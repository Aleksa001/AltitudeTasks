using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("Type arguments!");
                return;
            }
            string inputString = "";
            foreach(string arg in args)
            {
                if (arg.StartsWith("inputString"))
                {
                    inputString = arg.Split('=')[1];
                }
            }
            if (string.IsNullOrEmpty(inputString))
            {
                Console.WriteLine("Missing input parameter 'inputString'!");
                return;
            }

            Proccess(inputString);

            Console.ReadLine();
        }

        public static void Proccess(string input)
        {
            try
            {
                int[] numbers = Parse(input);
                numbers = numbers.Distinct().ToArray();
                Array.Sort(numbers);
                Array.ForEach(numbers, x => Console.Write(x + " "));
               
               

            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
          
        }

        public static int[] Parse(string input)
        {
            input = input.Replace("[", "").Replace("]", "").Replace(" ", "");
            string[] numberInString = input.Split(',');
            int[] numbers = new int[numberInString.Length];
            for(int i=0; i< numberInString.Length; i++)
            {
              
                numbers[i] = int.Parse(numberInString[i]);
            }
            return numbers;
        }
    }
}
