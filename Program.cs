namespace Orai01
{
    internal class Program
    {
        public class Data
        {
            public List<string> NobelData { get; set; }

            public Data(List<string> nobleData)
            {
                nobleData.RemoveAt(0);
                NobelData = nobleData;
            }
        }
        static void Main(string[] args)
        {


            string nobelPath = @"Nobel.csv";

            Data readNobelData = new(File.ReadAllLines(nobelPath).ToList());



            //3. Feladat:

            foreach (var guy in readNobelData.NobelData)
            {
                if (guy.Split(';')[2] == "Arthur B." &&
                    guy.Split(';')[3] == "McDonald")
                {
                    Console.WriteLine($"Arthur B. Mcdonald {guy.Split(';')[1]} Nobel-díjat kapott.");
                }
            }

            //4. Feladat:

            Console.Write("\nEzek az emberek kaptak irodalmi Nobel-dijat 2017-ben:\n");
            foreach (var pepl in readNobelData.NobelData)
            {
                if (pepl.Split(';')[0] == "2017" &&
                    pepl.Split(";")[1] == "irodalmi")
                {
                    Console.Write($"{pepl.Split(';')[3]} {pepl.Split(';')[2]}\n");
                }
            }

            //5.Feladat:

            Console.Write("\nEzek a szervezetek kaptak Nobel-díjat 1990 után:\n");

            foreach (var org in readNobelData.NobelData)
            {
                if (Convert.ToInt32(org.Split(';')[0]) > 1990 &&
                    org.Split(';')[2].Contains("(") == true &&
                    org.Split(';')[2].Contains("(Al)") == false)
                {
                    Console.Write($"{org.Split(';')[2]}\n");
                }
            }

            //6.Feladat:

            Console.WriteLine("\nA Curie család ezen tagja kapott Nobel-díjat:\n");

            foreach (var curie in readNobelData.NobelData)
            {
                if (curie.Split(';')[3].Contains("Curie") == true) 
                   Console.WriteLine($"{curie.Split(';')[2]} {curie.Split(';')[3]} - {curie.Split(';')[0]} - {curie.Split(';')[1]}");
            }



            //7.Feladat:

            int fizikai = 0;
            int kemiai = 0;
            int orvosi = 0;
            int irodalmi = 0;
            int beke = 0;
            int kozg = 0;

            foreach (var nobel in readNobelData.NobelData)
            {
                switch (nobel.Split(';')[1])
                {
                    default:
                        break;
                    case "fizikai":
                        fizikai++;
                        break;
                    case "kémiai":
                        kemiai++;
                        break;
                    case "orvosi":
                        orvosi++;
                        break;
                    case "irodalmi":
                        irodalmi++;
                        break;
                    case "béke":
                        beke++;
                        break;
                    case "közgazdaságtani":
                        kozg++;
                        break;
                }
            }

            Console.WriteLine($"\nEnnyi Nobel-díjat osztottak ki összesen típusonként:\n" +
                $"fizikai: {fizikai}\nkémiai: {kemiai}\norvosi: {orvosi}\nirodalmi: {irodalmi}\nbéke: {beke}\nközgazdaságtani: {kozg}");

            //8.Feladat:

            List<string> orvosiak = new();
            string orvosPath = @"orvosi.txt";

            foreach (var orvos in readNobelData.NobelData)
            {
                if (orvos.Split(';')[1] == "orvosi")
                    orvosiak.Add($"{orvos.Split(';')[0]}: {orvos.Split(';')[2]} {orvos.Split(';')[3]}"); 
            }
            foreach (var item in orvosiak)
            {
                Console.WriteLine(item.ToString());
            }
            if (File.Exists(orvosPath))
            {
                File.Delete(orvosPath);
                File.WriteAllLines(orvosPath, orvosiak);
            }
            else File.WriteAllLines(orvosPath, orvosiak);

        }
    }
            
}

