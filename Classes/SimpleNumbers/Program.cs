using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllText("file.txt");
            var lexical = new Lexical(text);
            var tokens = new List<Token>();
            while(true){
                var token = lexical.GetToken();
                if (token != null)
                {
                    if (token.Code != TokenCode.EOF)
                        tokens.Add(token);
                    else
                        break;
                }
            }
            Print(tokens);
        }

        private static void Print(List<Token> tokens)
        {
            foreach (var token in tokens)
                Console.WriteLine($"{token.Code.ToString()}: {token.Symbol}");
            Console.ReadLine();
        }
    }
}
