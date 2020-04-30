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
            Stack<int> s = generateStackByInput();
            Console.WriteLine(s);      
            Stack<TwoItems> stkTwoItems= stackTwoItems(s);
            Console.WriteLine(stkTwoItems);
        }

        // This function creates a stack according to the user inputs
        public static Stack<int> generateStackByInput()
        {
            Stack<int> s = new Stack<int>();
            string input;
            Console.WriteLine("Enter numbers for the stack, enter -1 to finish");
            input = Console.ReadLine();
            while(input != "-1")
            {
                s.Push(int.Parse(input));
                input = Console.ReadLine();
            }
            return s;
        }

        // Exam 2018: 4.a, this function returns the number in the bottom of the stack and remove it from the stack.
        public static int lastAndRemove(Stack<int> s)
        {
            Stack<int> temp = new Stack<int>();
            int bottomOfStack = 0;
            while (!s.IsEmpty())
            {
                bottomOfStack = s.Pop();
                if (!s.IsEmpty())
                    temp.Push(bottomOfStack);
            }
            while (!temp.IsEmpty())
                s.Push(temp.Pop());
            return bottomOfStack;
        }

        // Exam 2018: 4.b, this function creates a TwoItems stack from a given stack with even length.
        public static Stack<TwoItems> stackTwoItems(Stack<int> stk1)
        {
            Stack < TwoItems > stkTwoItems= new Stack<TwoItems>();
            TwoItems item;
            int firstNumber, secondNumber;
            while (!stk1.IsEmpty())
            {
                firstNumber = stk1.Pop();
                secondNumber = lastAndRemove(stk1);
                item = new TwoItems(firstNumber, secondNumber);
                stkTwoItems.Push(item);
            }
            return stkTwoItems;
        }
    }
}
