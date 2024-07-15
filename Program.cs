using System;
using System.Collections;
using System.Collections.Generic;

namespace FinalProj.FitnessApp
{
    internal class Program
    {
        private static ArrayList users = new ArrayList();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("FITNESS APP");
                Console.WriteLine("Choose:");
                Console.WriteLine("1. Log in");
                Console.WriteLine("2. Sign up");
                Console.WriteLine("3. Exit Program");
                string options = Console.ReadLine();

                switch (options)
                {
                    case "1":
                        Login.AccountUser(users);
                        break;

                    case "2":
                        Signup.Account(users);
                        break;

                    case "3":
                        Console.WriteLine("Exiting the program....");
                        return;

                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
        }
    }

    public static class Signup
    {
        public static void Account(ArrayList users)
        {
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            bool userExists = false;
            foreach (User user in users)
            {
                if (user.Email == email)
                {
                    userExists = true;
                    break;
                }
            }

            if (userExists)
            {
                Console.WriteLine("User already exists. Please try again.");
            }
            else
            {
                users.Add(new User { Email = email, Password = password });
                Console.WriteLine("Signup successful!");
                Login.AccountUser(users);
            }
        }
    }

    public static class Login
    {
        public static void AccountUser(ArrayList users)
        {
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            User loggedInUser = null;
            foreach (User user in users)
            {
                if (user.Email == email && user.Password == password)
                {
                    loggedInUser = user;
                    break;
                }
            }

            if (loggedInUser != null)
            {
                Console.WriteLine("Log in successfully!!");
                ShowMenu(loggedInUser);
            }
            else
            {
                Console.WriteLine("Incorrect, please try again.");
            }
        }

        private static void ShowMenu(User user)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. BMI calculator");
                Console.WriteLine("2. Health Indicator");
                Console.WriteLine("3. Start a program");
                Console.WriteLine("4. Save your daily progress");
                Console.WriteLine("5. Show progress");
                Console.WriteLine("6. Exit the program");

                string menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        BMICalculator();
                        break;
                    case "2":
                        HealthIndicator();
                        break;
                    case "3":
                        StartProgram();
                        break;
                    case "4":
                        SaveDailyProgress(user);
                        break;
                    case "5":
                        ShowProgress(user);
                        break;
                    case "6":
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
        }

        private static void BMICalculator()
        {
            Console.WriteLine("BMI calculator chosen.");
            Console.Write("Enter height(m): ");
            double height = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter weight(kg): ");
            int weight = Convert.ToInt32(Console.ReadLine());

            double bmi = weight / (height * height);

            Console.WriteLine($"Your BMI is {bmi}");
        }

        private static void HealthIndicator()
        {
            Console.WriteLine("Health Indicator chosen.");
            Console.Write("Input BMI(at 2 decimal places): ");
            double input = Convert.ToDouble(Console.ReadLine());

            if (input < 18.5)
            {
                Console.WriteLine("Malnourished");
            }
            else if (input >= 18.6 && input <= 24.9)
            {
                Console.WriteLine("Normal");
            }
            else if (input >= 25.0 && input <= 29.9)
            {
                Console.WriteLine("Overweight");
            }
            else if (input >= 30.0)
            {
                Console.WriteLine("Obesity");
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        private static void StartProgram()
        {
            Console.WriteLine("Start a program chosen.");
            Console.WriteLine("Select one:");
            Console.WriteLine("1. Ectomorphic");
            Console.WriteLine("2. Mesomorphic");
            Console.WriteLine("3. Endomorphic");
            string select = Console.ReadLine();

            switch (select)
            {
                case "1":
                    Console.WriteLine("Ectomorph\nNaturally thin, struggles to gain muscle.\nIntensity: Moderate - High\nTips\n- Focus on compound movements that target multiple muscle groups\n- Use heavier weights with lower reps (6-12 reps)\n- Ensure longer rest periods between sets (60-90 seconds) to fully recover and lift heavier.\n - Prioritize muscle-building exercises over cardio.");
                    break;
                case "2":
                    Console.WriteLine("Mesomorph\nNaturally muscular, gains muscle easily\nIntensity: Moderate\nTips\n- Combine strength training with moderate cardio to maintain muscle mass and avoid fat gain.\n - Use moderate weights with moderate reps (8-15 reps).\n - Maintain balanced rest periods (30-60 seconds) between sets.");
                    break;
                case "3":
                    Console.WriteLine("Endomorph\nNaturally higher body fat, gains fat easily\nIntensity: High\nTips\n- Focus on high-intensity interval training (HIIT) and circuit training to burn fat.\n- Use lighter weights with higher reps (12-20 reps) and minimal rest (15-30 seconds) between sets.\n - Include a mix of cardio and strength training to boost metabolism and preserve muscle mass.");
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
        }

        private static void SaveDailyProgress(User user)
        {
            Console.WriteLine("Enter today's date (mm-dd-yyyy): ");
            string date = Console.ReadLine();
            Console.WriteLine("Enter your progress: ");
            string progress = Console.ReadLine();

            user.DataProgress.Add(new UserData { Date = date, Progress = progress });
            Console.WriteLine("Data progress has been saved!");
        }

        private static void ShowProgress(User user)
        {
            Console.WriteLine("Showing progress:");
            foreach (var data in user.DataProgress)
            {
                Console.WriteLine($"Date: {data.Date}, Progress: {data.Progress}");
            }
        }
    }
}
