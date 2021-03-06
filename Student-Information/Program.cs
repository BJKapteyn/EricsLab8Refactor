﻿using System;
using System.Collections.Generic;

namespace Student_Information
{
    class Program
    {
        public static List<Student> Students = new List<Student>();
        

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our C# class. Which student would you like to learn more about?");
            AddStudent("Eric Holt", "Italian", "Paragould");
            AddStudent("Miguel", "BBQ Ribs", "Chicago, IL.");
            AddStudent("Andre Otte", "Veggie Burgers", "St Catherines, Ontario");
            GetInput();
        }

        public static void AddStudent(string name, string favoriteFood, string homeTown)
        {
            Students.Add(new Student(name, favoriteFood, homeTown));
        }

        public static string GetStudent(int index)
        {
            //Write a static method named GetStudent().
            //This method will take in an int index and return a string with all the info about a student: name, favorite food, and hometown.
            //Format it as you please, as long as all the data is in there. - 1pt
            //If GetStudent receives an index not attached to student, the method should throw an IndexOutOfRange Exception.
            //Catch the exception and return a string saying “Student not found, try another index” -1pt for throwing exception, then catching and returning
            try
            {
                if (index > Students.Count - 1)
                {
                    throw new IndexOutOfRangeException("Student not found, try another index");
                }
                else
                {
                    return $"{Students[index]}";
                }
            }
            catch (IndexOutOfRangeException e)
            {
                return e.Message;
            }
        }

        public static void PrintMenu()
        {
            for (int i = 0; i < Students.Count; i++)
            {
                Console.WriteLine($"{i}) - {Students[i].Name}");
            }
        }

        public static void GetInput()
        {

            bool validUserInput = false;
            int index = 0;
            string userInput;

            while (!validUserInput)
            {
                PrintMenu();
                Console.WriteLine("Please select index of the student you want to learn about");
                userInput = Console.ReadLine();

                //Convert to an int - passint to get student or throw formatException
                try
                {
                    index = int.Parse(userInput);
                    if(index < Students.Count)
                    {
                        validUserInput = true;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("That student does not exist.  Please try again.");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Not a valid number please try again.");
                }
                catch(IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            string student = GetStudent(index);
            Console.WriteLine($"Student {index} is {Students[index].Name}. What would you like to know about {Students[index].Name}? (enter or “hometown” or “favorite food”)");
            LearnMore(index);
        }

        public static void LearnMore(int index)
        {
            string name = Students[index].Name;
            string food = name + "'s favorite food is " + Students[index].FavoriteFood + ".";
            string homeTown = name + "'s home town is " + Students[index].HomeTown + ".";
            bool validInput = false;
            //Console.WriteLine($"What would you like to know about {name}? (enter “hometown” or “favorite food”)");


            while (!validInput)
            {
                
                string userInput = Console.ReadLine();
                bool validAnswer = false;

                if (userInput.ToLower() == "hometown")
                {
                    string studentHomeTown = homeTown + " Would you like to know more? (enter “yes” or “no”): ";
                    Console.WriteLine(studentHomeTown);
                    while (!validAnswer)
                    {
                        string userAnswer = Console.ReadLine();
                        if (userAnswer.ToLower() == "yes" || userAnswer.ToLower() == "y" )
                        {
                            Console.WriteLine($"Student {index} is {name}. What would you like to know about {name}? (enter or “hometown” or “favorite food”)");
                            validAnswer = true;
                        }
                        else if(userAnswer.ToLower() == "no" || userAnswer.ToLower() == "n")
                        {
                            validAnswer = true;
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine(studentHomeTown);
                        }
                    }
                }
                else if (userInput.ToLower() == "favorite food")
                {
                    string studentFood = food + " Would you like to know more? (enter “yes” or “no”): ";
                    Console.WriteLine(studentFood);
                    while (!validAnswer)
                    {
                        string userAnswer = Console.ReadLine();
                        if (userAnswer.ToLower() == "yes" || userAnswer.ToLower() == "y")
                        {
                            Console.WriteLine($"Student {index} is {name}. What would you like to know about {name}? (enter or “hometown” or “favorite food”)");
                            validAnswer = true;
                        }
                        else if (userAnswer.ToLower() == "no" || userAnswer.ToLower() == "n")
                        {
                            validAnswer = true;
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine(studentFood);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("That data does not exist.  Please try again.");

                }
                
            }
            validInput = false;
        }
    }
}
