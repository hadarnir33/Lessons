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
            Console.WriteLine(lastAndRemove(S)); 
        }

        // This function creates a stack according to the user inputs
        public static Stack<int> generateStackByInput()
        {
            Stack<int> S = new Stack<int>();
            string input;
            Console.WriteLine("Enter numbers for the stack, enter -1 to finish");
            input = Console.ReadLine();
            while(input != "-1")
            {
                S.Push(int.Parse(input));
                input = Console.ReadLine();
            }
            return S;
        }

        // Exam 2018: 4.a, this function returns the number in the bottom of the stack.
        public static int lastAndRemove(Stack<int> S)
        {
            int bottomOfStack = 0;
            while (!S.IsEmpty())
            {
                bottomOfStack = S.Pop();
            }
            return bottomOfStack;
        }
    }
}
