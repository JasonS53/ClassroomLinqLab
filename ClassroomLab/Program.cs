using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClassroomLab
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayAllDB();
            Console.WriteLine();
            DisplayStudentDB();
        }
        
        static void DisplayStudentDB()
        {           
            using (var context = new ClassContext())
            {
                Console.WriteLine("Which student would you like to find out more about?  Choose a number.");
                int input = int.Parse(Console.ReadLine());
               
                var sts = context.Students.Where(s => s.StudentId == input).ToList();
                foreach (var ok in sts)
                {
                    Console.WriteLine($"{ok.Name}'s favourite food is {ok.Food} and their hometown is {ok.Hometown}.");                   
                } 
            }           
        }

        static void DisplayAllDB()
        {
            using (var context = new ClassContext())
            {
                var sts = context.Students.Where(s => s.Name == s.Name).ToList();//Turns out this line is unnecessary
                foreach (Student student in sts)
                {                   
                    Console.WriteLine($"Id: {student.StudentId} Name: {student.Name}");
                }
               
            }    
        }

        static void CreateDB()
        {
            using (var context = new ClassContext())
            {
                Student st1 = new Student()
                {
                    Name = "Jason",
                    Food = "Mac and Cheese",
                    Hometown = "Courtright"
                };

                Student st2 = new Student()
                {
                    Name = "Kristen",
                    Food = "Macaroni and Cheese",
                    Hometown = "Orange Park"
                };

                Student st3 = new Student()
                {
                    Name = "Kalai",
                    Food = "Dosa",
                    Hometown = "Troy"
                };

                Student st4 = new Student()
                {
                    Name = "Sean",
                    Food = "Pizza",
                    Hometown = "Plymouth"
                };

                Student st5 = new Student()
                {
                    Name = "Jean",
                    Food = "Fritay",
                    Hometown = "Courtright"
                };

                Student st6 = new Student()
                {
                    Name = "Alice",
                    Food = "Sushi",
                    Hometown = "Detroit"
                };

                Student st7 = new Student()
                {
                    Name = "Justin",
                    Food = "Baja Blast",
                    Hometown = "Grand Rapids"
                };

                context.Students.Add(st1);
                context.Students.Add(st2);
                context.Students.Add(st3);
                context.Students.Add(st4);
                context.Students.Add(st5);
                context.Students.Add(st6);
                context.Students.Add(st7);
                context.SaveChanges();                
            }
        }
    }
}
