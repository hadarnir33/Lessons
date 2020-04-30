using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lessons;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> S = generateStackByInput();
            Console.WriteLine(S.ToString());
        }

        // This function creates a stack according to the user inputs
        public static Stack<int> generateStackByInput()
        {
            Stack<int> S = new Stack<int>();
            string input;
            Console.WriteLine("Enter numbers for the stack, enter end to finish");
            input = Console.ReadLine();
            while(input != "end")
            {
                S.Push(int.Parse(input));
                input = Console.ReadLine();
            }
            return S;
        }
    }
}
