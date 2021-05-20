using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {

    // List 1-2
    class Program {
        static void Main(string[] args) {
            // 同じように使える

            MyClass myClass = new MyClass { X = 1, Y = 2 };

            MyStruct myStruct = new MyStruct { X = 1, Y = 2 };

            PrintObjects(myClass, myStruct);

            // 違う結果
            Console.WriteLine("{0}: X={1} Y={2}", myClass, myClass.X, myClass.Y);
            Console.WriteLine("{0}: X={1} Y={2}", myStruct, myStruct.X, myStruct.Y);
            Console.ReadKey();

        }

        static void PrintObjects(MyClass myClass, MyStruct myStruct)
        {
            myClass.X *= 2;
            myClass.Y *= 2;
            myStruct.X *= 2;
            myStruct.Y *= 2;

            // 同じ結果
            Console.WriteLine("{0}: X={1} Y={2}", myClass, myClass.X, myClass.Y);
            Console.WriteLine("{0}: X={1} Y={2}", myStruct, myStruct.X, myStruct.Y);
        }


    }


    // クラス
    class MyClass {
        public int X { get; set; }
        public int Y { get; set; }
    }

    // 構造体
    struct MyStruct {
        public int X { get; set; }
        public int Y { get; set; }
    }



}
