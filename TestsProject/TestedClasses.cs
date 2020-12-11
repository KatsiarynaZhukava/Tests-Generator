using System;
using System.Collections.Generic;
using System.Text;

namespace TestsProject
{
    class TestedClasses
    {
        public int i;
        public string name;

        public void SetName(string newName)
        {
            name = newName;
        }

        public int ReturnInt()
        {
            return i;
        }

        public void voidMethod()
        {
            return;
        }
        public void voidMethodWithArgs(int a, double c)
        {
            return;
        }

        public void PrintString()
        {
            Console.WriteLine("this is some string");
        }

        private bool BoolBool()
        {
            return false;
        }
    }
}
