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
    abstract class Character
    {
        private string name;
        private int speed = 20;
        private int luck = 20;

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
        public int GetSpeed()
        {
            Console.WriteLine($"Nopeutesi on {speed}/100");
            return speed;
        }
        public int GetLuck()
        {
            Console.WriteLine($"Onnesi on {luck}/100");
            return luck;
        }
        public void Hurt()
        {
            //Play character sound
        }
    }
    abstract class Human : Character
    {
        //NAME from character
        //SPEED from character
        //LUCK from character
        //HURT from character?
        private string weapon;
        private string prey;
        private int weaponStrength;
        private int accuracy;

        public void SetWeapon()
        {
            Console.Write($"Valitsetko metsästysretkelle (H)aulikon vai (J)ousipyssyn? : ");
            string input = Console.ReadLine().Trim().ToLower();

            switch(input)
            {
                case "h":
                    Console.WriteLine($"Haulikko valittu.");
                    weapon = "haulikko";
                    weaponStrength = 50;
                    break;
                case "j":
                    Console.WriteLine("Jousipyssy valittu.");                    
                    weapon = "jousipyssy";
                    weaponStrength = 25;
                    break;
                default:
                    Console.WriteLine("Valintaa ei tunnistettu. Nyrkki valittu.");
                    weapon = "nyrkki";
                    weaponStrength = 10;
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
        public int GetWeaponStrength()
        {
            Console.WriteLine($"Aseen voima on {weaponStrength}/100");
            return weaponStrength;
        }
        
        public int GetAccuracy()
        {
            Console.WriteLine($"Tarkkuutesi on {accuracy}/100");
            return accuracy;
        }
        public int Shoot()
        {
            Console.WriteLine("Bang!");
            return -50;
        }
        public void Listen()
        {
            //soittaa äänen uudestaan
        }
        public void Speak()
        {
            //Tervehdys
        }
    }
    abstract class Animal: Character
    {
        Random random = new Random();
        //NAME from character
        //SPEED from character
        //LUCK from character
        //HURT from character?
        protected int x = 0, y = 0;
        private int RandomLocation;

        public int GetRandomLocation()
        {
            Array values = Enum.GetValues(typeof(Direction));            
            Direction randomDirection = (Direction)values.GetValue(random.Next(values.Length));
            return RandomLocation;
            //tarkista soundi
        }
    }
    class Grandma: Human
    {
    private string name = "Riitta";
    private int speed = 15;
    //private int luck;
    public void Hurt()
    {
        Console.WriteLine("Auts!");
    }
    public int Shoot()
    {
        Console.WriteLine("Mummo ampui sinua!");
        return -25;
    }
    public void CallPolice()
    {
        Console.WriteLine("Ammuit mummoa, poliisit heittivät sinut putkaan.");
    }
    //private string weapon = "nyrkki";
    //private string prey = "ankka";
    //private int weaponStrength = 10;
    //private int accuracy = 15;
    }
    class Hunter: Human
    {
    private string name = "Esko";
    private int speed = 25;
    //private int luck;
    public void Hurt()
    {
        Console.WriteLine("Urgh!");
    }
    
    private string weapon = "haulikko";
    private string prey = "peura";
    private int weaponStrength = 50;
    private int accuracy = 50;
    }
    class Deer : Animal
    {
        public void Hurt()
        {
            Console.Beep();
            Console.WriteLine("Möö!");
        }
        public int Kick()
        {
            Console.WriteLine("Peura potkaisee sinua. Jatkat matkaasi haavoittuneena");
            return -10;
        }
    }
    class Duck : Animal
    {
        public void Hurt()
        {
            Console.Beep();
            Console.WriteLine("Kääk!");
        }
        public int Heristys()
        {
            Console.WriteLine("Ankka heristää sinulle nyrkkiään ja katoaa näkyvistä");
            return -5;
        }
    }
    class Reindeer : Animal
    {
        public void Hurt()
        {
            Console.Beep();
            Console.WriteLine("Argh!");
        }
        public int Fly()
        {
            Console.WriteLine("Poro väistää ammuksesi ja lentää pois.");
            return -2;
        }
    }
    public class Program 
    {
        static Random rnd = new Random();
        
        public static void Main(string[] args)
        {
            Console.WriteLine("\nTervetuloa pelaamaan metsästäjä peliä!\n");
            Hunter metsastaja = new Hunter();
            Grandma mummo0 = new Grandma();

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
                            metsastaja.GetWeaponStrength();
                            metsastaja.GetAccuracy();
                            metsastaja.GetSpeed();
                            GameLoop(metsastaja, mummo0);
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
        static void GameLoop(Hunter metsastaja, Grandma mummo0)
        {
            do
            {
                Deer deer0 = new Deer();
                Duck duck0 = new Duck();
                Reindeer poro0 = new Reindeer();

                int preylocation;
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

                    if(suunta<=3)
                    {
                        DoBattle(saalis, preylocation, suunta, deer0, duck0, mummo0, poro0);
                    }
                    else if(suunta == 4)
                    {
                        Console.Beep();
                        Console.WriteLine("Ammuit itseäsi jalkaan! Onko nyt hyvä?");
                        return metsastaja.speed = -15;
                    }
                    else
                    {
                        Console.Beep();
                        Console.WriteLine("Ammuit taivaalle! Minnehän luoti osuu?");
                        return poro0.accuracy -15;
                    }
                }
            }
            while (Again());
        }
        public bool DoBattle(string saalis, string animal, int preylocation, int suunta, Deer deer0, Duck duck0, Grandma mummo0, Reindeer poro0)
        {
            if(preylocation == suunta)
            {
                BattlePrey(saalis, deer0, duck0, mummo0, poro0);
                return true;
            }
            else
            {
                BattleOther(saalis);
                return false;
            }
        }

        public void BattlePrey(string saalis, Deer deer0, Duck duck0, Grandma mummo0, Reindeer poro0)
        {
            switch(saalis)
            {
                case "peura":
                    deer0.Kick();
                    break;
                case "ankka":
                    duck0.Heristys();
                    break;
                case "mummo":
                    mummo0.Shoot();
                    break;
                case "poro":
                    poro0.Fly();
                    break;
                default:
                    Console.Beep();
                    break;
            }   
        }
        public void BattleOther(string saalis, Grandma mummo0, Deer deer0, Duck duck0, Reindeer poro0)
        {
            Random random = new Random();
            string animal;

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

            Console.WriteLine($"Ammuit {animal}a!");

            //int tulos = metsastaja.GetAccuracy - {animal}.Luck
            int tulos = 70-50;

            if(tulos < 70)
            {
                Console.WriteLine($"{animal} vain haavottui!");
                AnimalWin(saalis, deer0, duck0, mummo0, poro0);
            }
            else
            {
                Console.WriteLine("Osuit {animal}an!");

                switch(animal)
                {
                    case "peura":
                        Console.Beep();
                        Console.WriteLine("Osuit peuraan! Harmi, ettet ole peurametsällä.");
                        break;
                    case "ankka":
                        Console.Beep();
                        Console.WriteLine("Osuit ankkaan! Harmi, ettet ole ankkametsällä.");
                        break;
                    case "mummo":
                        Console.Beep();
                        Console.WriteLine("Voi ei! Osuit naapurin dementoituneeseen mummoon!");
                        mummo0.CallPolice();
                        break;
                    default:
                        Console.Beep();
                        Console.WriteLine("Osuit poroon! Millä Joulupukki nyt tulee vierailulle?");
                        break;
                }
            }
        }
        public void AnimalWin(string saalis, Character, Human, Animal)
        {
                switch(saalis)
            {
                case "peura":
                    deer0.Kick();
                    break;
                case "ankka":
                    duck0.Heristys();
                    break;
                case "mummo":
                    Human.Shoot();
                    break;
                case "poro":
                    poro0.Fly();
                    break;
                default:
                    Console.Beep();
                break;
            }   
        }
    }
}
