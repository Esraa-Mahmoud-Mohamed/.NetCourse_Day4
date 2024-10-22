using System;

class Calculator
{
    static void Main()
    {
        bool continueCalculation = true;

        while (continueCalculation)
        {
            double num1 = GetValidNumber("Please enter #1:");
            double num2 = GetValidNumber("Please enter #2:");

            Console.WriteLine("Please enter operator (+, -, *, /):");
            char operation = Console.ReadKey().KeyChar;
            Console.WriteLine(); // Move to the next line after operator input

            double result = 0;
            bool validOperation = true;

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                    {
                        Console.WriteLine("Cannot divide by zero.");
                        validOperation = false;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operator.");
                    validOperation = false;
                    break;
            }

            if (validOperation)
                Console.WriteLine($"{num1} {operation} {num2} = {result}");
            char continueChoice = 'o';
            do {
                Console.WriteLine("Continue??? (y or n):");
                continueChoice = Console.ReadKey().KeyChar;
                Console.WriteLine(); // Move to the next line after choice input

                if (continueChoice == 'n' || continueChoice == 'N')
                {
                    continueCalculation = false;
                    Console.WriteLine("Program end.");
                    return;
                }
                else if (continueChoice == 'y' || continueChoice == 'Y')
                {
                    continueCalculation = true;
                }
                else
                {
                    Console.WriteLine("Enter Valid choise");
                }
            } while (continueChoice != 'y');
            
        }
    }

    static double GetValidNumber(string prompt)
    {
        double number;
        bool isValid = false;

        do
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            if (double.TryParse(input, out number))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        } while (!isValid);

        return number;
    }
}
