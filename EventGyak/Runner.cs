using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventGyak
{
    class Runner
    {
        int x = 10;
        int y = 10;
        bool back = false;
        static Random rn = new Random();

        /// <summary>
        /// ez van meghivva a delegate-el
        /// </summary>
        public void Back()
        {
            back = true;
        }
        /// <summary>
        /// az ugrálás váza
        /// </summary>
        public void Run()
        {
            do
            {
                Thread.Sleep(1000);
                Console.Clear();
                x += State(x);
                y += State(y);
                kiir();
                if ((x == 10) && (y == 10) && back)
                    back = false;
            } while (true);
        }
        /// <summary>
        /// megadja a helyzet változás mértékét, úgy hogy ne menjen ki a 20x20-as kockából
        /// </summary>
        /// <param name="xy">az x vagy az y</param>
        /// <returns>a változás mértéke</returns>
        protected int State(int xy)
        {
            int direction = 0;
            if (!back)
                switch (xy)
                {
                    case 0:
                        direction = rn.Next(2);
                        break;
                    case 1:
                        direction = rn.Next(-1, 2);
                        break;
                    case 19:
                        direction = rn.Next(-2, 1);
                        break;
                    case 20:
                        direction = rn.Next(-2, 0);
                        break;
                    default:
                        direction = rn.Next(-2, 2);
                        break;
                }
            else
            {
                Console.Clear();
                Console.WriteLine("a cél: 10;10 vagyis a közepe");
                if (xy < 9)
                {
                    direction = 2;
                }
                else if (xy < 10)
                {
                    direction = 1;
                }
                else if (xy == 10)
                {
                    direction = 0;
                }
                else if (xy > 11)
                {
                    direction = -2;
                }
                else if (xy > 10)
                {
                    direction = -1;
                }
                else
                    throw new Exception("hibás paraméterezés a runner state függvényének back fázisában");
            }
            return direction;
        }
        /// <summary>
        /// képi megjelenítés
        /// </summary>
        protected void kiir()
        {
            if (!back)
                Console.WriteLine();
            Console.WriteLine("XX 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20");
            for (int yy = 1; yy < 21; yy++)
            {
                if (yy < 10)
                    Console.Write("0{0} ", yy);
                else
                    Console.Write(yy + " ");
                for (int xx = 1; xx < 21; xx++)
                {
                    if ((yy == y) && (xx == x))
                    {
                        Console.Write("+  ");
                    }
                    else
                        Console.Write("W  ");
                }
                Console.WriteLine();
            }
        }
    }
}
