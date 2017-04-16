using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomAttribute1
{
    class Program
    {
        static void Main()
        {
            // Warning: 'Program.Test()' is obsolete
            Test();
            Test1();
            //Test2();//It will be error as true flag is passed as parameter in Attribute Defination
        }

        [Obsolete]
        static void Test()
        {
        }
        [Obsolete("This method is no longer Exits")]
        static void Test1()
        {
        }
        [Obsolete("This method is no longer Exits",true)]
        static void Test2()
        {
        }
    }
}
