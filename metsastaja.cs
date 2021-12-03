/* Title: Metsästäjä
 * Authors: Sari Tolonen ja Marja Tuhkanen
 * Marjan muutokset
*/

using System;

namespace Metsastaja_harkka
{
    enum Direction
    {
        metsä = 0,
        niitty = 1,
        vuori = 2,
        //eri oliooiden sijaintien selostus
        // ilmansuunnat + alas
        // ei välttämättä tarpeellinen
    }
    interface IAudio
    {
        public void SoundPoint();
    }
    abstract class Animal
    {
        protected int x = 0, y = 0;
        public virtual void SetLocation(int newX, int newY)
        {
        }

        public string GetLocation()
        {
            string location = (x + " , " + y);
            return location;
        }
    }
    class Deer : Animal//, IAudio
    {
        public Deer(string name)
        {
            this.name = name;
        }

        public Deer(string name, int x, int y)
        {
            this.name = name;
            SetLocation(x, y);
        }
        public string name { get; set; } = "Default";

        public override void SetLocation(int newX, int newY)
        {
        }
        public void GetLocation(int newX, int newY)
        {
        }
    }
    class Rabbit : Animal
    {
        public Rabbit(string name, int x, int y)
        {
            this.name = name;
            SetLocation(x, y);
        }
        public string name { get; set; } = "Default";

        public override void SetLocation(int newX, int newY)
        {
            x = newX;
            y = newY;
        }
        public void GetLocation(int newX, int newY)
        {
            x = newX;
            y = newY;

        }
    }
    class Grandma
    {
        public void Cry()
        {
            Console.WriteLine("Auts!");
        }
        public void SetLocation(int newX, int newY)
        {
        }
        public void GetLocation(int newX, int newY)
        {
        }
            // TO-DO: grandma,dear,rabbit, sijainti - riippuen minkä sijainnin metsästäjä valitsee, siihen osuu
            // TO-DO: if -lauseiden avulla kommentit siihen mihin osuttiin Program luokkaan
            // eläimillä voi olla erilaisia ominaisuuksia 
    }
    class Program
    {
        //Yksinkertaistettu main
        static void Main(string[] args)
        {
            Console.Write("\n\nTervetuloa pelaamaan metsästäjä peliä!");

            Menu();

            do
            {
                GameLoop();
            }
            while (Again());
            
            Console.WriteLine("Kiitos kun pelasit Metsästäjä peliä! \nOhjelma loppuu...");
        }
        //Pelin päälooppi missä itse peli tapahtuu

        static void GameLoop()
        {
            Random rand = new Random();
            Deer deer0 = new Deer("Petteri");
            //TO-DO siajinnit
            Console.WriteLine("Olet lähtenyt peurametsälle. Kuljet pitkin pientä polkua. " +
                            "\nPohjoisessa sijaitsee vuori, jonka suunnalta kuuluu vuoripuron solinan. " +
                            "\nLännessä näet niityn, josta on kuultavissa leppoisa tuulevire, joka heiluttaa hellästi kukkasia. " +
                            "\nIdässä näet tuoretta kuusimetsää, jossa välillä kuuluu kuusitiasen sirputus. " +
                            "\nKuulet äänen. Et osaa sanoa miltä suunnalta ääni tulee. Mihin suuntaan ammut?");
            //To-Do: peura pitää oman äänensä...?
            Console.WriteLine("(L)änsi, (P)ohjoinen, (I)tä tai (A)las");
            string userInput = Console.ReadLine().ToLower();
        
            if (userInput.Trim().StartsWith("a"))
            {
                Console.WriteLine("Ammuit itseäsi jalkaan! Onko nyt hyvä?");
            }
            else if (userInput.Trim().StartsWith("p"))
            {
                Console.WriteLine("Osuit poroon! Millä Joulupukki nyt tulee vierailulle?");
            }
            else if (userInput.Trim().StartsWith("i"))
            {
                Console.WriteLine("Osuit jänikseen!");
            }
            else if (userInput.Trim().StartsWith("l"))
            {
               Console.WriteLine("Voi ei! Osuit naapurin dementoituneeseen mummoon!");
               Grandma grandma = new Grandma();
               grandma.Cry();
            }
            else
            {
                Console.WriteLine("Ammuit taivaalle! Minnehän luoti osuu?");
            }
        }
        //Tästä rakentuu valikko

        static void Menu()
        {
            Console.WriteLine("\nPÄÄVALIKKO \nTTK21SP2: Sari Tolonen ja Marja Tuhkanen");
            string[] menu = new string []{"Pelihahmo",
                                        "Saaliseläin",
                                        "Matkan pituus",
                                        "Aloita peli",
                                        "Lopeta peli"};
            for (int i = 1; i < (menu.Length); i++)
            {
                Console.Write($"\t{i}. {menu[i]}\n");
            } 
        }
        static void Player()
        {
            Console.WriteLine("Mikä on nimesi?");
            string input = Console.ReadLine();
            Console.Write($"Hei {input}! Valitsetko metsästysretkelle haulikon vai jousipyssyn?");
        }
        //Tässä kysymys haluaako pelata uudestaan
        static bool Again()
        {
            Console.WriteLine("Haluatko pelata uudestaan? (K)yllä vai (E)i?");
            string userInput = Console.ReadLine().Trim().ToLower();
            
            if (userInput.StartsWith("k"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class Hunter
    {
        private string name;
        private string weapon;
        private double accuracy;
        private double speed;

        public void Shoot()
        {
            Console.WriteLine("Bang!");
        }
        public void Listen()
        {
            //soittaa äänen uudestaan
        }
    }
}