using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
  class Program
  {
    static int Main(string[] args)
    {
      //string del = "\t->\t";
      string userInput = "";
      double numberTest = 0.0;

      CalculatorMenu();
      userInput = GetUserInput();
      while (userInput.ToLower() != "exit") 
      {

        List<string> userInputList;

        while(!validateUserInput(userInput))
        {
          userInput = GetUserInput();
        }

        userInputList = SplitUserInput(userInput);

        if (double.TryParse(userInputList[0], out numberTest))
        {
          AddingNumbersList(userInputList);
          userInput = GetUserInput();
        }
        else
        {
          var numbersList = userInputList.GetRange(1, userInputList.Count - 1).ToList(); ;
        switch (userInputList[0])
        {
          case "exit":
              return 0;

          case "*":
              MultiplyNumbersList(numbersList);
              userInput = GetUserInput();
              break;

          case "/":
              DividingNumbersList(numbersList);
              userInput = GetUserInput();
              break;

          case "+":
              AddingNumbersList(numbersList);
              userInput = GetUserInput();
              break;

          case "avg":
              AverageNumbersList(numbersList);
              userInput = GetUserInput();
              break;

            case "^2":
              AverageNumbersList(numbersList);
              userInput = GetUserInput();
              break;

            default:
              return 0;
              break;
        }

        }

      }




      return 0;
    }

    public static void AddingNumbersList(List<string> userNumberList)
    {
      double sum = 0.0;
      double tempNumber = 0.0;

      if (userNumberList.Count <= 1 ) 
      {
        double.TryParse(userNumberList[1], out sum);
      }
      else
      {
        foreach (var number1 in userNumberList)
        {
          if (double.TryParse(number1, out tempNumber))
          {
            sum += tempNumber;
          }
        }
      }
      PrintResult(sum);
    }

    public static void DividingNumbersList(List<string> userNumberList)
    {
      double sum = 1;
      double tempNumber = 0.0;

      if (userNumberList.Count <= 1)
      {
        double.TryParse(userNumberList[1], out sum);
      }
      else
      {
        for(int i = 0; i < userNumberList.Count; i++)
        {

          if (double.TryParse(userNumberList[i], out tempNumber))
          {
            if (i == 0)
            {
              sum = tempNumber;
            }
            else if (1 >= 0 )
            {
              sum /= tempNumber;
            }
          }
        }
      }
      PrintResult(sum);
    }

    public static void MultiplyNumbersList(List<string> userNumberList)
    {
      double product = 1;
      double tempNumber = 0.0;

      if (userNumberList.Count <= 1)
      {
        double.TryParse(userNumberList[1], out product);
      }
      else
      {
        foreach (var number1 in userNumberList)
        {
          if (double.TryParse(number1, out tempNumber))
          {
            product *= tempNumber;
          }
        }
      }
      PrintResult(product);
    }

    public static void PrintResult(double answer)
    {
      Console.WriteLine($"The answer is: {answer}");
    }

    public static void AverageNumbersList(List<string> userNumberList)
    {
      double sum = 0.0;
      double tempNumber = 0.0;

      if (userNumberList.Count <= 1)
      {
        double.TryParse(userNumberList[1], out sum);
      }
      else
      {
        foreach (var number1 in userNumberList)
        {
          if (double.TryParse(number1, out tempNumber))
          {
            sum += tempNumber;
          }
        }
      }
      PrintResult(sum / userNumberList.Count);
    }

    public static void SquareRootNumbersList(List<string> userNumberList)
    {
      double sum = 0.0;
      double tempNumber = 0.0;

      if (userNumberList.Count <= 1)
      {
        double.TryParse(userNumberList[1], out sum);
        Console.WriteLine(Math.Sqrt(sum));
      }
      else
      {
        foreach (var number1 in userNumberList)
        {
          if (double.TryParse(number1, out tempNumber))
          {
            Console.WriteLine($"{Math.Sqrt(tempNumber)}");
          }
        }
      }
    }

    public static List<string> SplitUserInput(string userString)
    {
      if (!String.IsNullOrWhiteSpace(userString))
      {
        var userItems = userString.Split(',', ' ').ToList();
        return userItems;
      }
      return null;
    }

    public static Boolean validateUserInput(string userString)
    {
      var validateString = userString.Split(',', ' ');
      var number = 0.0;

      if (double.TryParse(validateString[0], out number)) return true;
      while (validateString[0] != ""     &&
             validateString[0] != "*"    &&
             validateString[0] != "/"    &&
             validateString[0] != "+"    &&
             validateString[0] != "^2"   &&
             validateString[0] != "avg"  &&
             validateString[0] != "exit" 
             )
      {
        validateString = GetUserInput().Split(',', ' ');
      }
      return true;
    }

    public static string GetUserInput()
    {
      var userString = "";
      Console.WriteLine("Please enter a string to calculate or \"exit\" to exit the program ");
      userString = Console.ReadLine();
      return userString; 
    }


    public static void CalculatorMenu()
    {
      Console.WriteLine("Welcome to Calculator");
      Console.WriteLine("String and Number Manipulation");
      Console.WriteLine("Multiplication");
      Console.WriteLine("Create a console application that, given a comma separated list of");
      Console.WriteLine("strings, prints the result of multiplying the values together.");
      Console.WriteLine("\nExample Test Cases:");
      Console.WriteLine("1,2,3\t->\t1,4,9");
      Console.WriteLine("2,4,5\t->\t4,16,25");
      Console.WriteLine("\nHave your app use it's own shorthand to specify the operation to perform.");
      Console.WriteLine("* 2,4,5\t->\t40");
      Console.WriteLine("^2 2,4,5\t->\t4,16,25");
      Console.WriteLine("\nHave your app support sum(+) and division(/) operations.");
      Console.WriteLine("+ 30,10,2\t->\t42");
      Console.WriteLine("\nHave your app support the average(avg) operation.");
    }

  }
}
