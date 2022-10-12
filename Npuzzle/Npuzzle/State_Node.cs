namespace Npuzzle
{
    class State_Node
    {
        public int[,] state;
        public int huristicType;
        public State_Node parent = null;
        public int blankRow;
        public int blankCol;
        public int currentSteps;
        public int cost;
        public int heruicValue;
        public int puzzleSize;
        public bool down, up, left, right;


        public State_Node(int[,] state, int puzzleSize, int blankRow, int blankCol, int heruicValue, int level, State_Node parent, int huristicType)
        {

            this.state = state;
            this.puzzleSize = puzzleSize;
            this.parent = parent;
            this.blankRow = blankRow;
            this.blankCol = blankCol;
            this.currentSteps = level;
            this.heruicValue = heruicValue;
            this.huristicType = huristicType;

            //We assign the moves state according to the position of the blank cell in row and coloumn so we know what moves can be done
            if (this.blankRow > 0)
                this.up = true;
            if (this.blankRow < this.puzzleSize - 1)
                this.down = true;
            if (this.blankCol > 0)
                this.left = true;
            if (this.blankCol < this.puzzleSize - 1)
                this.right = true;

        }


    }

}
