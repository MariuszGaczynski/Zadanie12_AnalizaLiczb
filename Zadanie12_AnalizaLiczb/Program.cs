using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie12_AnalizaLiczb
{
    class Program
    {
        static void Main(string[] args)
        {
            Graphic1();

            string givenStringOfNumbers;
            bool isStringCorrect = true;
            double[] arrayOfDoubleNumbers;
            do
            {

                Console.WriteLine(" Pass some integer numbers.\n" +
                    " Divide them by coma.\n" +
                    " When you finished press enter to proceed :");
                Console.Write("\n  Your numbers : ... ");

                givenStringOfNumbers = Console.ReadLine();

                arrayOfDoubleNumbers = OperationOnArray.CreateArray(givenStringOfNumbers);

                if (arrayOfDoubleNumbers[0] == 0.00012345678)
                {
                    Console.WriteLine("Let's do it one more time. Concentrate !");
                    isStringCorrect = false;
                }
                else
                {
                    isStringCorrect = true;
                }

            } while (isStringCorrect == false);


            bool anotherAnalysis = true;
            do
            {

                Console.WriteLine("\n\tWhat you want to analize ?\n");

                Console.WriteLine("    get a maximum value among given numbers  :   press '1'");
                Console.WriteLine("    get a minimum value among given numbers  :   press '2'");
                Console.WriteLine("            get an average of given numbers  :   press '3'");
                Console.WriteLine("        get a median value of given numbers  :   press '4'");
                Console.WriteLine("  get a standard deviation of given numbers  :   press '5'");
                Console.Write("\n\tYour choice ...");

                bool choosingAnalysis = true;
                do
                {
                    string answer1WhatToAnalize = Console.ReadLine();

                    switch (answer1WhatToAnalize)
                    {
                        case "1":
                            {
                                Graphic2();
                                Console.WriteLine("\nMaximum value among given numbers is {0}.",
                                OperationOnArray.GetMax(arrayOfDoubleNumbers));
                                Graphic2();
                                break;
                            }
                        case "2":
                            {
                                Graphic2();
                                Console.WriteLine("\nMinimum value among given numbers is {0}.",
                                OperationOnArray.GetMin(arrayOfDoubleNumbers));
                                Graphic2();
                                break;
                            }
                        case "3":
                            {
                                Graphic2();
                                Console.WriteLine("\nAn Average of given numbers is {0}.",
                                OperationOnArray.GetAverage(arrayOfDoubleNumbers));
                                Graphic2();
                                break;
                            }
                        case "4":
                            {
                                Graphic2();
                                Console.WriteLine("\nMedian value of given numbers is {0}.",
                                OperationOnArray.GetMedian(arrayOfDoubleNumbers));
                                Graphic2();
                                break;
                            }
                        case "5":
                            {
                                Graphic2();
                                Console.WriteLine("\nStandard deviation of given numbers is {0}.",
                                OperationOnArray.GetStandardDeviation(arrayOfDoubleNumbers));
                                Graphic2();
                                break;
                            }
                        default:
                            Console.WriteLine("\nChoose between possible functions.");
                            choosingAnalysis = false;
                            break;
                    }

                } while (choosingAnalysis == false);

               
                Console.Write("\n Do you want to perform another analyze ? (Y)es or (N)o ? ...");

                bool doingRestart = true;
                do
                {
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "y")
                    {
                        anotherAnalysis = true;
                    }
                    else if (answer == "n")
                    {
                        anotherAnalysis = false;
                    }
                    else
                    {
                        Console.Write("Another analysis ? (Y)es or(N)o ? ...");
                    }
                } while (doingRestart == false);

            }  while (anotherAnalysis == true);

            Console.WriteLine();
            Console.WriteLine();
            Graphic3();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\t Thank you for your studies. Hope you found some answers     ;)      ");
            Graphic3();
            Console.WriteLine();


            Console.ReadLine();
        }

        // 3 metody graficzne żeby coś sie działo ;) 
        public static void Graphic1()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
            Console.WriteLine("HHHHHHHHHHHHHHHHH                                         HHHHHHHHHHHHHHHHHHH");
            Console.WriteLine("HHHHHHHHHHHHHHHHH   Integer Numbers Sequence Analyzer     HHHHHHHHHHHHHHHHHHH");
            Console.WriteLine("HHHHHHHHHHHHHHHHH                                         HHHHHHHHHHHHHHHHHHH");
            Console.WriteLine("HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
            Console.WriteLine("HHHHHHHH  MIN  /  MAX  /  AVERAGE  /  MEDIAN  /  STANDARD DEVIATION  HHHHHHHH");
            Console.WriteLine("HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH\n\n");
            Console.ResetColor();

        }

        public static void Graphic2()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n-----------------------------------------------------------------------------");
            Console.ResetColor();
        }

        public static void Graphic3()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH");
            Console.ResetColor();
        }


    }

    public class OperationOnArray
    {
        // metoda na utowrzenie arraya

        public static double[] CreateArray(string givenStringOfNumbers)    //tworzenie tablicy z podanego stringa
        {
            string[] stringOfGivenNumbers = givenStringOfNumbers.Trim().Split(','); // pocięcie stringa po przecinakch
            double[] doubleOfGivenNumbers = new double[stringOfGivenNumbers.Length];  // inicjajca tablicy z wartościami int

            int i = 0;

            foreach (string stringNumber in stringOfGivenNumbers)
            {
                bool isParsable = Double.TryParse(stringNumber, out double givenNumber);
                if (isParsable && givenNumber <= 10000000000 && givenNumber >= -10000000000)
                {
                    doubleOfGivenNumbers[i] = givenNumber;
                    i++;
                }
                else if (isParsable && givenNumber > 1000000000 || givenNumber < -1000000000)
                {
                    Console.WriteLine("Don't go so far ! Pass a value between one billion and minus one billion." +
                        "You must try again.");

                    doubleOfGivenNumbers.SetValue(0.00012345678, 0); // nie umiałem inaczej warunku ustawić żebym potem widział że coś poszło nie tak ;(
                    break;     // więc ta jedna liczba może rozwalić działanie aplikacji ;( (jak ją ktoś wpisze jako pierwszą oczywiście)
                               // jakieś nadanie statusu empty czy coś takiego byłoby dobre pewnie (null jako warttość pola nie działał)
                }
                else
                {
                    Console.WriteLine("Some values are not recognizable. Try again.");
                    double[] newEmptyDouble = new double[stringOfGivenNumbers.Length];
                    doubleOfGivenNumbers = newEmptyDouble;

                    doubleOfGivenNumbers.SetValue(0.00012345678, 0); // ten sam warunek co wyżej
                    break;
                }

            }

            return doubleOfGivenNumbers;
        }
        // metody do obliczeń różnorakich
        public static double GetMax(double[] arrayOfDoubleNumbers)
        {

            double newMax = -1000000000;

            foreach (double number in arrayOfDoubleNumbers)
            {
                if (number > newMax)
                {
                    newMax = number;
                }

            }

            return newMax;
        }

        public static double GetMin(double[] arrayOfDoubleNumbers)
        {

            double newMin = 1000000000;

            foreach (double number in arrayOfDoubleNumbers)
            {
                if (number < newMin)
                {
                    newMin = number;
                }

            }

            return newMin;
        }


        public static double GetAverage(double[] arrayOfDoubleNumbers)
        {

            double sum = 0;

            foreach (double number in arrayOfDoubleNumbers)
            {
                sum += number;
            }

            return sum / arrayOfDoubleNumbers.Length;
        }


        public static double GetMedian(double[] arrayOfDoubleNumbers)
        {
            double[] sortedArrayOfDoubleNumbers = new double[arrayOfDoubleNumbers.Length];
            arrayOfDoubleNumbers.CopyTo(sortedArrayOfDoubleNumbers, 0);

            Array.Sort(sortedArrayOfDoubleNumbers);


            int medianIndex, medianIndex1, medianIndex2;
            double value;

            if (arrayOfDoubleNumbers.Length % 2 == 0)
            {
                medianIndex1 = arrayOfDoubleNumbers.Length / 2;
                medianIndex2 = (arrayOfDoubleNumbers.Length / 2) + 1;

                value = (arrayOfDoubleNumbers[medianIndex1] + arrayOfDoubleNumbers[medianIndex2]) / 2;
            }
            else
            {
                medianIndex = (arrayOfDoubleNumbers.Length + 1) / 2;

                value = arrayOfDoubleNumbers[medianIndex-1];
            }

            return value;
        }

        public static double GetStandardDeviation(double[] arrayOfDoubleNumbers)
        {
            double sigma;
            double calc1 = 0;
            double calc2;
            double average = GetAverage(arrayOfDoubleNumbers);

            foreach (double number in arrayOfDoubleNumbers)
            {
                calc1 += (number - average) * (number - average);
            }

            calc2 = calc1 / arrayOfDoubleNumbers.Length;

            sigma = Math.Sqrt(calc2);

            return sigma;
        }


    }
}
