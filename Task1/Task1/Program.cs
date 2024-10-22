using System;

class Program
{
    static void Main()
    {
        int birthYear, birthMonth, birthDay;

        // Get the current date
        int currentYear = DateTime.Now.Year;
        int currentMonth = DateTime.Now.Month;
        int currentDay = DateTime.Now.Day;

        // Input for Birth Year
        do
        {
            Console.WriteLine("Please enter your birth year (1980-2023):");
            if (!int.TryParse(Console.ReadLine(), out birthYear) || birthYear < 1980 || birthYear > 2023)
            {
                Console.WriteLine("Invalid year, please try again.");
            }
        } while (birthYear < 1980 || birthYear > 2023);

        // Input for Birth Month
        do
        {
            Console.WriteLine("Please enter your birth month (1-12):");
            if (!int.TryParse(Console.ReadLine(), out birthMonth) || birthMonth < 1 || birthMonth > 12)
            {
                Console.WriteLine("Invalid month, please try again.");
            }
        } while (birthMonth < 1 || birthMonth > 12);

        // Input for Birth Day
        bool validDay;
        do
        {
            Console.WriteLine("Please enter your birth day:");
            validDay = int.TryParse(Console.ReadLine(), out birthDay) && IsValidDay(birthYear, birthMonth, birthDay);
            if (!validDay)
            {
                Console.WriteLine("Invalid day, please try again.");
            }
        } while (!validDay);

        // Calculate the age
        // Calculate age in years, months, and days
        int ageYears = currentYear - birthYear;
        int ageMonths = currentMonth - birthMonth;
        int ageDays = currentDay - birthDay;

        // If the birth month hasn't been reached yet in the current year, subtract one year from age
        if (ageMonths < 0)
        {
            ageYears--;
            ageMonths += 12;  // Add 12 to months to handle negative months
        }

        // If the birth day hasn't been reached yet in the current month, subtract one month and adjust days
        if (ageDays < 0)
        {
            ageMonths--;
            if (ageMonths < 0)  // Handle if the month goes negative after adjusting
            {
                ageMonths += 12;
                ageYears--;
            }
            // Add the number of days from the previous month
            int previousMonthDays = GetDaysInMonth(currentYear, currentMonth - 1);
            ageDays += previousMonthDays;
        }

        // Output the calculated age
        Console.WriteLine($"You're {ageYears} years, {ageMonths} months, and {ageDays} days old.");

        //DateTime birthDate = new DateTime(birthYear, birthMonth, birthDay);
        //TimeSpan ageSpan = currentDate - birthDate;

        //// Convert age in TimeSpan to years, months, and days
        //DateTime zeroTime = new DateTime(1, 1, 1);
        //DateTime age = zeroTime + ageSpan;

        //Console.WriteLine($"You're {age.Year - 1} years, {age.Month - 1} months, and {age.Day - 1} days old.");
    }

    static bool IsValidDay(int year, int month, int day)
    {
        // Months with 31 days: Jan(1), Mar(3), May(5), Jul(7), Aug(8), Oct(10), Dec(12)
        if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
        {
            return day >= 1 && day <= 31;
        }
        // Months with 30 days: Apr(4), Jun(6), Sep(9), Nov(11)
        else if (month == 4 || month == 6 || month == 9 || month == 11)
        {
            return day >= 1 && day <= 30;
        }
        // Months with 28 days: Feb(2)
        else if (month == 2)
        {
            return day >= 1 && day <= 28;
        }
        return false;
    }

    static int GetDaysInMonth(int year, int month)
    {
        int[] daysInMonths = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        // Adjust for leap year in February
        if (month == 2)
        {
            return 29;
        }
        if (month == 0) // If it's previous month from January, go back to December (31 days)
        {
            return 31;
        }
        return daysInMonths[month - 1];
    }
}
