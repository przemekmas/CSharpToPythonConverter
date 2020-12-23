using CSharpToPythonConverter.Processor;
using System;

namespace CSharpToPythonConverter
{
    public class Program
    {
        static void Main(string[] args)
        {
            var csharpCode = @"
public class Test
{
    public void TestMethod()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(i);

            for (int x = 0; x < 2; x++)
            {
                Console.WriteLine(x);
            }
        }
        
        CallMePlease(""Method CalMePlease called"");
    }

    public void CallMePlease(string parameter)
    {
        Console.WriteLine(parameter);
        
        if (10 > 1 && 20 > 10)
        {
            Console.WriteLine(""10 is higher than 1"");
        }
        else if (5 > 10)
        {
            Console.WriteLine(""5 is not higher than 10"");
        }
        else
        {
            Console.WriteLine(""Test"");
        }
    }

    public void WhileLoopTestMethod()
    {
        while (true)
        {
            Console.WriteLine(""while loop"");
        }
    }

    public void DecrementLoopMethod()
    {
        for (int i = 10; i > 0; i--)
        {
            Console.WriteLine(i);
        }
        
        CallMePlease(""Method CalMePlease called"");
    }
}

public class Test1
{
    public void Test()
    {
        var obj = new Test();
    }
}
";

            csharpCode = @"
string propPrzemek = ""Hello"";
Console.WriteLine(propPrzemek);

long sad = 2323.0000000;
Console.WriteLine(sad);

private static int _subGridSize = 3;

var localList = new List<int>() { 1, 2, 3 };
var localList = new List<string>() { ""Hello"", ""Przemek""};

foreach (var item in localList)
{
    Console.WriteLine(item);
}
var currentRowIndex = 0;
var currentColIndex = 0;

if (5 > 2)
{
    Console.WriteLine(""Five is greater than two!"");
}

var x = 5;
//var y = ""Hello, World"";
// Comment

/*
string test = ""test"", lol = ""lol"";
Console.WriteLine(test);
Console.WriteLine(lol);
*/

var variable = ""gr8"";
Console.WriteLine(""Python is "" + variable);

var xx = 5;
var dd = 10;
var xd = xx + dd;

Console.WriteLine(xd);

int input = 10;
int first = 0
int second = 1;
int third = 0;

for (int i = 3; i <= input; i++)
{
    third = first + second;
    Console.Write(""{ 0}"", third);
    first = second;
    second = third;
}

";

            int input = 10, first = 0, second = 1, third = 0;

            for (int i = 3; i <= input; i++)
            {
                third = first + second;
                Console.Write("{0} ", third);
                first = second;
                second = third;
            }

            CSharpCodeReadOperations.Read(csharpCode);
            
            Console.ReadKey();
        }
    }
}
