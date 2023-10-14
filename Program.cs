using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Formats.Asn1;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace File_IO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select A Program You Want To Run");
            Console.WriteLine("\n1.Write Json file \n2.Read Json File \n3 Write XML File \n4 Read XML File \n5 Write Txt File \n6. Read Txt File");
            int Option = Convert.ToInt32(Console.ReadLine());
            var data = new NewData
            {
                Name = "Test",
                Age = 1,
            };
            switch (Option)
            {
                case 1:

                    string FilePath = "C:\\Users\\hshem\\source\\repos\\File_IO\\Data.json";
                    string jsonData = JsonSerializer.Serialize(data);
                    File.WriteAllText(FilePath, jsonData);
                    Console.WriteLine("Done!!");

                    break;
                case 2:

                    string filePath = "C:\\Users\\hshem\\source\\repos\\File_IO\\Data.json";
                    if (File.Exists(filePath))
                    {
                        var JsonData = File.ReadAllText(filePath);
                        var Data = JsonSerializer.Deserialize<NewData>(JsonData);
                        Console.WriteLine("Data read from JSON file:");
                        Console.WriteLine($"Name: {Data.Name}");
                        Console.WriteLine($"Age: {Data.Age}");
                    }
                    else
                    {
                        Console.WriteLine("JSON file not found.");
                    }

                    break;
                case 3:
                    string file_Path = "C:\\Users\\hshem\\source\\repos\\File_IO\\Data.xml";


                    using (var writer = new StreamWriter(file_Path))
                    {
                        var serializer = new XmlSerializer(typeof(NewData));
                        serializer.Serialize(writer, data);
                    }

                    Console.WriteLine("Data written to XML file.");

                    break;
                case 4:
                    string File_Path = "C:\\Users\\hshem\\source\\repos\\File_IO\\Data.xml";


                    if (File.Exists(File_Path))
                    {
                        using (var reader = new StreamReader(File_Path))
                        {
                            var serializer = new XmlSerializer(typeof(NewData));
                            var Data_Xml = (NewData)serializer.Deserialize(reader);

                            Console.WriteLine("Data read from XML file:");
                            Console.WriteLine($"Name: {data.Name}");
                            Console.WriteLine($"Age: {data.Age}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("XML file not found.");
                    }

                    break;
                case 5:
                    var csv_data = new List<NewData>
                       {
                         new NewData { Name = "Test1", Age = 2 },
                         new NewData { Name = "Test2", Age = 3 }
                         };


                    string csv_filePath = "C:\\Users\\hshem\\source\\repos\\File_IO\\Data.csv";


                    using (var writer = new StreamWriter(csv_filePath))
                    {
                        foreach (var item in csv_data)
                        {
                            writer.WriteLine($"{item.Name},{item.Age}");
                        }
                    }

                    Console.WriteLine("Data written to CSV file.");

                    break;
                case 6:

                    break;  
                    case 7:
                    return;
               
                    
            }
                    
        }
        
    }


    public class NewData
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}