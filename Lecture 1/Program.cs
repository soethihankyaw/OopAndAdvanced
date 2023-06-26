using System.Diagnostics;
using System.Text;
using Custom.Oop.Learn;

class Program
{
    public static void Main(string[] args)
    {
        randomNumberCorrectWay();
       
        Human human = new Human();
        human.Name = "Soe Thi";
        human.Age = 22;

        Console.Write("My Name is {0} and {1} years old!",human.Name, human.Age);
    }

    public static void writeDictonaryToAFile(Dictionary<int, int> dictNums, string srFileNamel)
    {   
        Stopwatch sw = new Stopwatch();
        sw.Start();
        StringBuilder stringBuilder = new StringBuilder();
        var srTemp = "";
        foreach(var item in dictNums)
        {
            srTemp = srTemp + stringBuilder.AppendLine($"Number {item.ToString()} has been randomly generated.");
        }
        File.WriteAllText(srFileNamel, stringBuilder.ToString());
        sw.Stop();
        Console.WriteLine("Elapsed File total ms with Proper Way {0}", sw.Elapsed.TotalMilliseconds);


    }
    public static void randomNumberCorrectWay()
    {
        Random myRandom = new Random();
        Dictionary<int, int> dictNumbers = new Dictionary<int, int>();
        Stopwatch timer = new Stopwatch();
        timer.Start();
        for(int i = 0; i < 1000000; i++ )
        {
            var vrNumber = myRandom.Next(1, 101);

            try
            {
               if(dictNumbers.ContainsKey(vrNumber))
                {
                    dictNumbers[vrNumber]++;
                }
                else
                {
                    dictNumbers.Add(vrNumber, 1);
                }
            } catch(Exception e) 
            {
                dictNumbers[vrNumber]++;
            }
        }
        timer.Stop();
        Console.WriteLine("Elapsed total ms with Proper Way {0}",timer.Elapsed.TotalMilliseconds);
        writeDictonaryToAFile(dictNumbers, "DictFile");
    }
}