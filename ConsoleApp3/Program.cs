using System;

namespace std
{
    static class Program
    {

        public static int TwoToStepen(int step)
        {
            int answer = 1;

            while (step != 0)
            {
                answer *= 2;
                step--;
            }
            return answer;
        }
        public static int Roof(double num)
        {
            int constant = 100;
            double firstVar = num;
            double secondVar = firstVar;
            for (int i = 0; i < constant; i++)
            {
                firstVar = (firstVar + secondVar / firstVar) / 2;
            }
            return (int)firstVar;
        }
        public static double SumArifmProgr(double a1, double a2, int n)
        {
            var lastPoint = a1 + (n - 1) * (a2 - a1);
            var sumAP = ((a1 + lastPoint) * n) / 2;

            return sumAP;
        }
        static void Main()
        {
            // ЗАДАЧА 1 (PS1 Ч.1. #12)
            Console.WriteLine("Координаты точки через запятую: ");
            Console.WriteLine(TriangPoint(1, 2, 5, 4, 3, 6, 3, 2, 4));
            Console.WriteLine();

            // ЗАДАЧА 2 (PS1 Ч.2. #3)
            Console.WriteLine($"ЗАДАЧА 2 (PS1 Ч.2. #3) Ответ: {SumArifmProgr(2, 7, 15)}");
            Console.WriteLine();

            // ЗАДАЧА 3 (PS1 Ч.3. #14)
            Console.WriteLine("ЗАДАЧА 3 (PS1 Ч.3. #14)");
            Console.WriteLine("Начните вводить любые числа:");
            int cntMax = 0, cntStr = 0;
            int numUser = 1;
            while (numUser != 0)
            {
                numUser = int.Parse(Console.ReadLine());
                if (numUser % 2 == 0 & numUser != 0)
                {
                    cntStr += 1;
                    if (cntMax < cntStr)
                    {
                        cntMax = cntStr;
                    }
                } 
                else
                {
                    cntStr = 0;
                }
            }
            Console.WriteLine($"Максимальная длина чётных чисел: {cntMax}");

            // ЗАДАЧА 4 (PS1 Ч.4. #5)
            int sumDel = 0, cnt = 0;
            for (int i = 1; i < 1000000; i++)
            {
                int num = i;
                int lenN = 0;
                for (int j = 1; j < Roof(i); j++)
                {
                    if (num % j == 0)
                    {
                        lenN += j;
                        if ((num / j) != i)
                        {
                            lenN += (num / j);
                        }
                    }
                }
                if (lenN == num)
                {
                    cnt += 1;
                }
                int EvklidExellent = TwoToStepen(8 - 1) * (TwoToStepen(8) - 1);
                if (i > EvklidExellent)
                {
                    break;
                }
            }
            Console.WriteLine(cnt);
        }


        static double TriangPoint(double ax, double ay, double bx, double by, double mx, double my, double lenA, double lenB, double lenC)
        {
            var lenBetweenCentres1 = Roof((bx - ax) * (bx - ax) + (by - ay) * (by - ay));

            var dx1 = (lenA * lenA - lenB * lenB + lenBetweenCentres1) / (2 * lenBetweenCentres1);
            var dyMinus1 = -Roof(lenA * lenA - dx1 * dx1);
            var dyPlus = Roof(lenA * lenA - dx1 * dx1);

            var tX11 = (ax + dx1);
            var tY11 = (ay + dyMinus1);

            var tX21 = (ax + dx1);
            var tY21 = (ay + dyPlus);


            var lenBetweenCentres2 = Roof((mx - bx) * (mx - bx) + (my - by) * (my - by));

            var dx2 = (lenB * lenB - lenC * lenC + lenBetweenCentres2) / (2 * lenBetweenCentres2);
            var dyMinus2 = -Roof(lenB * lenB - dx2 * dx2);
            var dyPlus2 = Roof(lenC * lenC - dx2 * dx2);

            var tX12 = (bx + dx2);
            var tY12 = (by + dyMinus2);

            var tX22 = (bx + dx2);
            var tY22 = (by + dyPlus2);

            var lenBetweenCentres3 = Roof((ax - mx) * (ax - mx) + (ay - my) * (ay - my));

            var dx3 = (lenA * lenA - lenC * lenC + lenBetweenCentres3) / (2 * lenBetweenCentres3);
            var dyMinus3 = -Roof(lenA * lenA - dx3 * dx3);
            var dyPlus3 = Roof(lenC * lenC - dx3 * dx3);

            var tX13 = (bx + dx3);
            var tY13 = (by + dyMinus3);

            var tX23 = (bx + dx3);
            var tY23 = (by + dyPlus3);

            double[,] points = { { tX11, tY11 }, { tX21, tY21 }, { tX12, tY12 }, { tX22, tY22 }, { tX13, tY13 }, { tX23, tY23 } };
            
            for (int i = 0; i < points.Length - 1; i++)
            {

                for (int j = 0; j < points.Length - 1; j++)
                {
                    if (points[1, i] == points[1, j])
                    {
                        return points[1, i];
                        break;
                    }
                }
            }
            return points[1, 5];
        }

    }
}