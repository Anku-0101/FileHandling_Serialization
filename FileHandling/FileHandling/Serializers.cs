using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileHandling
{
    public class Serializers
    {
        public Serializers()
        {
        }

        public void Serialization_Demo()
        {

        }
    }

    [Serializable()]

    public class Animal : ISerializable
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int AnimalID { get; set; }

        public Animal()
        {

        }

        public Animal(string name = "No Name", double weight =0, double height = 0)
        {
            Name   = name;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return string.Format(" {0} weighs {1} lbs and is {2} inches tall", Name, Weight, Height);
        }

        //Serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //SerializationInfo hold key value pairs
            //Streaming context is used to hold additional information

            info.AddValue("Name", Name);
            info.AddValue("Weight", Weight);
            info.AddValue("Height", Height);
        }

        //Deserialization

        public Animal(SerializationInfo info, StreamingContext context)
        {
            Name   = (string)info.GetValue("Name",    typeof(string));
            Weight = (double)info.GetValue("Weight",  typeof(double));
            Height = (double)info.GetValue("Height",  typeof(double));
        }
    }

}
