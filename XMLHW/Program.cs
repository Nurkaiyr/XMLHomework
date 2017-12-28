using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLHW
{
    class Program
    {
        static void Main(string[] args)
        {
            //FirstTask();
            SecondTask();
        }

        private static void SecondTask()
        {
            XmlDocument docs = new XmlDocument();
            docs.Load("Student.xml");
            var root = docs.DocumentElement;
            foreach (XmlNode child in root.ChildNodes)
            {
                if (child.NodeType == XmlNodeType.Element) Console.WriteLine(child.Name+ " "+ child.InnerText);
            }
        }

        private static void FirstTask()
        {
            List<Item> items = new List<Item>();

            XmlTextReader xmlReader = new XmlTextReader("https://habrahabr.ru/rss/interesting/");

            while (xmlReader.Read())
            {
                Item item = new Item();

                while (xmlReader.Read() && item.PubDate == null)
                {
                    if (xmlReader.NodeType == XmlNodeType.Element)
                        switch (xmlReader.Name)
                        {
                            case "title":
                                xmlReader.Read();
                                item.Title = xmlReader.ReadString();
                                break;

                            case "link":
                                xmlReader.Read();
                                item.Link = xmlReader.ReadString();
                                break;

                            case "description":
                                xmlReader.Read();
                                item.Description = xmlReader.ReadString();
                                break;

                            case "pubDate":
                                xmlReader.Read();
                                item.PubDate = xmlReader.ReadString();
                                break;
                        }
                }
                items.Add(item);
            }

            foreach (var item in items)
            {
                PrintItem(item);

                Console.WriteLine();
            }

            Console.ReadLine();
        }

        static public void PrintItem(Item item)
        {
            Console.WriteLine($"{item.Title}\n\n" +$"{item.Description}\n\n" + $"{item.Link}\n" + $"{item.PubDate}\n");
        }
    }
}
