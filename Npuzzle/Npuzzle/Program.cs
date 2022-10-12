using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Npuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 0;
            int blankRow = 0, blankCol = 0;
            int[] puzzle1D;

            //Solvable
            //sample (Done)
           //int[,] puzzle2D = readFromFile("8 Puzzle (1).txt", out puzzle1D, out size, out blankRow, out blankCol); //8
            //int[,] puzzle2D = readFromFile("8 Puzzle (2).txt", out puzzle1D, out size, out blankRow, out blankCol);//20
            //int[,] puzzle2D = readFromFile("8 Puzzle (3).txt", out puzzle1D, out size, out blankRow, out blankCol);//14
           //int[,] puzzle2D = readFromFile("15 Puzzle - 1.txt", out puzzle1D, out size, out blankRow, out blankCol);//5
            //int[,] puzzle2D = readFromFile("24 Puzzle 1.txt", out puzzle1D, out size, out blankRow, out blankCol);//11
            //int[,] puzzle2D = readFromFile("24 Puzzle 2.txt", out puzzle1D, out size, out blankRow, out blankCol);//24


            //hamming & manhattan (Done)
           // int[,] puzzle2D = readFromFile("50 Puzzle.txt", out puzzle1D, out size, out blankRow, out blankCol);//18
           // int[,] puzzle2D = readFromFile("99 Puzzle - 1.txt", out puzzle1D, out size, out blankRow, out blankCol);//18
           // int[,] puzzle2D = readFromFile("99 Puzzle - 2.txt", out puzzle1D, out size, out blankRow, out blankCol);//38
           // int[,] puzzle2D = readFromFile("9999 Puzzle.txt", out puzzle1D, out size, out blankRow, out blankCol);//4



            //manhattan (Done)
            int[,] puzzle2D = readFromFile("15 Puzzle 1.txt", out puzzle1D, out size, out blankRow, out blankCol);//46
            //int[,] puzzle2D = readFromFile("15 Puzzle 3.txt", out puzzle1D, out size, out blankRow, out blankCol);//38
            //int[,] puzzle2D = readFromFile("15 Puzzle 4.txt", out puzzle1D, out size, out blankRow, out blankCol);//44
           // int[,] puzzle2D = readFromFile("15 Puzzle 5.txt", out puzzle1D, out size, out blankRow, out blankCol);//45


            //Very Larg - max time 2m (Done)
           // int[,] puzzle2D = readFromFile("TEST.txt", out puzzle1D, out size, out blankRow, out blankCol);//56

            //--------------------------------------------------------------------------------------------------------------

            //Unsolvable
            //sample (Done)
            //int[,] puzzle2D = readFromFile(@"Unsolvable\8 Puzzle - Case 1.txt", out puzzle1D, out size, out blankRow, out blankCol);
           // int[,] puzzle2D = readFromFile(@"Unsolvable\8 Puzzle(2) - Case 1.txt", out puzzle1D, out size, out blankRow, out blankCol);
            //int[,] puzzle2D = readFromFile(@"Unsolvable\8 Puzzle(3) - Case 1.txt", out puzzle1D, out size, out blankRow, out blankCol);
            //int[,] puzzle2D = readFromFile(@"Unsolvable\15 Puzzle - Case 2.txt", out puzzle1D, out size, out blankRow, out blankCol);
            //int[,] puzzle2D = readFromFile(@"Unsolvable\15 Puzzle - Case 3.txt", out puzzle1D, out size, out blankRow, out blankCol);

            //complete (Done)
            //int[,] puzzle2D = readFromFile(@"Unsolvable\15 Puzzle 1 - Unsolvable.txt", out puzzle1D, out size, out blankRow, out blankCol);
            //int[,] puzzle2D = readFromFile(@"Unsolvable\99 Puzzle - Unsolvable Case 1.txt", out puzzle1D, out size, out blankRow, out blankCol);
            //int[,] puzzle2D = readFromFile(@"Unsolvable\99 Puzzle - Unsolvable Case 2.txt", out puzzle1D, out size, out blankRow, out blankCol);
          // int[,] puzzle2D = readFromFile(@"Unsolvable\9999 Puzzle.txt", out puzzle1D, out size, out blankRow, out blankCol);





            //Main menue
            if (cheackSolvability(puzzle1D, size, blankRow))
            {
                Console.WriteLine("Solvable");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Choose the heuristic Value type");
                Console.WriteLine("[1] Hamming Distance");
                Console.WriteLine("[2] Manhattan Distance");
                int type = Convert.ToInt32(Console.ReadLine());
                int heruicValue = 0;
                if (type == 1)
                {
                    Stopwatch timer11 = new Stopwatch();
                    
                    timer11.Start();
                    System.Threading.Thread.Sleep(500);



                    Console.WriteLine();
                    heruicValue = AstarFunctions.calculateHamming(puzzle2D, size);
                    State_Node initState = new State_Node(puzzle2D, size, blankRow, blankCol, heruicValue, 0, null, 1);
                    State_Node goal = AstarFunctions.AstarAlgorithm(initState);
                    int minMoves = goal.currentSteps;
                    if (size == 3)
                        AstarFunctions.displaySteps(goal);
                    Console.WriteLine("Minimum # Of Moves = " + minMoves);
                    Console.WriteLine();


                    timer11.Stop();
                    Console.WriteLine("Time : {0}", timer11.Elapsed);

                }

                else if (type == 2)
                {
                    Stopwatch timer22 = new Stopwatch();
                    
                    timer22.Start();
                    System.Threading.Thread.Sleep(500);

                    Console.WriteLine();
                    heruicValue = AstarFunctions.calculateManhattan(puzzle2D, size);
                    State_Node initState = new State_Node(puzzle2D, size, blankRow, blankCol, heruicValue, 0, null, 2);
                    State_Node goal = AstarFunctions.AstarAlgorithm(initState);
                    int minMoves = goal.currentSteps;
                    if (size == 3)
                        AstarFunctions.displaySteps(goal);
                    Console.WriteLine("Minimum # Of Moves = " + minMoves);
                    Console.WriteLine();

                    timer22.Stop();

                    Console.WriteLine("Time : {0}", timer22.Elapsed);
                }

            }
            else
                Console.WriteLine("UnSolvable");

        }

        public static int[,] readFromFile(string path, out int[] p, out int s, out int blankRow, out int blankCol)
        {
            //This function reads the puzzle from the file and Parse it into 1D AND 2D array and we save the position of blank cell to for later Operations

            string contet = File.ReadAllText(path);
            contet = Regex.Replace(contet, @"\s+", ",");
            if (contet[contet.Length - 1] == ',')
                contet = contet.Remove(contet.Length - 1);
            int[] puzzle1D = contet.Split(' ', ',').Select(z => Convert.ToInt32(z)).ToArray();
            int size = puzzle1D[0];
            int bR = 0, bC = 0;
            puzzle1D = puzzle1D.Skip(1).ToArray();

            int[,] puzzle2D = new int[size, size];
            int c = 0;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    puzzle2D[x, y] = puzzle1D[c];
                    if (puzzle2D[x, y] == 0)
                    {
                        bR = x;
                        bC = y;
                    }
                    c++;
                }
            }
            blankRow = bR;
            blankCol = bC;
            s = size;
            p = puzzle1D;
            return puzzle2D;

        }

        static int calculateInversionCount(int[] puzzle, int size)
        {
            //Calculate invCount for all numbers except blank space
            int inversionCount = 0;
            for (int i = 0; i < size * size - 1; i++)
            {
                for (int j = i + 1; j < size * size; j++)
                {
                    if (puzzle[i] != 0 && puzzle[j] != 0 && puzzle[i] > puzzle[j])
                        inversionCount++;
                }
            }
            return inversionCount;
        }

        static bool cheackSolvability(int[] puzzle, int size, int blankIndex)
        {
            int inversionCount = calculateInversionCount(puzzle, size);

            //checking if the puzzle has a solution 
            if (size % 2 != 0)
            {
                if (inversionCount % 2 == 0)
                    return true;
            }
            else if (size % 2 == 0)
            {
                if (inversionCount % 2 != 0 && blankIndex % 2 == 0)
                    return true;
                else if (inversionCount % 2 == 0 && blankIndex % 2 != 0)
                    return true;
            }
            return false;
        }

    }
}



