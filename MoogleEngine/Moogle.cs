namespace MoogleEngine;

public static class Moogle
{
    public static SearchResult Query(string query) {

        string[] terms = Aux.tokenizer(query).Split();
        Data.DataBase.EjecutarQuery(terms);
        
        int max = Data.DataBase.docs.Length;
        
        for(int i = 0; i < max; i ++)
        {
            if(Data.DataBase.docs[i].score == 0)
            {
                max = i;
                break;
            }
        }
        
        SearchItem[] items = new SearchItem[max];
        for(int i = 0; i < max; i ++)
        {
            Document actual = Data.DataBase.docs[i];
            items[i] = new SearchItem(actual.GetTitle(), actual.GetSnippet(terms), (float)actual.score);
            Console.WriteLine(actual.score);
        }
        return new SearchResult(items,query);
    }
}