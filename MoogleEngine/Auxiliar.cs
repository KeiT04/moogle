using System.Text.RegularExpressions;

namespace MoogleEngine;

public class Aux
{
    public static string tokenizer(string input)
    {
        Regex rgx = new Regex("[^a-zA-Z0-9*~!áéíóú]");

        string token = rgx.Replace(input , " ");

        token = Regex.Replace(token, @"\s+", " ");

        token = token.ToLower();

        return token;
    }

    public static void Manage(Document[] docs)
    {
        for(int i = 0; i < docs.Length; i++)
        {
            int max = i;
            for(int j = i + 1 ; j < docs.Length ; j++)
            {
                if(docs[j].score > docs[max].score)
                    max = j;
            }
            (docs[i], docs[max]) = (docs[max], docs[i]);
        }
    }

    public static int MaxFq(Dictionary<string, Dictionary<int,int> > dict , int pos)
    {
        int max = 0;
        foreach (var wordfreq in dict.Values)
        {
            if(wordfreq.ContainsKey(pos))
            {
                max = Math.Max(max, wordfreq[pos]);
            }
        }
        return max;
    }

    public static int MaxFq(string[] arr)
    {
        int maxrep = 0;
        bool[] taken = new bool[arr.Length];
        
        for(int j = 0; j < arr.Length; j++)
        {
            if(taken[j] == false)
            {
                int rep = 1 ;
                for(int i = j + 1; i < arr.Length; i ++ )
                {
                    if(arr[i] == arr[j])
                    {
                        rep++;
                        taken[i] = true;
                    }
                }
                maxrep = Math.Max(rep, maxrep);
            }
        }
        return maxrep;
    }

    public static int Find(string word, string[] text)
    {
        for(int j = 0; j < text.Length; j++ )
        {
            if(word == Aux.tokenizer(text[j]))
                return j;
        }
        return -1;
    }
}