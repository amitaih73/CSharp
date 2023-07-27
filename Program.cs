using Process;
using System;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Process
{
    class Processor{
        public virtual string Name => this.GetType().Name;
        public virtual object Process(string a_str) 
        {
            return a_str; 
        }
    }

    class UpCase : Processor {
        public override object Process(string a_str) 
        {
            return a_str.ToUpper();
        }
    }

    class DownCase : Processor
    {
        public override string Process(string a_str)
        {
            return a_str.ToLower();
        }
    }

    class Spliters : Processor
    {
        public override string[] Process(string a_str)
        {
            return a_str.Split();
        }
    }

    class StringSwapper
    {
        public string Swap(string str)
        {
            char[] charStr = str.ToCharArray();
            int size = charStr.Length;
            for (int i = 0; i < size - 1; i += 2) {
                char temp = charStr[i];
                charStr[i] = charStr[i + 1];
                charStr[i + 1] = temp;
            }
            return new String(charStr);
        }
    }

    class StringSwaperAdapter :  Processor
    {
       private StringSwapper swapper;

        public StringSwaperAdapter()
        {
            swapper = new StringSwapper();
        }
        public override string Process(string a_str)
        {
            return swapper.Swap(a_str);
        }
    }
    class Series
    {
        public int SeriaRec(int a_element)
        {
            if (a_element == 1)
{
                return 5;
            }
            return SeriaRec(a_element - 1) + (2 * a_element * a_element);
        }

        public int GiveElement(int a_element)
        {
            return SeriaRec(a_element);
        }
    }

    class Series2
    {
        public double SeriaRec(int a_element)
        {
            if (a_element == 1)
            {
                return 0;
            }
            double res = SeriaRec(a_element - 1);
            return Math.Pow(res, 2) - res - 1;
        }

        public double GiveElement(int a_element)
        {
            return SeriaRec(a_element);
        }
    }

    class Factorial
    {
        public double SeriaRec(int a_element)
        {
            if (a_element == 0)
            {
                return 1;
            }

            if (a_element == 1)
            {
                return 1;
            }
            return a_element * SeriaRec(a_element - 1);
        }

        public double GiveElement(int a_element)
        {
            if(a_element < 0)
            {
                throw new Exception("Element must be a positive integer.");
            }
            return SeriaRec(a_element);
        }
    }

    class SumOfDigits
    {
        public double SeriaRec(int a_element)
        {
            if (a_element == 0)
            {
                return 0;
            }

            
            return a_element % 10 + SeriaRec(a_element / 10);
        }

        public double GiveElement(int a_element)
        {
            if (a_element < 0)
            {
                throw new Exception("Element must be a positive integer.");
            }
            return SeriaRec(a_element);
        }
    }

    class SumOfOddDigits
    {
        public double SeriaRec(int a_element)
        {
            if (a_element == 0)
            {
                return 0;
            }

            double resOfOdd = SeriaRec(a_element / 10); 
            if ((a_element % 10) % 2 != 0)
            {
                return resOfOdd + 1;
            }
            return resOfOdd;
        }

        public double GiveElement(int a_element)
        {
            if (a_element < 0)
            {
                throw new Exception("Element must be a positive integer.");
            }
            return SeriaRec(a_element);
        }
    }

    class SumOfItemsInArray
    {
        public int RestOfArrRec(int[] a_array)
        {
            if (a_array.Length == 1)
            {
                return a_array[0];
            }
            int[] tempaArr = new int[a_array.Length -1];
            Array.Copy(a_array, 1, tempaArr, 0, a_array.Length - 1);
            return a_array[0] + RestOfArrRec(tempaArr);
        }
    }

    class Divid
    {
        public int DividRec(int a_mone, int a_mehane)
        {
            if (a_mehane == 0) {
                throw new Exception("divid by zero");
            }
            if (a_mone <= 0) {
                return 0;
            }
            return 1 + DividRec(a_mone - a_mehane, a_mehane);
        }
    }

    class Palindrom {
        public bool IsPalindromRec(string a_str) 
        {
            int size = a_str.Length;
            if (size == 1 || size == 0) {
                return true;
            }
            if (size == 2)
            {
                if (a_str[0] == a_str[size - 1]) { 
                    return true;
                }
                return false;
            }
            if (a_str[0] == a_str[size - 1]) { 
                string temp = a_str.Substring(1, a_str.Length - 2);
                return IsPalindromRec(temp);
            }
            else
            {
                return false;
            }
        }
    }
    class Test
    {
        static void Process(Processor p, string s)
        {
            Console.WriteLine("Using Processor " + p.Name);
            Console.WriteLine(p.Process(s));
        }

        static void Main(string[] args)
        {
            Processor pro = new Processor();
            Process(pro, "Hello World");

            Processor upCasees = new UpCase();
            Process(upCasees, "Hello World");

            Processor downCasees = new DownCase();
            Process(downCasees, "Hello World");

            Processor spliter = new Spliters();
            Process(spliter, "Hello World");

            StringSwaperAdapter swaper = new StringSwaperAdapter();
            Console.WriteLine(swaper.Process("ahala"));

            Series ser = new Series();
            int res10 = ser.GiveElement(10);
            Console.WriteLine(res10);

            Series2 ser2 = new Series2();
            double resTow10 = ser2.GiveElement(10);
            Console.WriteLine(resTow10);

            Factorial factorial = new Factorial();
            double fact10 = 0;
            try
            {
                fact10 = factorial.GiveElement(5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine(fact10);
            }

            SumOfDigits digitSum = new SumOfDigits();
            double digSum = 0;
            try
            {
                digSum = digitSum.GiveElement(156);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine(digSum);
            }

            SumOfOddDigits odds = new SumOfOddDigits();
            double oddsDigits = odds.GiveElement(2587);
            Console.WriteLine(oddsDigits);

            SumOfItemsInArray items = new SumOfItemsInArray();
            int[] myArray = { 1, 2, 4, 6 };
            int sumItems = items.RestOfArrRec(myArray);
            Console.WriteLine(sumItems);

            Divid divider = new Divid();
            
            int resDivid = divider.DividRec(14, 2);
            Console.WriteLine(resDivid);

            Palindrom palindrom = new Palindrom();
            Console.WriteLine(palindrom.IsPalindromRec("aba"));
            Console.WriteLine(palindrom.IsPalindromRec("kd;sa;dk"));
        }
    }
}