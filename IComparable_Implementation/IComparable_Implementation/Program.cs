using System;
using System.Collections.Generic;

namespace IComparable_Implementation
{
    public class StudentComparision : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x.Marks > y.Marks) return 1;
            else if (x.Marks < y.Marks) return -1;
            else return 0;
        }
    }
    class Program
    {
        static void Main()
        {
            Student s1 = new Student() { SID = 102, Class = 5, Marks = 87.5f, Name = "Aman" };
            Student s2 = new Student() { SID = 112, Class = 5, Marks = 97.5f, Name = "Kiran"};
            Student s3 = new Student() { SID = 106, Class = 5, Marks = 93.5f, Name = "Shiv" };
            Student s4 = new Student() { SID = 110, Class = 5, Marks = 67.0f, Name = "John" };
            Student s5 = new Student() { SID = 101, Class = 5, Marks = 99.2f, Name = "Jim"  };
            Student s6 = new Student() { SID = 108, Class = 5, Marks = 53.8f, Name = "Raj"  };

            List<Student> ls = new List<Student>() { s1, s2, s3, s4, s5, s6 };


           // ls.Sort();

            StudentComparision obj = new StudentComparision();
            ls.Sort(obj);

            foreach (Student s in ls)
            {
                s.Information();
                Console.WriteLine();
            }
                
            // If we have given a class only to consume then we need to define another class and inherit
            // IComparer interface to it and then pass the overloaded method of sort which takes the
            // object of IComparer as a parameter implementation of both IComparer and IComparable is basically the same

        }


    }
}