using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCDay10
{
    class Program
    {
        public static void Main()
        {
            var Input = File.ReadAllText(@"C:\Users\Mark\source\repos\AoCDay10\AoCDay10\input.txt");
            var SplitPut = Input.Split("\n");

            var StartPosition = FindStart(SplitPut)
                .Split(' ');
            Console.WriteLine(SplitPut[int.Parse(StartPosition[0])][int.Parse(StartPosition[1])]);
        }

        static string FindStart(string[] input)
        {
            for (int i = 0; i < input.Length; i++) { 
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j].Equals('S'))
                    {
                        return (i.ToString() + " " + j.ToString());
                    }
                }
            }
            return ("00");
        }        
    }
}
