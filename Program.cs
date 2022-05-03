using System.Linq;
public class Program{
    public static void Main(String[] args){
        try{
            string[] lines = File.ReadAllLines("/home/philipp/Dokumente/Programmieren/C#/Programming Language/Test.txt");
            Interpreter(lines);
        }catch(IndexOutOfRangeException){
            Console.WriteLine("IndexOutOfRangeExeption while starting.");
            Console.WriteLine("Possible Solutions:");
            Console.WriteLine("- Add code to file");
        }
    }

    public static void Interpreter(String[] lines){
        List<Integers> integers = new List<Integers>();

        foreach(String line in lines){
            string[] split = line.Split(new char[] {' ', '(', ')', '.', '"', '='}, StringSplitOptions.RemoveEmptyEntries);
            if(split[0] == "output"){
                bool found = false;
                foreach(Integers integer in integers){
                    if (integer.intName == split[1]){
                        Console.WriteLine(integer.intValue.ToString());
                        found = true;
                    }
                }
                if(found == false){
                    string[] output = line.Split(new char[] {'"'});
                    Console.WriteLine(output[1]);
                }

            }else if(split[0] == "int"){
                integers.Add(new Integers(split[1], Int32.Parse(split[2])));
            }

        }
    }
}