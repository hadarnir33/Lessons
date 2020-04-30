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
            Console.WriteLine(S);
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

        // Exam 2018: 4.a, this function returns the number in the bottom of the stack and remove it from the stack.
        public static int lastAndRemove(Stack<int> S)
        {
            Stack<int> Temp = new Stack<int>();
            int bottomOfStack = 0;
            while (!S.IsEmpty())
            {
                bottomOfStack = S.Pop();
                if (!S.IsEmpty())
                    Temp.Push(bottomOfStack);
            }
            while (!Temp.IsEmpty())
                S.Push(Temp.Pop());
            return bottomOfStack;
        }
    }
}
