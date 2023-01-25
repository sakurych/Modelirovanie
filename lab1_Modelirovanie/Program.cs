using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.Threading.Tasks;
using static lab1_Modelirovanie.Methods;
using static lab1_Modelirovanie.Tests;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace lab1_Modelirovanie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestSerial();
            TestFrequency();
            IntervalTest();
            PokerTest();
        }

        static void TestSerial()
        {
            var regular = new Methods(); // Встроеный метод
            var SerialRegular1 = new Tests();
            List<int> regMethod = new List<int>(1000);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var p = new ExcelPackage(new FileInfo(@"C:\workbooks\Sasha.xlsx")))
            {
                var sh = p.Workbook.Worksheets["TestSerial"];
                for (int j = 1; j < 31; j++)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        regMethod.Add(regular.standartMethod());
                    }
                    for (int k = 0; k < 1000; k++)
                    {
                        if (regMethod[k] < 2147483649 / 2)
                        {
                            regMethod[k] = 0;
                        }
                        else
                        {
                            regMethod[k] = 1;
                        }
                    }
                    double val = SerialRegular1.Serial(regMethod);
                    regMethod.Clear();
                    sh.Cells["A" + j].Value = val;
                }
                p.Save();
            }


            var vichetov = new Methods(); // Метод вычетов
            List<int> listVichetov = new List<int>();
            var SerialVichetov1 = new Tests();
            using (var p = new ExcelPackage(new FileInfo(@"C:\workbooks\Sasha.xlsx")))
            {
                var sh = p.Workbook.Worksheets["TestSerial"];
                for (int j = 1; j < 31; j++)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        listVichetov.Add(vichetov.RandomMultiCompar());
                        Console.Write(listVichetov[i] + "  ");
                    }
                    for (int k = 0; k < 1000; k++)
                    {
                        if (listVichetov[k] < 2147483647 / 2)
                        {
                            listVichetov[k] = 0;
                        }
                        else
                        {
                            listVichetov[k] = 1;
                        }
                    }
                    double val = SerialVichetov1.Serial(listVichetov);
                    sh.Cells["C" + j].Value = val;
                    listVichetov.Clear();
                }
                p.Save();
            }

            var crypto = new Methods(); // Метод серединных квадратов
            List<int> listCrypto = new List<int>();
            var SerialCubes = new Tests();
            using (var p = new ExcelPackage(new FileInfo(@"C:\workbooks\Sasha.xlsx")))
            {
                int val = 0;
                var sh = p.Workbook.Worksheets["TestSerial"];
                for (int j = 1; j < 31; j++)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        val = Math.Abs(crypto.CryptoRNG());
                        if (val < (2147483647 / 2))
                        {
                            listCrypto.Add(0);
                        }
                        if (val > (2147483647 / 2))
                        {
                            listCrypto.Add(1);
                        }
                    }
                    double cal = SerialCubes.Serial(listCrypto);
                    sh.Cells["E" + j].Value = cal;
                    listCrypto.Clear();
                }
                p.Save();
            }
        }

        static void TestFrequency()
        {
            var regular = new Methods(); // Встроеный метод
            var FrequencyRegular1 = new Tests();
            List<int> regMethod = new List<int>(1000);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var p = new ExcelPackage(new FileInfo(@"C:\workbooks\Sasha.xlsx")))
            {
                int val = 0;
                var sh = p.Workbook.Worksheets["FrequencyTest"];
                for (int j = 1; j < 31; j++)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        regMethod.Add(regular.standartMethod() % 10);
                    }
                    double cal = FrequencyRegular1.FrequencyTest(regMethod);
                    sh.Cells["A" + j].Value = cal;
                    regMethod.Clear();
                }
                p.Save();
            }

            var vichetov = new Methods(); // Метод вычетов
            List<int> listVichetov = new List<int>();
            var FrequencyVichetov1 = new Tests();
            using (var p = new ExcelPackage(new FileInfo(@"C:\workbooks\Sasha.xlsx")))
            {
                var sh = p.Workbook.Worksheets["FrequencyTest"];
                for (int j = 1; j < 31; j++)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        listVichetov.Add(vichetov.RandomMultiCompar() % 10);
                    }
                    double val = FrequencyVichetov1.FrequencyTest(listVichetov);
                    sh.Cells["C" + j].Value = val;
                    listVichetov.Clear();
                }
                p.Save();
            }

            var crypto = new Methods(); // Метод crypyoRNG
            List<int> listCrypto = new List<int>();
            var FrequencyCubes = new Tests();
            using (var p = new ExcelPackage(new FileInfo(@"C:\workbooks\Sasha.xlsx")))
            {
                int val = 0;
                var sh = p.Workbook.Worksheets["FrequencyTest"];
                for (int j = 1; j < 31; j++)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        listCrypto.Add(Math.Abs(crypto.CryptoRNG()) % 10);
                    }
                    double cal = FrequencyCubes.FrequencyTest(listCrypto);
                    sh.Cells["E" + j].Value = cal;
                    listCrypto.Clear();
                }
                p.Save();
            }
        }

        static void IntervalTest()
        {
            var regular = new Methods(); // Встроеный метод
            var IntervalRegular1 = new Tests();
            List<int> listReg = new List<int>(1000);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var p = new ExcelPackage(new FileInfo(@"C:\workbooks\Sasha.xlsx")))
            {
                int val = 0;
                var sh = p.Workbook.Worksheets["IntervalTest"];
                for (int j = 1; j < 31; j++)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        listReg.Add(regular.standartMethod() % 10);
                    }
                    double cal = IntervalRegular1.IntervalTest(listReg);
                    sh.Cells["A" + j].Value = cal;
                    listReg.Clear();
                }
                p.Save();
            }

            var vichetov = new Methods(); // Метод вычетов
            List<int> listVichetov = new List<int>();
            var IntervalVichetov1 = new Tests();
            using (var p = new ExcelPackage(new FileInfo(@"C:\workbooks\Sasha.xlsx")))
            {
                var sh = p.Workbook.Worksheets["IntervalTest"];
                for (int j = 1; j < 31; j++)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        listVichetov.Add(vichetov.RandomMultiCompar() % 10);
                    }
                    double val = IntervalVichetov1.IntervalTest(listVichetov);
                    sh.Cells["C" + j].Value = val;
                    listVichetov.Clear();
                }
                p.Save();
            }


            var crypto = new Methods(); // Метод crypyoRNG
            List<int> listCrypto = new List<int>();
            var IntervalCrypto = new Tests();
            using (var p = new ExcelPackage(new FileInfo(@"C:\workbooks\Sasha.xlsx")))
            {
                int val = 0;
                var sh = p.Workbook.Worksheets["IntervalTest"];
                for (int j = 1; j < 31; j++)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        val = Math.Abs(crypto.CryptoRNG());
                        listCrypto.Add(val % 10);
                    }
                    double cal = IntervalCrypto.IntervalTest(listCrypto);
                    sh.Cells["E" + j].Value = cal;
                    listCrypto.Clear();
                }
                p.Save();
            }
        }

        static void PokerTest()
        {
            var regular = new Methods(); // Встроеный метод
            var PokerRegular1 = new Tests();
            List<int> listReg = new List<int>(1000);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var p = new ExcelPackage(new FileInfo(@"C:\workbooks\Sasha.xlsx")))
            {
                int val = 0;
                var sh = p.Workbook.Worksheets["PokerTest"];
                for (int j = 1; j < 31; j++)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        listReg.Add(regular.standartMethod() % 100);
                    }
                    double cal = PokerRegular1.PokerTest(listReg);
                    sh.Cells["A" + j].Value = cal;
                    listReg.Clear();
                }
                p.Save();
            }

            var vichetov = new Methods(); // Метод вычетов
            List<int> listVichetov = new List<int>();
            var PokerVichetov1 = new Tests();
            using (var p = new ExcelPackage(new FileInfo(@"C:\workbooks\Sasha.xlsx")))
            {
                var sh = p.Workbook.Worksheets["PokerTest"];
                for (int j = 1; j < 31; j++)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        listVichetov.Add(vichetov.RandomMultiCompar() % 100);
                    }
                    double val = PokerVichetov1.PokerTest(listVichetov);
                    sh.Cells["C" + j].Value = val;
                    listVichetov.Clear();
                }
                p.Save();
            }

            var crypto = new Methods(); // Метод crypyoRNG
            List<int> listCrypto = new List<int>();
            var PokerCrypto = new Tests();
            using (var p = new ExcelPackage(new FileInfo(@"C:\workbooks\Sasha.xlsx")))
            {
                int val = 0;
                var sh = p.Workbook.Worksheets["PokerTest"];
                for (int j = 1; j < 31; j++)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        listCrypto.Add(crypto.CryptoRNG() % 100);
                    }
                    double cal = PokerCrypto.PokerTest(listCrypto);
                    sh.Cells["E" + j].Value = cal;
                    listCrypto.Clear();
                }
                p.Save();
            }
        }
    }
}
