using System;
using System.Collections.Generic;

namespace IComparable_Implementation
{
    public class Student //: IComparable<Student>
    {
        public int  SID { get; set; }
        public string Name { get; set; }
        public int  Class { get; set; }
        public float Marks { get; set; }

        public void Information()
        {
            Console.Write(this.SID);
            Console.Write(" ");
            Console.Write(this.Name);
            Console.Write(" ");
            Console.Write(this.Class);
            Console.Write(" ");
            Console.Write(this.Marks);
            Console.Write(" ");
        }

        //public int CompareTo(Student other)
       // {
         //   if (other.SID < this.SID) return 1;
           // else if (other.SID > this.SID) return -1;
           // else return 0;
       // }
    }
}
