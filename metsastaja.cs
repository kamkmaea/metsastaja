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
        Random random = new Random();
        protected int x = 0, y = 0;
        private int RandomLocation;
        public virtual void SetLocation(int newX, int newY)
        {
            
        }
        public int GetRandomLocation()
        {
            Array values = Enum.GetValues(typeof(Direction));            
            Direction randomDirection = (Direction)values.GetValue(random.Next(values.Length));
            return RandomLocation;
            //tarkista soundi
        }
    }
    abstract class Human
    {
        private string Hurt;
    }
    class Poro : Animal
    {
        public Poro(string name)
        {
            this.name = name;
        }

        public Poro(string name, int x, int y)
        {
            this.name = name;
            SetLocation(x, y);
        }
        public string name { get; set; } = "Default";
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
    class Grandma: Human
    {
        public void Deathnoise()
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


















    class Hunter: Human
    {
        private string name = "Albert";
        private string weapon = "haulikko";
        private string prey = "peura";
        private int weaponSrength = 50;
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
                    prey = "peura";
                    break;
                case "a":
                    Console.WriteLine("Saaliiksesi valitsit ankan.");                    
                    prey = "ankka";
                    break;
                default:
                    Console.WriteLine("Valintaa ei tunnistettu. Poro valittu.");
                    prey = "peura";
                    break;
            }
        }
        public string GetPrey()
        {
            Console.WriteLine($"Saaliseläin {prey}");
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
        public void Hurt()
        {
            //Kiljahdus
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
                            metsastaja.GetName();
                            break;
                        case "2":
                            Console.WriteLine("Saalis valittu");
                            metsastaja.SetPrey();
                            metsastaja.GetPrey();
                            break;
                        case "3":
                            Console.WriteLine("Ase valittu");
                            metsastaja.SetWeapon();
                            metsastaja.GetWeapon();
                            break;
                        case "4":
                            Console.WriteLine("Aloitetaan peliä");
                            metsastaja.GetName();
                            metsastaja.GetWeapon();
                            metsastaja.GetPrey();
                            metsastaja.GetStrength();
                            metsastaja.GetAccuracy();
                            metsastaja.GetSpeed();
                            GameLoop(metsastaja);
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
                                        "Ase",
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
        {
            Console.WriteLine("Haluatko pelata uudestaan? (K)yllä vai (E)i?");
            string userInput = Console.ReadLine().Trim().ToLower();
            
            if (userInput.StartsWith("k"))
            {
                return true;
            }
            else if (userInput.StartsWith("e"))
            {
                return false;
            }
            else
            {
                Console.WriteLine("Tuntematon syöte, lopetetaan...");
                return false;
            }
        }
        static void GameLoop(Hunter metsastaja)
        {
            do
            {
                Deer deer0 = new Deer("");
                Duck duck0 = new Duck("");

                int preylocation;
                string animal;

                int rounds = AskRounds();

                for (int i = 0 ; i < rounds ; i++)
                {
                    string saalis = metsastaja.GetPrey();

                    if(saalis == "peura")
                    {
                        preylocation = deer0.GetRandomLocation();
                    }
                    else
                    {
                        preylocation = duck0.GetRandomLocation();
                    }


                    Console.WriteLine($"Olet lähtenyt {saalis} metsälle. Kuljet pitkin pientä polkua. ");
                    Console.WriteLine($"Pohjoisessa sijaitsee vuori");
                    Console.Beep();
                    Console.WriteLine(", jonka suunnalta kuuluu vuoripuron solina. ");
                    Console.WriteLine($"Lännessa näet niityn");
                    Console.Beep();
                    Console.WriteLine($", josta on kuultavissa leppoisa tuulevire, joka heiluttaa hellästi kukkasia.");

                    Console.WriteLine($"Idässä näet tuoretta kuusimetsää");
                    Console.Beep();
                    Console.WriteLine($", josta välillä kuuluu kuusitiasen sirputus. ");

                    Console.WriteLine($"Kuulet äänen.");
                    Console.Beep();
                    Console.WriteLine($"Se on {saalis}. Et osaa sanoa miltä suunnalta ääni tulee. Mihin suuntaan ammut?");

                    Console.WriteLine("Länsi (1), Pohjoinen (2), Itä (3) tai Alas (4)");
                    int.TryParse(Console.ReadLine(), out int suunta);
                    
                    if(preylocation == suunta)
                    {
                        int tulos = 10;
                        //int tulos = metsastaja.accuracy + metsastaja.speed + metsastaja.Strength - saalis.Luck - saalis.speed

                        if(tulos < 70)
                        {
                            Console.WriteLine("Ammuit ohi!");
                        }
                        else
                        {
                            Console.WriteLine("Osuit {saalis}an!");
                        }
                    }
                    else if(suunta == 4)
                    {
                        Console.WriteLine("Ammuit itseäsi jalkaan! Onko nyt hyvä?");
                        Console.Beep();

                    }
                    else
                    {
                        if(saalis == "peura")
                        {
                            string[] osuttuelain = new string[]{"ankka", "mummo", "poro",};
                            animal = osuttuelain[rnd.Next(osuttuelain.Length)];
                        }
                        else
                        {
                            string[] osuttuelain = new string[]{"peura", "mummo", "poro",};
                            animal = osuttuelain[rnd.Next(osuttuelain.Length)];
                        }

                        switch(animal)
                        {
                            case "peura":
                                Console.Beep();
                                Console.WriteLine("Osuit peuraan! Harmi, ettet ole peurametsällä.");
                                break;
                            case "ankka":
                                Console.WriteLine("Osuit ankkaan! Harmi, ettet ole ankkametsällä.");
                                break;
                            case "mummo":
                                Console.WriteLine("Voi ei! Osuit naapurin dementoituneeseen mummoon!");
                                Console.Beep();
                                break;
                            case "poro":
                                Console.WriteLine("Osuit poroon! Millä Joulupukki nyt tulee vierailulle?");
                                Console.Beep();
                                break;
                            default:
                                Console.WriteLine("Ammuit taivaalle! Minnehän luoti osuu?");
                                break;
                        }
                    }
                }
            }
            while (Again());
        }
    }
}