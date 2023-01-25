using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_Modelirovanie
{
    internal class Tests
    {
        public double FrequencyTest(List<int> gen_nums)
        {
            int[] nums = new int[10];
            for (int i=0; i<nums.Length; i++)
            {
                nums[i] = 0;
            }
            double v = 0;
            for(int i = 0; i<gen_nums.Count; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if (gen_nums[i] == j)
                    {
                        nums[j]++;
                    }
                }
            }

            for (int j = 0; j < nums.Length; j++)
            {
                v += Math.Pow(nums[j] - 1000 * 0.1, 2) / (1000 * 0.1);
            }
            Console.WriteLine(v);
            return v;
        }

        public double Serial(List<int> gen_nums)
        {
            int[] nums = new int[4];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
            string str1 = "00";
            string str2 = "01";
            string str3 = "10";
            string str4 = "11";

            for (int i = 0; i< gen_nums.Count; i = i + 2)
            { 
                string para = "" + gen_nums[i] + gen_nums[i+1];
                if ( para == str1)
                {
                    nums[0]++;
                }
                if (para == str2)
                {
                    nums[1]++;
                }
                if (para == str3)
                {
                    nums[2]++;
                }
                if (para == str4)
                {
                    nums[3]++;
                }
            }

            double sumV = 0;
            for(int j =0; j < nums.Length; j++) 
            {
                sumV+=Math.Pow(nums[j] - 500 * 0.25,2) / (500 * 0.25);
            }
            return sumV;
        }
        
        public double IntervalTest(List<int> gen_nums)
        {
            int count = 0;
            int ALPHA = 5;
            int BETA = 10;
            int[] mas = new int[7];
            for (int i = 0;i < gen_nums.Count;i++)
            {
                if (gen_nums[i] >= ALPHA && gen_nums[i] <= BETA)
                {
                    if(count > 6)
                    {
                        count = 6;
                    }
                    mas[count]++;
                    count = 0;
                }
                else
                {
                    count++;
                }
            }

            double p = 0.5;
            double Pr = 0;
            double sumOfVI = 0;
            double V = 0;
            double ns = (double)1000;
            for (int i = 0; i < 6 + 1; i++)
            {
                Pr = p * Math.Pow(1 - p, i);
                if (i == 6) Pr = Math.Pow(1 - p, i);
                Console.Write(Pr.ToString() + "         " + mas[i].ToString());
                V = Math.Pow((double)mas[i] * 2 - (1000 * Pr), 2) / (1000 * Pr);
                sumOfVI += V;
                Console.Write($"      V[{i}] - {V}\n");
            }
            Console.WriteLine(sumOfVI.ToString());
            return sumOfVI;
        }

        public double PokerTest(List<int> gen_nums)
        {
            int N = 1000;
            int[] pokerCounter = new int[5];
            for (int i = 0; i < N / 5; i++)
            {
                int[] pokerCounterU = new int[5];

                double[] tempU = new double[5];
                int q = 1;
                int step = 0;
                int sumOfpoker = 0;
                for (int ite = 0; ite < 5; ite++)
                {
                    tempU[ite] = gen_nums[5 * i + ite];
                    pokerCounterU[ite] = 1;
                }
                Array.Sort(tempU);

                for (int j = 1; j < 5; j++)
                {
                    if (tempU[j] == tempU[j - 1])
                    {
                        q++;
                        if (j == 4)
                            for (int k = step; k < step + q; k++) pokerCounterU[k] = q;
                    }
                    else
                    {
                        for (int k = step; k < step + q; k++) pokerCounterU[k] = q;
                        step += q;
                        q = 1;
                    }
                }
                for (int k = 0; k < 5; k++) sumOfpoker += pokerCounterU[k];
                switch (sumOfpoker)
                {
                    case 5:
                        pokerCounter[0]++; break;
                    case 7:
                        pokerCounter[1]++; break;
                    case 9:
                        pokerCounter[2]++; break;
                    case 11:
                        pokerCounter[2]++; break;
                    case 13:
                        pokerCounter[3]++; break;
                    case 17:
                        pokerCounter[3]++; break;
                    case 25:
                        pokerCounter[4]++; break;
                    default:
                        Console.WriteLine(sumOfpoker.ToString());
                        break;
                }
            }
            Console.WriteLine();
            //for (int k = 0; k < 5; k++) Console.Write(pokerCounter[k].ToString() + " ");
            Console.WriteLine("Теоретическая вероятность в Покер-тесте:");
            double P1 = (99) * (98) * (97) * (96) / Math.Pow(100, 4);
            double P2 = (99) * (98) * (97) * 10 / Math.Pow(100, 4);
            double P3 = (99) * (98) * 15 / Math.Pow(100, 4) + (99) * (98) * 10 / Math.Pow(100, 4); ;
            double P4 = (99) * 10 / Math.Pow(100, 4) + (99) * 5 / Math.Pow(100, 4);
            double P5 = 1 / Math.Pow(100, 4);
            Console.WriteLine("{0,-6}", "Значение 1: " + P1);
            Console.WriteLine("{0,-6}", "Значение 2: " + P2);
            Console.WriteLine("{0,-6}", "Значение 3: " + P3);
            Console.WriteLine("{0,-6}", "Значение 4: " + P4);
            Console.WriteLine("{0,-6}", "Значение 5: " + P5);
            Console.WriteLine("\nКол-во полученных значений: ");
            Console.WriteLine("{0,-6}", "Значение 1: " + pokerCounter[0]);
            Console.WriteLine("{0,-6}", "Значение 2: " + pokerCounter[1]);
            Console.WriteLine("{0,-6}", "Значение 3: " + pokerCounter[2]);
            Console.WriteLine("{0,-6}", "Значение 4: " + pokerCounter[3]);
            Console.WriteLine("{0,-6}", "Значение 5: " + pokerCounter[4]);
            double V1, V2, V3, V4, V5;
            double sumOfVI = 0;
            V1 = Math.Pow(pokerCounter[0] - (N / 5 * P1), 2) / (N / 5 * P1);
            sumOfVI += V1;
            V2 = Math.Pow(pokerCounter[1] - (N / 5 * P2), 2) / (N / 5 * P2);
            sumOfVI += V2;
            V3 = Math.Pow(pokerCounter[2] - (N / 5 * P3), 2) / (N / 5 * P3);
            sumOfVI += V3;
            V4 = Math.Pow(pokerCounter[3] - (N / 5 * P4), 2) / (N / 5 * P4);
            sumOfVI += V4;
            V5 = Math.Pow(pokerCounter[4] - (N / 5 * P5), 2) / (N / 5 * P5);
            sumOfVI += V5;
            Console.WriteLine("\nV  -  " + sumOfVI);
            return sumOfVI;
        }
    }
}
