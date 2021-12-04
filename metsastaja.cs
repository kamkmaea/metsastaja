/* Title: Metsästäjä
 * Authors: Sari Tolonen ja Marja Tuhkanen
 * Marjan muutokset https://github.com/kamkmaea/metsastaja
*/

using System;

namespace metsastaja_harkka
{
    enum Direction
    {
        metsä = 1,
        niitty = 2,
        vuori = 3
    }
    interface SoundPoint
    {
        public void SoundPlayer()
        {
             //using Console.Beep() play sound at point
        }
    }

    abstract class Animal
    {
        protected int x = 0, y = 0;
        public virtual void SetLocation(int newX, int newY)
        {
            
        }
    }
    class Deer : Animal
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
        public void GetLocation()
        {
            Array values = Enum.GetValues(typeof(Direction)); 
            Random random = new Random();
            Direction randomDirection = (Direction)values.GetValue(random.Next(values.Length));
            //tarkista soundi
        }
        //Todo: play sound at point funktio
        //Console.Beep metodi
    }
    class Duck : Animal
    {
        public void DeathNoise()
        {
            Console.Beep();
            Console.WriteLine("Kääk!");
        }
        public Duck(string name)
        {

        }
        public Duck(string name, int x, int y)
        {
            this.name = name;
            SetLocation(x, y);
        }
        public string name { get; set; } = "Default";

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
        
        // TO-DO: if -lauseiden avulla kommentit siihen mihin osuttiin Program luokkaan
        // eläimillä voi olla erilaisia ominaisuuksia 
    }


















    public class Hunter
    {
        private string name;
        private string weapon;
        private string prey;
        private int weaponSrength;
        private double accuracy = 50;
        private double speed = 50;
        
        public void SetName()
        {
            Console.WriteLine("Mikä on nimesi?");
            name = Console.ReadLine().Trim();
        }
        
        public string GetName()
        {
            Console.WriteLine($"Pelihahmo {name}");
            return name;

        }
        
        public void SetWeapon()
        {
            Console.Write($"Hei {name}! Valitsetko metsästysretkelle (H)aulikon vai (J)ousipyssyn? : ");
            string input = Console.ReadLine().Trim().ToLower();

            switch(input)
            {
                case "h":
                    Console.WriteLine($"Haulikko valittu.");
                    weapon = "haulikko";
                    weaponSrength = 50;
                    break;
                case "j":
                    Console.WriteLine("Jousipyssy valittu.");                    
                    weapon = "jousipyssy";
                    weaponSrength = 25;
                    break;
                default:
                    Console.WriteLine("Valintaa ei tunnistettu. Nyrkki valittu.");
                    weapon = "nyrkki";
                    weaponSrength = 10;
                    break;
            }
        }

        public string GetWeapon()
        {
            Console.WriteLine($"Sinulla on {weapon}");
            return weapon;
        }
        public void SetPrey()
        {
            Console.Write($"Haluatko metsästää (P)euroja vai (A)nkkoja?: ");
            string input = Console.ReadLine().Trim().ToLower();

            switch(input)
            {
                case "p":
                    Console.WriteLine($"Saaliiksesi valitsit peuran.");
                    prey = "Peura";
                    break;
                case "a":
                    Console.WriteLine("Saaliiksesi valitsit ankan.");                    
                    prey = "Ankka";
                    break;
                default:
                    Console.WriteLine("Valintaa ei tunnistettu. Peura valittu.");
                    prey = "Peura";
                    break;
            }
        }
        public string GetPrey()
        {
            Console.WriteLine($"Saalistat {prey}");
            return prey;
        }
        
        public double GetAccuracy()
        {
            Console.WriteLine($"Tarkkuutesi on {accuracy}/100");
            return accuracy;
        }
        
        public double GetSpeed()
        {
            Console.WriteLine($"Nopeutesi on {speed}/100");
            return speed;
        }

        public int GetStrength()
        {
            Console.WriteLine($"Aseen voima on {weaponSrength}/100");
            return weaponSrength;
        }


        public void Shoot()
        {
            Console.WriteLine("Bang!");
        }


        public void Listen()
        {
            //soittaa äänen uudestaan
        }
    }


    public class Program 
    {
        static Random rnd = new Random();
        
        public static void Main(string[] args)
        {
            Console.WriteLine("\nTervetuloa pelaamaan metsästäjä peliä!\n");
            Hunter metsastaja = new Hunter();

            bool do_loop = true;
            while (do_loop)
            {
                    DrawMenu(); 
                    Console.Write("\n    Valintasi: ");
                    string input = Console.ReadLine().Trim();
                    
                    switch(input)
                    {
                        case "1":
                            Console.WriteLine("Pelihahmo valittu");
                            metsastaja.SetName();
                            metsastaja.SetWeapon();
                            //Player();
                            break;
                        case "2":
                            Console.WriteLine("Saalis valittu");
                            metsastaja.SetPrey();
                            metsastaja.GetPrey();
                            break;
                        case "3":
                            AskRounds();
                            break;
                        case "4":
                            Console.WriteLine("Aloitetaan peliä");
                            metsastaja.GetName();
                            metsastaja.GetWeapon();
                            metsastaja.GetPrey();
                            metsastaja.GetStrength();
                            metsastaja.GetAccuracy();
                            metsastaja.GetSpeed();
                            do
                            {
                                int rounds = AskRounds();
                
                                for (int i = 0 ; i < rounds ; i++)
                                {
                                    Deer deer0 = new Deer("Petteri");
                                    deer0.GetLocation();

                                    

                                    //TO-DO siajinnit
                                    Console.WriteLine($"Olet lähtenyt metsälle. Kuljet pitkin pientä polkua. ");
                                    Console.WriteLine($"Pohjoisessa sijaitsee, jonka suunnalta kuuluu. ");
                                    Console.WriteLine($"Lännessa näet niityn, josta on kuultavissa.");
                                    Console.WriteLine($"Idässä näet tuoretta kuusimetsää, josta välillä kuuluu kuusitiasen sirputus. ");
                                    Console.WriteLine($"Kuulet äänen.");
                                    Console.WriteLine($"Se on. Et osaa sanoa miltä suunnalta ääni tulee. Mihin suuntaan ammut?");


                                    //To-Do: peura pitää oman äänensä...?
                                    Console.WriteLine("(L)änsi, (P)ohjoinen, (I)tä tai (A)las");
                                    string userInput = Console.ReadLine().ToLower();
                                    //vaihda switch case
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
                                        Console.WriteLine("Osuit ankkaan!");
                                        Duck duck = new Duck("Aku");
                                        duck.DeathNoise();
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
                            }
                            while (Again());

                            break;
                        case "5":
                            Console.WriteLine("Lopetus valittu");
                            Console.WriteLine("Kiitos kun pelasit Metsästäjä peliä!");
                            Console.WriteLine("Sari Tolonen ja Marja Tuhkanen @TTK21SP2");
                            
                            do_loop = false;
                            break;
                        default:
                            Console.WriteLine("Valintaa ei tunnistettu. Valitse numero 1-5.");
                            break;    
                    }
            }
        }
        static int AskRounds()
        {
            Console.WriteLine("Matkan pituus valittu");
            Console.WriteLine("Kuinka monta kilometriä haluat kulkea? Maximi on 10km.");
            int.TryParse(Console.ReadLine(), out int rounds);
            if (rounds < 11)
            {
                Console.WriteLine($"Valitsit {rounds}kilometriä.");
            }
            else
            {
                Console.WriteLine("Liian monta kilometriä tai tuntematon syöte, matkan pituudeksi asetetaan 1km.");
                rounds = 1;
            }
            return rounds;
        }
        static void DrawMenu()
        {
            MakeLine(7);
            Console.Write("=( PÄÄVALIKKO )=");
            MakeLine(7);
            Console.WriteLine("\n");

            string[] menu = new string []{"Pelihahmo",
                                        "Saaliseläin",
                                        "Matkan pituus",
                                        "Aloita peli",
                                        "Lopeta peli"};
            for (int i = 1; i <= (menu.Length); i++)
            {
                Console.Write($"\t{i}. {menu[i-1]}\n");
            }
        }
        static void MakeLine(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write('-');
            }
        }
        static bool Again()
        //Tässä kysymys haluaako pelata uudestaan
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
}
