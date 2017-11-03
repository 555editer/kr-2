using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace test
{

    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("text.txt");//создаём потоковый читатель из текстового файла
                
            string text = sr.ReadToEnd();//записываем всё из файла в text
            sr.Close();//закрываем поток
            Regex reg = new Regex("(0[1-9]|[12][0-9]|3[01])[.](0[1-9]|1[012])[.]\\d\\d\\d\\d");//рег. выр.
            MatchCollection matches = reg.Matches(text);//записываем все совпадения в matches

            StreamWriter sw = new StreamWriter("result.txt");
            foreach (Match match in matches)
            {
                sw.WriteLine(match.Value + "\n");//записываем в файл сод. результат по строкам (1 строка 1 дата)
            }

            sw.Close();    
        }
    }
}