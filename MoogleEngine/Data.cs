namespace MoogleEngine;

public class Data
{
    public static DB DataBase = new DB();
}

public class DB
{
    public Document [] docs;
    static Dictionary <string, Dictionary <int, int>> Contenido = new Dictionary <string, Dictionary <int, int>>();
    public Vectorizing Vec;

    public void Loading(string dir)
    {
        SearchFiles(dir);
        SetContenido();
        CreateVectors();
    }
    public void SearchFiles(string dir)
    {   
        dir = Path.Combine(Directory.GetCurrentDirectory(), "..", dir);
        IEnumerable<string> routes = Directory.EnumerateFiles(dir, "*txt", SearchOption.AllDirectories);
        this.docs = new Document[routes.Count()];
        
        for(int i = 0; i < this.docs.Length ; i++)
        {
            docs[i] = new Document(routes.ElementAt(i));
        }
    }

    public void SetContenido()
    {
        for(int i = 0; i < this.docs.Length; i++)
        {
            string[] text = Aux.tokenizer(File.ReadAllText(docs[i].route)).Split();

            foreach (string w in text)
            {
                if( !Contenido.ContainsKey(w))
                    Contenido[w] = new Dictionary <int , int>() ; 
                
                if(!Contenido[w].ContainsKey(i))
                Contenido[w].Add(i , 0);
                
                Contenido[w][i]++;
            }
        }    
    }

    public void CreateVectors()
    {
        for(int i = 0; i < docs.Length; i++)
        {
            docs[i].Vd = new Vectorizing();

            int maxfq = Aux.MaxFq(Contenido , i);
            foreach(string word in Contenido.Keys)
            {
                if(Contenido[word].ContainsKey(i))
                {
                    double tf = Contenido[word][i] / (maxfq + 1.0) ;
                    double idf = Math.Log10((docs.Length + 1.0)/(Contenido[word].Count + 1.0));
                    docs[i].Vd[word] = tf * idf ;
                }
            }
        }
    }

    public void EjecutarQuery(string[] query)
    {
        CreateVec(query);
    
        for(int i = 0 ; i < docs.Length ; i++)
            docs[i].GetScore(Vec) ;
    
        Aux.Manage(docs);
    }

    public void CreateVec(string[] query)
    {
        this.Vec = new Vectorizing();
        int maxfq = Aux.MaxFq(query) ;

        foreach (string word in query)
        {
            if(!Vec.v.ContainsKey(word)) //(para no ingresar nuevamente palabras repetidas)
            {
                int nj = 0 ;
                if(Contenido.ContainsKey(word)) nj = (Contenido[word].Count) ;
                else nj  = docs.Length ;
  
                double tf = query.Count(s => s == word) / (maxfq + 1.0);
                double idf = Math.Log10( (docs.Length + 1.0) / ( nj + 1.0) );
                Vec[word] = tf * idf ;
            }
        }       
    }    
}