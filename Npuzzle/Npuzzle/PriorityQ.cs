using System;

namespace Npuzzle
{
    class PriorityQ
    {

        State_Node[] heapArr;
        int length = 0;

        public PriorityQ()
        {
            heapArr = new State_Node[100000000];
        }

        public void insertKey(State_Node key)
        {
            length = length + 1;
            heapArr[length] = null;
            increaseKey(length, key);
        }

        public void increaseKey(int i, State_Node key)
        {
            heapArr[i] = key;
            while (i > 1 && heapArr[i / 2].cost >= heapArr[i].cost)
            {
                exchange(ref heapArr[i / 2], ref heapArr[i]);
                i = i / 2;
            }
        }


        public State_Node extractMin()
        {
            if (length == 0)
            {
                throw new InvalidOperationException("Queue is Empty");
            }
            State_Node minimum = heapArr[1];
            heapArr[1] = heapArr[length];
            length = length - 1;
            minHeapify(1, length);
            return minimum;

        }

        public bool isEmpty()
        {
            if (length == 0)
                return true;

            return false;
        }

        void minHeapify(int i, int heapSize)
        {
            int left = 2 * i;
            int right = 2 * i + 1;
            int least;

            if (left <= heapSize && heapArr[left].cost < heapArr[i].cost)
                least = left;
            else
                least = i;
            if (right <= heapSize && heapArr[right].cost < heapArr[least].cost)
                least = right;
            if (least != i)
            {
                exchange(ref heapArr[i], ref heapArr[least]);
                minHeapify(least, heapSize);
            }
        }

        void exchange(ref State_Node x, ref State_Node y)
        {
            State_Node t = x;
            x = y;
            y = t;
        }

    }
}



