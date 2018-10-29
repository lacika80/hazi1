using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGyak
{
    class MainLine
    {
        
        delegate void Parancs();   
        List<Parancs> P = new List<Parancs>();

        public void ConnectToEvent(Runner runner)
        {
            P.Add(runner.Back);
        }

        /// <summary>
        /// Főszál, ne kérdezd miért ez a neve. Már kicsit fáradt vok így hajnal 2-kor XD
        /// </summary>
        public void Alma()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine("a programot úgy irtam, hogy több futót terveztem eredetileg külön console ablakban, de azt nem tudtam így az este már megoldani");
                Console.WriteLine("szóval maradt, hogy van 1 futó amit listába helyezek és úgy adom hozzá az event-hez mintha több is lenne");
                Console.WriteLine("a lényeg hogy ez a futó egy 20x20-as kockában mászkál max 2 min 0 lépéssel");
                Console.WriteLine("ha lenyomsz egy gombot ami nem 'e' akkor elsétál minél gyorsabban a közepére");
                Console.WriteLine("ha e-t nyomsz akkor kilép a program.");
                Console.WriteLine("utána: vélemény?");
                key = Console.ReadKey();
                if (!(key.KeyChar == (char)13))
                {
                    Console.WriteLine("látom nem olvastad el... azt irtam, hogy Enter-t nyomj. (meg akk a többit is olvasd át mert késöbb nincs feltüntetve)");
                }
            } while (!(key.KeyChar == (char)13));

            Runner R = new Runner();
            ConnectToEvent(R);
            bool first = true;
            Task.Run(() => R.Run());
            do
            {
                if (!first)
                {
                    foreach (Parancs item in P)
                    {
                        item();
                    }
                }
                else
                    first = false;
            } while (!(Console.ReadKey().KeyChar == 'e'));
        }
    }
}
