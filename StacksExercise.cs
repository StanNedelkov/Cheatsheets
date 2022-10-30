using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCoteTests
{

    public class StacksExercise
    {
        private static string[] ReadLine() 
            => Console.ReadLine()!
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        public void StackAddRemove()
        {
            string[] line1 = ReadLine();

            Stack<int> stack = new Stack<int>();
            foreach (var number in line1)
            {
                stack.Push(int.Parse(number));
            }

            string[] commands = ReadLine();

            while (commands[0].ToLower() != "end")
            {
                string command = commands[0].ToLower();
                int firstNumber = int.Parse(commands[1]);

                if (command == "add")
                {
                    stack.Push(firstNumber);
                    stack.Push(int.Parse(commands[2]));
                }

                else if (command == "remove" &&
                    stack.Count >= firstNumber)
                {
                    for (int i = 0; i < firstNumber; i++)
                    {
                        stack.Pop();
                    }
                }
                commands = ReadLine();
            }
            Console.WriteLine("Sum: " + stack.Sum());
        }
    }

}
