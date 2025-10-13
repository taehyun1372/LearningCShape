using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _8_Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("key", "value");

            var element = (string)hashtable["key"]; //hashtable is non generic type so it returns object type
            Console.WriteLine(element);

            hashtable["key"] = null; //we can either set or get value using the key 
            Console.WriteLine(hashtable["key"]);

            foreach(DictionaryEntry entry in hashtable) //hashtable returns DictionaryEnty when iterating
            {
                Console.WriteLine(entry.Value); //We can use either .Value or .Key 
            }

            Hashtable phoneBook = new Hashtable()
            {
                { "Marcin Jamro", "000-000-000" },
                { "John Smith", "111-111-111" }
            };
            phoneBook["Liiy Smith"] = "333-333-333";
            try
            {
                phoneBook.Add("Mary Fox", "222-222-222");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("They entry already exists");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Phone numbers");
            if(phoneBook.Count == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                foreach(DictionaryEntry entry in phoneBook)
                {
                    Console.WriteLine($"- {entry.Key}: {entry.Value}");
                }
            }

            Console.WriteLine("Search by name:");
            string name = Console.ReadLine();
            if(phoneBook.ContainsKey(name))
            {
                string number = (string)phoneBook[name];
                Console.WriteLine($"Found phone number : {number}");
            }
            else
            {
                Console.WriteLine("Could not find the book specified");
            }

            Dictionary<string, string> dictionary = new Dictionary<string, string>
            {
                {"Key 1 ", "Value 1" },
                {"Key 2 ", "Value 2" }
            };

            //string value = dictionary["key"]; key not found exception occurs
            string value;
            if (dictionary.TryGetValue("key", out value))
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("Could not find the key specified");
            }

            if(dictionary.ContainsKey("key"))
            {
                Console.WriteLine(dictionary["key"]);
            }
            else
            {
                Console.WriteLine("Could not find the key specified");
            }
            
            try
            {
                Console.WriteLine(dictionary["key"]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not find the key specified");
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
