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
            //Stack<int> s = GenerateStackByInput();
            //Console.WriteLine(s);
            //DuplicatesItems(s);
            //Console.WriteLine(s);
            string str = "1234567";
            Console.WriteLine(str.Substring(1, str.Length - 2)); 
        }

        public static int Percent(int a, int b)
        {
            if (a < b)
                return a;
            else
                return Percent(a - b, b);
        }


        // This function creates a stack according to the user inputs.
        public static Stack<int> GenerateStackByInput()
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
        public static int LastAndRemove(Stack<int> s)
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
        public static Stack<TwoItems> StackTwoItems(Stack<int> stk1)
        {
            Stack < TwoItems > stkTwoItems= new Stack<TwoItems>();
            TwoItems item;
            int firstNumber, secondNumber;
            while (!stk1.IsEmpty())
            {
                firstNumber = stk1.Pop();
                secondNumber = LastAndRemove(stk1);
                item = new TwoItems(firstNumber, secondNumber);
                stkTwoItems.Push(item);
            }
            return stkTwoItems;
        }

        // Exam 2008: 4.a, this function duplicates an item in the stack if it is a changing direction item.
        public static void DuplicatesItems(Stack<int> stk1)
        {
            Stack<int> tempStk = new Stack<int>();
            int bottom, middle, top;
            bottom = stk1.Pop();
            tempStk.Push(bottom);
            middle = stk1.Pop();
            tempStk.Push(middle);
            while (!stk1.IsEmpty())
            {
                top = stk1.Pop();
                if (middle > bottom && middle > top || middle < bottom && middle < top)
                    tempStk.Push(middle);
                tempStk.Push(top);
                bottom = middle;
                middle = top;
            }
            while (!tempStk.IsEmpty())
                stk1.Push(tempStk.Pop());
        }
    }
}
