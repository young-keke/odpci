using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WordEater.AllOfParser;

namespace WordEater
{
    class Model
    {
        private ObservableCollection<string> Words = new ObservableCollection<string>();
        public ObservableCollection<string> FoundWords = new ObservableCollection<string>();
        ParserWorker<string[]> Parser;
        List<string> eighteen = new List<string> { "абдоминоаортальный", "антиолигархический", "бишнуприя-манипури", "восстанавливавшись", "гребенчатосетчатый", "диссидентствовавши", "застраховывавшийся", "кальциетермический", "контрамаркирование", "малопоместительный", "нагреховодничавший", "несформулированный", "отлицензировавшись", "перекоммутировавши", "перештемпелёванный", "поруководствовавши", "проинвестировавший", "пятидесятиминутный", "рассогласовываться", "самообслуживавшись", "слабонаркотический", "тарифицировавшийся", "феноменологический", "экспрессионистский" };
        List<string> nineteen = new List<string> { "абонементодержатель", "аэрофотографический", "генерал-фельдмаршал", "дисциплинировавшись", "инженер-программист", "короткостебельность", "мясозаготовительный", "обмеблировывающийся", "перекоммутироваться", "порекомендовавшийся", "противопартизанский", "рационализированный", "сердечно-сосудистый", "транслитерироваться", "электроглянцеватель" };
        List<string> twenty = new List<string> { "абдоминоперинеальный", "восемнадцатисерийный", "жанрово-литературный", "компрометировавшийся", "недоукомплектоваться", "перепрограммирование", "простенографировавши", "сверхбарометрический", "ультрафундаменталист" };
        List<string> twentyOne= new List<string> { "абразивно-механически", "гонококконосительство", "контрпропагандистский", "переаттестовывающийся", "распропагандированный", "четырнадцатиградусный" };
        public Model()
        { }
        public Model(int i)
        {
            switch (i)
            {
                case 18:
                    Parser = new ParserWorker<string[]>(new WikiParser(), i, eighteen);
                    break;
                case 19:
                    Parser = new ParserWorker<string[]>(new WikiParser(), i, nineteen);
                    break;
                case 20:
                    Parser = new ParserWorker<string[]>(new WikiParser(), i, twenty);
                    break;
                case 21:
                    Parser = new ParserWorker<string[]>(new WikiParser(), i, twentyOne);
                    break;
            }
            Parser.OnCompleted += Parser_OnCompleted;
            Parser.OnNewData += Parser_OnNewData;
        }


        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            foreach (var word in arg2)
            {
                Words.Add(word);
            }
        }
        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("DONE");
        }


        public void StartParsing()
        {
            Parser.ParserSettings = new WikiSettings();
            Parser.Start();
        }
        //public void GetCount(string str)
        //{
        //    string c;
        //    int i=1;
        //    List<string> W = new List<string>();
        //    List<int> C = new List<int>();
        //    var deletedSpace = str.Replace(" ", "");
        //    for (int j = 0; j < deletedSpace.Length; j++)
        //    {
        //        c = deletedSpace[j].ToString();
        //        for (int kek = j + 1; kek < deletedSpace.Length; kek++)
        //        {

        //            if (c == deletedSpace[kek].ToString())
        //            {
        //                i++;
        //            }
        //            else continue;
        //        }
        //        W.Add(c);
        //        C.Add(i);
        //        deletedSpace = deletedSpace.Replace(c, "");
        //        i = 1;
        //    }
        //    Find(ref FoundWords, W[0], C[0]);
        //    for (int q = 1; q < W.Count; q++)
        //    {
        //        Find(ref FoundWords, W[q], C[q], FoundWords);
        //    }
        //}
        public void Find(ref ObservableCollection<string> result, string c, int i, ObservableCollection<string> col = null)//
        {
            ObservableCollection<string> Result = new ObservableCollection<string>();
            if (col != null && col.Any())
            {
                foreach (string word in col)
                {
                    int count = 0;
                    for (int j = 0; j < word.Length; j++)
                    {
                        if (word[j].ToString() == c)
                        {
                            count++;
                        }
                        else { }
                    }
                    if (count >= i)
                    {
                        Result.Add(word);
                    }
                    else { }
                }
            }
            else
            {
                foreach (string word in Words)
                {
                    int count = 0;
                    for (int j = 0; j < word.Length; j++)
                    {
                        if (c == word[j].ToString())
                        {
                            count++;
                        }
                        else { }
                    }
                    if (count >= i)
                    {
                        Result.Add(word);
                    }
                    else { }
                }
            }
            result = Result;
        }
    }
}
