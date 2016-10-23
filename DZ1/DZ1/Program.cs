using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> listOfIntegers = new GenericList<int>();
            listOfIntegers.Add(1); // [1]
            listOfIntegers.Add(2); // [1 ,2]
            listOfIntegers.Add(3); // [1 ,2 ,3]
            listOfIntegers.Add(4); // [1 ,2 ,3 ,4]
            listOfIntegers.Add(5); // [1 ,2 ,3 ,4 ,5]
            listOfIntegers.RemoveAt(0); // [2 ,3 ,4 ,5]
            listOfIntegers.Remove(5); // [2 ,3 ,4]
            Console.WriteLine ( listOfIntegers.Count ); // 3
            Console.WriteLine ( listOfIntegers.Remove (100) ); // false
            Console.WriteLine ( listOfIntegers.RemoveAt (5)); // false
            listOfIntegers.Clear (); // []
            Console.WriteLine ( listOfIntegers.Count ); // 0


            GenericList<string> listOfStrings = new GenericList<string>();
            listOfStrings.Add("1"); // [1]
            listOfStrings.Add("2"); // [1 ,2]
            listOfStrings.Add("3"); // [1 ,2 ,3]
            listOfStrings.Add("4"); // [1 ,2 ,3 ,4]
            listOfStrings.Add("5"); // [1 ,2 ,3 ,4 ,5]
            listOfStrings.RemoveAt(0); // [2 ,3 ,4 ,5]
            listOfStrings.Remove("5"); // [2 ,3 ,4]
            Console.WriteLine(listOfStrings.Count); // 3
            Console.WriteLine(listOfStrings.Remove("100")); // false
            Console.WriteLine(listOfStrings.RemoveAt(5)); // false
            listOfStrings.Clear(); // []
            Console.WriteLine(listOfStrings.Count); // 0

            IGenericList<string> stringList = new GenericList<string>();
            stringList.Add(" Hello ");
            stringList.Add(" World ");
            stringList.Add("!");

            // foreach
            // foreach (string value in stringList)
            //  {
            //      Console.WriteLine(value);
            //  }

            // foreach without the syntax sugar
            IEnumerator<string> enumerator = stringList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                string value = (string)enumerator.Current;
                Console.WriteLine(value);
            }
        }
    }
}
