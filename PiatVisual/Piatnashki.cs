using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Lesson_6
{
    public class Piatnashki
    {
        public int[,] array;

        private readonly int dim = 4;

        private int _zeroX;
        private int _zeroY;

        public bool Win { get; private set; }

        public enum Direction
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        public Piatnashki()
        {
            array = CreateArray(dim);

            //PrintArray(arr, 4, 4);


            shuffle();

            PrintArray(array, dim, dim);
        }

        public void Play()
        {
            
            while (!Win)
            {
                PrintArray(array, dim, dim);
                Console.WriteLine("Next move! W -> up, A -> left, S -> down, D -> right");

                ConsoleKeyInfo k = Console.ReadKey();
                
                switch (k.KeyChar)
                {
                    case 'w':
                        Move(Direction.UP);
                        break;
                    case 'a':
                        Move(Direction.LEFT);
                        break;
                    case 's':
                        Move(Direction.DOWN);
                        break;
                    case 'd':
                        Move(Direction.RIGHT);
                        break;
                    case (char)ConsoleKey.Escape:
                        return;
                        //break;
                }
                
                checkWin();

            }

        }
        public void Restart()
        {
            Win = false;
            shuffle();
        }
        public void Move(Direction dir)
        {
            Console.WriteLine($"  {_zeroX}    {_zeroY}");
            switch (dir)
            {
                case Direction.DOWN:
                    if (_zeroX < (dim - 1))
                    {
                        ChangeElements(Direction.DOWN, _zeroX, _zeroY);
                    }
                    break;
                case Direction.LEFT:
                    if (_zeroY > 0)
                    {
                        ChangeElements(Direction.LEFT, _zeroX, _zeroY);
                    }
                    break;
                case Direction.RIGHT:
                    if (_zeroY < (dim - 1))
                    {
                        ChangeElements(Direction.RIGHT, _zeroX, _zeroY);
                    }
                    break;
                case Direction.UP:
                    if (_zeroX > 0)
                    {
                        ChangeElements(Direction.UP, _zeroX, _zeroY);
                    }
                    break;
            }
            checkWin();
        }
        private void ChangeElements(Direction direc, int pos0_x, int pos0_y)
        {
            int tempVar;
            //Console.WriteLine($"  {_zeroX}    {_zeroY}");
            switch (direc)
            {
                case Direction.DOWN:

                    tempVar = array[pos0_x + 1, pos0_y]; //element wich we change with zero
                    array[pos0_x + 1, pos0_y] = 0;       //set zero in next position
                    array[pos0_x, pos0_y] = tempVar;     //set element to previous zero position
                    _zeroX++;
                    break;
                case Direction.LEFT:
                    tempVar = array[pos0_x, pos0_y - 1];
                    array[pos0_x, pos0_y - 1] = 0;
                    array[pos0_x, pos0_y] = tempVar;
                    _zeroY--;
                    break;
                case Direction.RIGHT:
                    tempVar = array[pos0_x, pos0_y + 1];
                    array[pos0_x, pos0_y + 1] = 0;
                    array[pos0_x, pos0_y] = tempVar;
                    _zeroY++;
                    break;
                case Direction.UP:
                    tempVar = array[pos0_x - 1, pos0_y];
                    array[pos0_x - 1, pos0_y] = 0;
                    array[pos0_x, pos0_y] = tempVar;
                    _zeroX--;
                    break;
            }

        }
        private void checkWin()
        {
            int tempVar = array[0, 0];
            for (int i = 0; i < (dim); i++)
            {
                for (int j = 0; j < (dim); j++)
                {
                    if (i == 0 && j == 0) continue;
                    if ((array[i, j] - tempVar) != 1)
                    {
                        Console.WriteLine($"array item: {array[i, j]}   tempVar: {tempVar}");
                        return;
                    }
                    tempVar = array[i, j];


                }
            }
            Win = true;
            Console.WriteLine("UR WIN!!!!CONGRATS!!!!!");

        }

        private int[,] CreateArray(int items)
        {

            int[,] arrTemp = new int[items, items];

            //PrintArray(arr, arrX, arrY);
            int counter = 0;

            for (int i = 0; i < items; i++)
            {
                for (int j = 0; j < items; j++)
                {
                    arrTemp[i, j] = counter++;
                }
            }
            _zeroX = 0;
            _zeroY = 0;
            //PrintArray(arr, arrX, arrY);
            return arrTemp;

        }

        private void PrintArray(int[,] arr, int arrX, int arrY)
        {
            //var c = arr.Length / arr.Rank;
            Console.WriteLine();
            for (int i = 0; i < arrX; i++)
            {
                for (int j = 0; j < arrY; j++)
                {
                    Console.Write("\t" + arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }
        private void shuffle()
        {
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                int index1 = rnd.Next(dim);
                int index2 = rnd.Next(dim);

                int tempVar = array[index1, index2];

                int index3 = rnd.Next(dim);
                int index4 = rnd.Next(dim);

                array[index1, index2] = array[index3, index4];
                array[index3, index4] = tempVar;



            }
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    if (array[i, j] == 0)
                    {
                        _zeroX = i;
                        _zeroY = j;

                        break;
                    }
                }
            }
            //Console.WriteLine($"  {_zeroX}    {_zeroY}");
        }
    }
}
