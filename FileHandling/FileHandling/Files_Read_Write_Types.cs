using System;
using System.IO;
using System.Text;


namespace FileHandling
{
    public class Files_Read_Write_Types
    {
        public void File_Handling_Demo()
        {
            DirectoryInfo CurrDirectory = new DirectoryInfo(".");
            DirectoryInfo AnkuDir = new DirectoryInfo(@"/Users/ankuchoudhary/Desktop/StrandCode/FileIO");

            Console.WriteLine(AnkuDir.FullName);
            Console.WriteLine(AnkuDir.Name);
            Console.WriteLine(AnkuDir.Parent);
            Console.WriteLine(AnkuDir.Attributes);
            Console.WriteLine(AnkuDir.CreationTime);

            //Directory.CreateDirectory(@"/Users/ankuchoudhary/Desktop/StrandCode/FileIO/C#FileA");
            Directory.CreateDirectory(@"/Users/ankuchoudhary/Desktop/StrandCode/FileIO/C#File");

            // DirectoryInfo CreateDirB = new DirectoryInfo(@"/Users/ankuchoudhary/Desktop/StrandCode/FileIO/C#File/C#FileB");

            //Directory.Delete(@"/Users/ankuchoudhary/Desktop/StrandCode/FileIO/C#FileA");

            string[] cust =
            {
                "Ram",
                "Lakshman",
                "Bharat",
                "Shrtrughan"

            };

            string textfilepath = @"/Users/ankuchoudhary/Desktop/StrandCode/FileIO/C#File/testfile1.txt";

            File.WriteAllLines(textfilepath, cust);

            foreach (string cstmr in File.ReadAllLines(textfilepath))
            {
                Console.WriteLine($"Brothers : {cstmr}");
            }

            DirectoryInfo mydirectory = new DirectoryInfo(@"/Users/ankuchoudhary/Desktop/StrandCode/FileIO");

            FileInfo[] textfiles = mydirectory.GetFiles("*.txt", SearchOption.AllDirectories);

            Console.WriteLine("Length of text file {0}", textfiles.Length);

            foreach (FileInfo files in textfiles)
            {
                Console.WriteLine(files.Name);
                Console.WriteLine(files.Length);
            }


            //File Stream

            string textfilepath1 = @"/Users/ankuchoudhary/Desktop/StrandCode/FileIO/C#File/testfile2.txt";

            FileStream fs = File.Open(textfilepath1, FileMode.Create);

            string randomString = "This is a text used to store in file ";

            byte[] reBysteArray = Encoding.Default.GetBytes(randomString);

            fs.Write(reBysteArray, 0, reBysteArray.Length);

            fs.Position = 0;

            byte[] fileByte2Read = new byte[reBysteArray.Length];

            for (int i = 0; i < reBysteArray.Length; i++)
            {
                fileByte2Read[i] = (byte)fs.ReadByte();
            }

            Console.WriteLine(Encoding.Default.GetString(fileByte2Read));

            fs.Close();


            //Stream Reader and Writers are used for reading and writing strings

            string textFilepath3 = @"/Users/ankuchoudhary/Desktop/StrandCode/FileIO/C#File/testfile3.txt";

            StreamWriter sw = File.CreateText(textFilepath3);
            sw.Write("this is a string to be writen on file");
            sw.WriteLine("this is a sentence1");
            sw.WriteLine("this is a sentence2");
            sw.Close();

            StreamReader sr = File.OpenText(textFilepath3);

            Console.WriteLine("Peek : {0}", Convert.ToChar(sr.Peek()));
            Console.WriteLine("1st string :{0}", sr.ReadLine());
            Console.WriteLine("Everything else :{0}", sr.ReadToEnd());

            sr.Close();

            //Binary Readers and writers, used for stroring data files

            string textfilepath4 = @"/Users/ankuchoudhary/Desktop/StrandCode/FileIO/C#File/testfile4.dat";
            FileInfo datFile = new FileInfo(textfilepath4);
            BinaryWriter bw = new BinaryWriter(datFile.OpenWrite());

            string name = "Mohan";
            int age = 42;
            double height = 6.72;

            bw.Write(name);
            bw.Write(age);
            bw.Write(height);

            bw.Close();

            BinaryReader br = new BinaryReader(datFile.OpenRead());

            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadDouble());

            br.Close();



            Console.WriteLine("Hello World!");


        }
    }
}
