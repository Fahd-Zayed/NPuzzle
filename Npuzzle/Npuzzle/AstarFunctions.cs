using System;


namespace Npuzzle
{
    class AstarFunctions
    {
        public static PriorityQ Q = new PriorityQ();


        public static State_Node AstarAlgorithm(State_Node initailState)
        {
            Q.insertKey(initailState);
            State_Node min;
            while (!Q.isEmpty())
            {
                //Extracting the top of the heap which has the minimum cost;
                min = Q.extractMin();

                //if the heuristic value = 0 that means no misplaced values and that's the goal state
                if (min.heruicValue == 0)
                    return min;

                //getting the possibilites of the moves then add it to the Queue
                AstarFunctions.generateNextMoves(min);

            }
            return null;
        }


        public static void generateNextMoves(State_Node Parent)
        {
            //What I need to do here is to get the child Nodes then add it to the Queue
            //Create a new node with each new state and add it to the queue if it's diffrent from its GrandParent
            //Calculate Hamming OR Manhattan for every new state
            if (Parent.up)
            {
                //This means that (blankCell) can move up
                if (Parent.huristicType == 1)
                {
                    int[,] newState = new int[Parent.puzzleSize, Parent.puzzleSize];
                    Array.Copy(Parent.state, newState, Parent.state.Length);
                    swapBlank(ref newState[Parent.blankRow, Parent.blankCol], ref newState[Parent.blankRow - 1, Parent.blankCol]);
                    int hammingDistance = calculateHamming(newState, Parent.puzzleSize);
                    State_Node newNode = new State_Node(newState, Parent.puzzleSize, Parent.blankRow - 1, Parent.blankCol, hammingDistance, Parent.currentSteps + 1, Parent,1);
                    if (!((Parent.parent != null && newNode.blankRow == Parent.parent.blankRow && newNode.blankCol == Parent.parent.blankCol)))
                    {
                        newNode.cost = newNode.currentSteps + newNode.heruicValue;
                        Q.insertKey(newNode);
                    }
                }
                else if (Parent.huristicType == 2)
                {
                    int[,] newState = new int[Parent.puzzleSize, Parent.puzzleSize];
                    Array.Copy(Parent.state, newState, Parent.state.Length);
                    swapBlank(ref newState[Parent.blankRow, Parent.blankCol], ref newState[Parent.blankRow - 1, Parent.blankCol]);
                    int ManhattanDistance = calculateManhattan(newState, Parent.puzzleSize);
                    State_Node newNode = new State_Node(newState, Parent.puzzleSize, Parent.blankRow - 1, Parent.blankCol, ManhattanDistance, Parent.currentSteps + 1, Parent, 2);
                    if (!((Parent.parent != null && newNode.blankRow == Parent.parent.blankRow && newNode.blankCol == Parent.parent.blankCol)))
                    {
                        newNode.cost = newNode.currentSteps + newNode.heruicValue;
                        Q.insertKey(newNode);
                    }
                }
            }

            if (Parent.down)
            {
                //This means that (blankCell) can move down
                if (Parent.huristicType == 1)
                {
                    int[,] newState = new int[Parent.puzzleSize, Parent.puzzleSize];
                    Array.Copy(Parent.state, newState, Parent.state.Length);
                    swapBlank(ref newState[Parent.blankRow, Parent.blankCol], ref newState[Parent.blankRow + 1, Parent.blankCol]);
                    int hammingDistance = calculateHamming(newState, Parent.puzzleSize);
                    State_Node newNode = new State_Node(newState, Parent.puzzleSize, Parent.blankRow + 1, Parent.blankCol, hammingDistance, Parent.currentSteps + 1, Parent, 2);
                    if (!((Parent.parent != null && newNode.blankRow == Parent.parent.blankRow && newNode.blankCol == Parent.parent.blankCol)))
                    {
                        newNode.cost = newNode.currentSteps + newNode.heruicValue;
                        Q.insertKey(newNode);
                    }
                }
                else if (Parent.huristicType == 2)
                {
                    int[,] newState = new int[Parent.puzzleSize, Parent.puzzleSize];
                    Array.Copy(Parent.state, newState, Parent.state.Length);
                    swapBlank(ref newState[Parent.blankRow, Parent.blankCol], ref newState[Parent.blankRow + 1, Parent.blankCol]);
                    int ManhattanDistance = calculateManhattan(newState, Parent.puzzleSize);
                    State_Node newNode = new State_Node(newState, Parent.puzzleSize, Parent.blankRow + 1, Parent.blankCol, ManhattanDistance, Parent.currentSteps + 1, Parent, 2);
                    if (!((Parent.parent != null && newNode.blankRow == Parent.parent.blankRow && newNode.blankCol == Parent.parent.blankCol)))
                    {
                        newNode.cost = newNode.currentSteps + newNode.heruicValue;
                        Q.insertKey(newNode);
                    }
                }

            }

            if (Parent.left)
            {
                //This means that (blankCell) can move left
                if (Parent.huristicType == 1)
                {
                    int[,] newState = new int[Parent.puzzleSize, Parent.puzzleSize];
                    Array.Copy(Parent.state, newState, Parent.state.Length);
                    swapBlank(ref newState[Parent.blankRow, Parent.blankCol], ref newState[Parent.blankRow, Parent.blankCol - 1]);
                    int hammingDistance = calculateHamming(newState, Parent.puzzleSize);
                    State_Node newNode = new State_Node(newState, Parent.puzzleSize, Parent.blankRow, Parent.blankCol - 1, hammingDistance, Parent.currentSteps + 1, Parent, 1);
                    if (!((Parent.parent != null && newNode.blankRow == Parent.parent.blankRow && newNode.blankCol == Parent.parent.blankCol)))
                    {
                        newNode.cost = newNode.currentSteps + newNode.heruicValue;
                        Q.insertKey(newNode);
                    }
                }
                else if (Parent.huristicType == 2)
                {
                    int[,] newState = new int[Parent.puzzleSize, Parent.puzzleSize];
                    Array.Copy(Parent.state, newState, Parent.state.Length);
                    swapBlank(ref newState[Parent.blankRow, Parent.blankCol], ref newState[Parent.blankRow, Parent.blankCol - 1]);
                    int ManhattanDistance = calculateManhattan(newState, Parent.puzzleSize);
                    State_Node newNode = new State_Node(newState, Parent.puzzleSize, Parent.blankRow, Parent.blankCol - 1, ManhattanDistance, Parent.currentSteps + 1, Parent, 2);
                    if (!((Parent.parent != null && newNode.blankRow == Parent.parent.blankRow && newNode.blankCol == Parent.parent.blankCol)))
                    {
                        newNode.cost = newNode.currentSteps + newNode.heruicValue;
                        Q.insertKey(newNode);

                    }
                }

            }

            if (Parent.right)
            {
                //This means that (blankCell) can move right
                if (Parent.huristicType == 1)
                {
                    int[,] newState = new int[Parent.puzzleSize, Parent.puzzleSize];
                    Array.Copy(Parent.state, newState, Parent.state.Length);
                    swapBlank(ref newState[Parent.blankRow, Parent.blankCol], ref newState[Parent.blankRow, Parent.blankCol + 1]);
                    int hammingDistance = calculateHamming(newState, Parent.puzzleSize);
                    State_Node newNode = new State_Node(newState, Parent.puzzleSize, Parent.blankRow, Parent.blankCol + 1, hammingDistance, Parent.currentSteps + 1, Parent, 1);
                    if (!((Parent.parent != null && newNode.blankRow == Parent.parent.blankRow && newNode.blankCol == Parent.parent.blankCol)))
                    {
                        newNode.cost = newNode.currentSteps + newNode.heruicValue;
                        Q.insertKey(newNode);
                    }
                }
                else if (Parent.huristicType == 2)
                {
                    int[,] newState = new int[Parent.puzzleSize, Parent.puzzleSize];
                    Array.Copy(Parent.state, newState, Parent.state.Length);
                    swapBlank(ref newState[Parent.blankRow, Parent.blankCol], ref newState[Parent.blankRow, Parent.blankCol + 1]);
                    int ManhattanDistance = calculateManhattan(newState, Parent.puzzleSize);
                    State_Node newNode = new State_Node(newState, Parent.puzzleSize, Parent.blankRow, Parent.blankCol + 1, ManhattanDistance, Parent.currentSteps + 1, Parent, 2);
                    if (!((Parent.parent != null && newNode.blankRow == Parent.parent.blankRow && newNode.blankCol == Parent.parent.blankCol)))
                    {
                        newNode.cost = newNode.currentSteps + newNode.heruicValue;
                        Q.insertKey(newNode);
                    }
                }


            }

        }



        public static int calculateHamming(int[,] puzzle2D, int size)
        {
            //This function gets the hamming distance by comparing the puzzle with a sample of its goal when we find a diffrence in place we increament the distance
            int[,] gaolSample = new int[size, size];
            int hamming = 0, s = 1;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    gaolSample[i, j] = s;
                    if (puzzle2D[i, j] != 0 && puzzle2D[i, j] != gaolSample[i, j])
                        hamming++;
                    s++;

                }
            }
            return hamming;
        }

        public static int calculateManhattan(int[,] Puzzle2D, int size)
        {
            //This function gets the manhattan distance by calculating the horizontal and vertical distance between the current cell and the correct one in the goal
            int manhattanDistance = 0, correctRow = 0, correctCol = 0;
            int currentRow = 0, currentCol = 0;

            for (int i = 0; i < size * size; i++)
            {
                currentRow = i / size;
                currentCol = i % size;
                if (Puzzle2D[currentRow, currentCol] != 0)
                {
                    correctRow = (Puzzle2D[currentRow, currentCol] - 1) / size;
                    correctCol = ((Puzzle2D[currentRow, currentCol] - 1) % size);

                    manhattanDistance += Math.Abs(correctRow - currentRow) + Math.Abs(correctCol - currentCol);
                }

            }
            return manhattanDistance;
        }




        static void swapBlank(ref int oldBlank, ref int newBlank)
        {
            //Noraml Swap
            int tmp = oldBlank;
            oldBlank = newBlank;
            newBlank = tmp;
        }



        public static void displaySteps(State_Node s)
        {
            //To display the movements we took to reach goal state in 8-Puzzle
            if (s == null)
                return;

            displaySteps(s.parent);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write(s.state[i, j] + " ");

                Console.WriteLine();
            }
            Console.WriteLine("-------------------");
        }

    }
}
