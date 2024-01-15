using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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
            Console.WriteLine(PipeTravel(int.Parse(StartPosition[1]), int.Parse(StartPosition[0]), SplitPut));

            //Console.WriteLine(SplitPut[int.Parse(StartPosition[0])][int.Parse(StartPosition[1])]);
            
        }

        static int PipeTravel(int X, int Y, string[] Input)
        {
            int Steps = 0;
            string PreviousMove = null;
            bool Looper = true;

            while (Looper)
            {
                string NextMove = CheckDirections(X, Y, Input, PreviousMove);
                if (NextMove == "North")
                {
                    Y--;
                }
                if (NextMove == "South")
                {
                    Y++;
                }
                if (NextMove == "East")
                {
                    X++;
                }
                if (NextMove == "West")
                {
                    X--;
                }

                Steps = Steps + 1;
                PreviousMove = NextMove;
                Console.WriteLine(Steps);
                if (Input[Y][X] == 'S'){
                    Looper = false; 
                }

            }
            //Console.WriteLine(Input[Y][X]);
            return Steps / 2;
        }

        static string CheckDirections(int X, int Y, string[] Input, string Prev)
        {
            var NorthMove = new[] { '|', 'J', 'L' };
            var SouthMove = new[] { '|', 'F', '7' };
            var WestMove = new[] { '-', 'J', '7' };
            var EastMove = new[] { '-', 'F', 'L' };

            var SMovementNorth = new[] { '|', 'F', '7' };
            var SMovementSouth = new[] { '|', 'J', 'L' };
            var SMovementWest = new[] { '-', 'F', 'L' };
            var SMovementEast = new[] { '-', 'J', '7' };

            if (Prev == "null")
            {
                return "North";
            }

            if (Input[Y][X] == 'S')
            {
                if (SMovementNorth.Any(x => Input[Y - 1][X].ToString().Contains(x)))
                {
                    return "North";
                }
                if (SMovementSouth.Any(x => Input[Y + 1][X].ToString().Contains(x)))
                {
                    return "South";
                }
                if (SMovementWest.Any(x => Input[Y][X - 1].ToString().Contains(x)))
                {
                    return "West";
                }
                if (SMovementEast.Any(x => Input[Y][X + 1].ToString().Contains(x)))
                {
                    return "East";
                }
            }

            if (NorthMove.Any(x => Input[Y][X].ToString().Contains(x)) && Prev != "South")
            {
                return "North";
            }
            if (SouthMove.Any(x => Input[Y][X].ToString().Contains(x)) && Prev != "North")
            {
                return "South";
            }
            if (WestMove.Any(x => Input[Y][X].ToString().Contains(x)) && Prev != "East")
            {
                return "West";
            }
            if (EastMove.Any(x => Input[Y][X].ToString().Contains(x)) && Prev != "West")
            {
                return "East";
            }


            return "null";
        }


        static string FindStart(string[] Input)
        {
            for (int i = 0; i < Input.Length; i++) { 
                for (int j = 0; j < Input[i].Length; j++)
                {
                    if (Input[i][j].Equals('S'))
                    {
                        return (i.ToString() + " " + j.ToString());
                    }
                }
            }
            return ("00");
        }        
    }
}
