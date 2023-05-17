namespace MoogleEngine;

public class Document
{
    public string route;
    public Vectorizing VecDoc;
    public double score;

    public Document(string route)
    {
        this.route = route;
    }

    public void GetScore(Vectorizing Vec)
    {
        this.score = Vec * this.VecDoc;
    }

    public string GetTitle()
    {
        return this.route.Substring(this.route.LastIndexOf("/") + 1);
    }

    public string GetSnippet(string[] query)
    {
        string pointerword = "";
        string snipe = "";
        
        double maxweigth = 0;
        
        foreach (string word in query)
        {
            if(VecDoc.v.ContainsKey(word) && VecDoc[word] > maxweigth)
            {
                maxweigth = VecDoc[word];
                pointerword = word;
            }            
        }    
    
        string[] text = File.ReadAllText(this.route).Split();
        int index = Aux.Find(pointerword , text);

        int end = Math.Min(text.Length - 1 , index + 30);
        for(int i = Math.Max(0, index - 10) ; i < end ; i++)
        {
            snipe += text[i] + " ";
        }
        return snipe;
    }
}
