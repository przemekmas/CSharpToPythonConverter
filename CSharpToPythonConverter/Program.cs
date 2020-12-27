using CSharpToPythonConverter.Processor;
using System;

namespace CSharpToPythonConverter
{
    public class Program
    {
        static void Main(string[] args)
        {
            var csharpCode = @"
            Console.WriteLine(""Hello World!"");
            Console.WriteLine(""I will print on a new line."");

            Console.Write(""Hello World! "");
            Console.Write(""I will print on the same line."");

            // This is a comment
            Console.WriteLine(""Hello World!"");

            string name = ""John"";
            Console.WriteLine(name);

            int myNum = 15;
            Console.WriteLine(myNum);

            myNum = 15;
            myNum = 20;
            Console.WriteLine(myNum);

            string firstName = ""John "";
            string lastName = ""Doe"";
            string fullName = firstName + lastName;
            Console.WriteLine(fullName);

            int x = 5;
            int y = 6;
            Console.WriteLine(x + y);

            x = 10;
            x += 5;

            x = 20;
            y = 18;
            if (x > y)
            {
                Console.WriteLine(""x is greater than y"");
            }

            int time = 22;
            if (time < 10)
            {
                Console.WriteLine(""Good morning."");
            }
            else if (time < 20)
            {
                Console.WriteLine(""Good day."");
            }
            else
            {
                Console.WriteLine(""Good evening."");
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
            }

            string[] cars = { ""Volvo"", ""BMW"", ""Ford"", ""Mazda"" };
            foreach (string i in cars)
            {
                Console.WriteLine(i);
            }";

            CSharpCodeReadOperations.Read(csharpCode);
            Console.ReadKey();
        }
    }
}
