using System;
using System.IO;
using System.Text;

using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace FileHandling
{
    class Program
    {

        



        static void Main(string[] args)
        {
            // Files_Read_Write_Types obj = new Files_Read_Write_Types();
            // obj.File_Handling_Demo();


            // Serialization

            Animal bowser = new Animal("Bowser", 25, 35);


            Stream str = File.Open("AnimalData.dat", FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(str, bowser);
            str.Close();

            bowser = null;

            str = File.Open("AnimalData.dat",FileMode.Open);
            bf = new BinaryFormatter();

            bowser = (Animal)bf.Deserialize(str);
            str.Close();
            Console.WriteLine(bowser.ToString());


            //XML Serialization

            bowser.Weight = 95;

            XmlSerializer serializer = new XmlSerializer(typeof(Animal));

            using (TextWriter tw = new StreamWriter(@"/Users/ankuchoudhary/Desktop/StrandCode/FileIO/C#File/bowser.xml"))
            {
                serializer.Serialize(tw, bowser);
            }

            bowser = null;

            XmlSerializer deserializer = new XmlSerializer(typeof(Animal));
            TextReader reader = new StreamReader(@"/Users/ankuchoudhary/Desktop/StrandCode/FileIO/C#File/bowser.xml");

            object obj = deserializer.Deserialize(reader);
            bowser = (Animal)obj;
            reader.Close();
            Console.WriteLine(bowser.ToString());


            //Collection of Animal
            List<Animal> theAnimals = new List<Animal>
            {
                new Animal("Mario", 23, 4.5),
                new Animal("Logan", 52, 9.2),
                new Animal("Giffy", 76, 14.8)
            };

            using(Stream fs = new FileStream(@"/Users/ankuchoudhary/Desktop/StrandCode/FileIO/C#File/AnimalList.xml",FileMode.Create))
            {
                XmlSerializer serializer2 = new XmlSerializer(typeof(List<Animal>));
                serializer2.Serialize(fs, theAnimals);

                
            };

            theAnimals = null;

            XmlSerializer serializer3 = new XmlSerializer(typeof(List<Animal>));

            using(FileStream fs2 = File.OpenRead(@"/Users/ankuchoudhary/Desktop/StrandCode/FileIO/C#File/AnimalList.xml"))
            {
                theAnimals = (List<Animal>)serializer3.Deserialize(fs2);
            }

            foreach(Animal a in theAnimals)
            {
                Console.WriteLine(a.ToString());
            }




        }
    }
}
