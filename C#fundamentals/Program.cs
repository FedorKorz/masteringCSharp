using System.Collections;

namespace CSharpFundamentals
{
    class Program : NewClass
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();
            array.Add("first");
            array.Add("second");
            array.Add("third");
            
            foreach (String iteam in array)
            {
                Console.WriteLine(iteam);
            }

        }
    }

}
