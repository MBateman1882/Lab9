using System;
using System.Collections.Generic;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string> { "Allen Anderson", "Brittany Bund", "Carl Crawford", "Debbie Dolan", "Eddie Everhart" };
            List<string> food = new List<string> { "Apple Pie", "Beef Stew", "Crab Cakes", "Donuts", "Egg Salad" };
            List<string> homeTown = new List<string> { "Ann Arbor, Michigan", "Bloomfield Hills, Michigan", "Concord, Michigan", "Dallas, Texas", "Edmond, Oklahoma" };
            List<string> color = new List<string> { "Aquamarine", "Blue", "Cyan", "Dark Red", "Ebony" };
            string input, extraInfo, differentInfo, differentStudent, addStudent;
            int inputNum = 0;
            bool exceptionCheck;

            do
            {
                Console.WriteLine("Here are the students in this class:");
                foreach (string student in names)
                {
                    Console.WriteLine(student);
                }

                Console.Write("Would you like to add a new student or view an existing student's information? ('Add' or 'View'): ");
                addStudent = Console.ReadLine().ToLower();

                while (addStudent != "add" && addStudent != "view")
                {
                    Console.WriteLine("Invalid input. Please choose either 'Add' or 'View'.");
                    addStudent = Console.ReadLine().ToLower();
                }

                if (addStudent == "add")
                {
                    ValidateNotNullOrEmpty(names, "name");

                    ValidateNotNullOrEmpty(homeTown, "hometown");

                    ValidateNotNullOrEmpty(food, "favorite food");

                    ValidateNotNullOrEmpty(color, "favorite color");
                }

                Console.Write($"Which student would you like to learn about? (1-{names.Count}): ");
                input = Console.ReadLine();

                do
                {
                    exceptionCheck = true;

                    try
                    {
                        inputNum = int.Parse(input) - 1;
                        Console.WriteLine($"You've selected {names[inputNum]}.");
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.Write($"Please enter a number from 1-{names.Count}: ");
                        input = Console.ReadLine();
                        exceptionCheck = false;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.Write($"Please only enter a number from 1-{names.Count}: ");
                        input = Console.ReadLine();
                        exceptionCheck = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.Write($"Please only enter a number from 1-{names.Count}: ");
                        input = Console.ReadLine();
                        exceptionCheck = false;
                    }

                } while (!exceptionCheck);

                do
                {
                    Console.Write("What would you like to know about them? ('Hometown', 'Favorite food', 'Favorite Color', or 'None'): ");
                    extraInfo = Console.ReadLine().ToLower();

                    while (extraInfo != "hometown" && extraInfo != "favorite food" && extraInfo != "favorite color" && extraInfo != "none")
                    {
                        Console.WriteLine("Invalid input. Please choose either 'Hometown', 'Favorite food', 'Favorite Color', or 'None'.");
                        extraInfo = Console.ReadLine().ToLower();
                    }

                    if (extraInfo == "hometown")
                    {
                        Console.WriteLine($"{names[inputNum]}'s hometown is {homeTown[inputNum]}.");
                    }
                    else if (extraInfo == "favorite food")
                    {
                        Console.WriteLine($"{names[inputNum]}'s favorite food is {food[inputNum]}.");
                    } 
                    else if (extraInfo == "favorite color")
                    {
                        Console.WriteLine($"{names[inputNum]}'s favorite color is {color[inputNum]}.");
                    }

                    Console.Write($"Would you like to learn something else about {names[inputNum]}? (y/n):");
                    differentInfo = Console.ReadLine().ToLower();

                    while (differentInfo != "y" && differentInfo != "n")
                    {
                        Console.WriteLine("Invalid input");
                        differentInfo = Console.ReadLine().ToLower();
                    }

                } while (differentInfo == "y");


                Console.Write("Would you like information on a different student? (y/n): ");
                differentStudent = Console.ReadLine().ToLower();

                while (differentStudent != "y" && differentStudent != "n")
                {
                    Console.WriteLine("Invalid input");
                    differentStudent = Console.ReadLine().ToLower();
                }

            } while (differentStudent == "y");

            Console.WriteLine("Goodbye!");
            return;

            //Commented-out code from in-class demonstration. Insufficient time to impliment into the lab and finish building but kept as reference.

            //StudentInfo studentTwo = new StudentInfo("Name", "town", "food");

            //List<StudentInfo> studentList = new List<StudentInfo>();

            //studentList.Add(studentTwo);

            //Console.WriteLine("Add new student");
            //bool repeat = true;

            //while(repeat)
            //{
            //    Console.WriteLine("Give me a new student's name");
            //    string name = Console.ReadLine();
            //    Console.WriteLine("Give me a new student's hometown");
            //    string hometown = Console.ReadLine();
            //    Console.WriteLine("Give me a new student's favorite food");
            //    string favoritefood = Console.ReadLine();

            //    //StudentInfo newStudent = new StudentInfo(name, hometown, favoritefood);

            //    studentList.Add(new StudentInfo(name, hometown, favoritefood));

            //    Console.WriteLine("Continue");
            //    string inputTwo = Console.ReadLine().ToLower();
            //    if(inputTwo != "y")
            //    {
            //        repeat = false;
            //    }
            //}

            //foreach(StudentInfo Student in studentList)
            //{
            //    Console.WriteLine($"{Student.Name} {Student.HomeTown} {Student.FavoriteFood}");
            //}
        }

        public static void ValidateNotNullOrEmpty(List<string> List, string ListType)
        {
            bool repeat;
            string NewListEntry;

            do
            {
                Console.Write($"Please enter the new student's {ListType}: ");
                NewListEntry = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(NewListEntry))
                {
                    Console.WriteLine("Cannot have a blank entry.");
                    repeat = true;
                }
                else
                {
                    repeat = false;
                    List.Add(NewListEntry);
                }

            } while (repeat == true);
        }
    }
}
