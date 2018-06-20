using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {
            int N;
            double S=0,P=0;
            string tmp;
            
            Console.Write("N=  ");
            tmp = Console.ReadLine();
            N=int.Parse(tmp);

            for (int i = 1; i <= N;i++ ) {
                S += (double)1 / i;
                P += 1 / ((double)i * i);
            };
            Console.WriteLine("Сумма первых " + N + " членов равна " + S);
            Console.WriteLine("число Пи равно " + Math.Sqrt(P*6));

            //Console.WriteLine("Сумма первых {0:d} членов равна {0:f3}",N,S);
            Console.ReadKey();
        }
        
        static int StringToInt(string x) {
            int len;
            double sum = 0;
            if (x.Length>8) len=8; else len=x.Length;
            for (int i=0;i<len;i++) {
                if (x[i].Equals('0')) continue;
                if (x[i].Equals('1')) { sum += Math.Pow(10, len - i-1); continue; };
                if (x[i].Equals('2')) { sum += 2 * Math.Pow(10, len - i-1); continue; };
                if (x[i].Equals('3')) { sum += 3 * Math.Pow(10, len - i-1); continue; };
                if (x[i].Equals('4')) { sum += 4 * Math.Pow(10, len - i-1); continue; };
                if (x[i].Equals('5')) { sum += 5 * Math.Pow(10, len - i-1); continue; };
                if (x[i].Equals('6')) { sum += 6 * Math.Pow(10, len - i-1); continue; };
                if (x[i].Equals('7')) { sum += 7 * Math.Pow(10, len - i-1); continue; };
                if (x[i].Equals('8')) { sum += 8 * Math.Pow(10, len - i-1); continue; };
                if (x[i].Equals('9')) { sum += 9 * Math.Pow(10, len - i-1); continue; };
                return 0;
            };
            return (int)Math.Round(sum);
        }
    }
}
