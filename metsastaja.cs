/* Title: Metsästäjä
 * Authors: Sari Tolonen ja Marja Tuhkanen
*/

using System;
using System.Media;
//  using System.Threading;

namespace metsastaja_harkka
{
    abstract class Character
    {
        protected string name = "Esko";
        protected int speed = 20;
        protected int luck = 20;
        protected int hurt = -10;

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
        public int GetHurt()
        {
            Console.WriteLine($"Sinuun sattui.");
            return hurt;
        }
    }
    abstract class Human : Character
    {
        //NAME from character
        //SPEED from character
        //LUCK from character
        //HURT from character
        protected string weapon = "haulikko";
        protected string prey = "peura";
        protected int weaponStrength = 50;
        protected int accuracy = 25;
        protected const string shoot = "Bang";

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
                    prey = "poro";
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
        public string GetShoot()
        {
            if (weapon == "halikko" && OperatingSystem.IsWindows())
            {
                SoundPlayer Noises = new SoundPlayer("haulikko.wav");
                Noises.Load();
                Noises.Play();
            }
            else if (weapon == "jousipyssy" && OperatingSystem.IsWindows())
            {
                SoundPlayer Noises = new SoundPlayer("nuoli.wav");
                Noises.Load();
                Noises.Play();
            }
            Console.WriteLine("Ammuit aseella");
            return shoot;
        }
    }
    abstract class Animal: Character
    {
        //NAME from character
        //SPEED from character
        //LUCK from character
        //HURT from character
        private int RandomLocation;

        public int GetRandomLocation()
        {
            Random rnd = new Random();
            RandomLocation = rnd.Next(3);
            return RandomLocation;
        }
    }
    class Grandma: Human
    {
        //string NAME from character
        //int SPEED from character
        //int LUCK from character
        //int HURT from character
        //string WEAPON from human
        //string PREY from human
        //int WEAPONSTRENGTH from human
        //int ACCURACY from human
        //string SHOOT from human

        public void MummoHurt()
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer Noises = new SoundPlayer("mummo.wav");
                Noises.Load();
                Noises.Play();
            }
            Console.WriteLine("Auts!");
        }
    
        public void Ampu()
        {
            Console.WriteLine(Human.shoot + "Mummo ampui sinua!");
        }
        public void CallPolice()
        {
            Console.WriteLine("Mummo soitti poliisille! \nPoliisit heittivät sinut putkaan.");
        }
    }
    class Hunter: Human
    {
        //string NAME from character
        //int SPEED from character
        //int LUCK from character
        //int HURT from character
        //string WEAPON from human
        //string PREY from human
        //int WEAPONSTRENGTH from human
        //int ACCURACY from human
        //string SHOOT from human

        public void MetsastajaHurt()
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer Noises = new SoundPlayer("hunter.wav");
                Noises.Load();
                Noises.Play();
            }
            Console.WriteLine("Urgh!");
        }
    }
    class Deer : Animal
    {
        //string NAME from character
        //int SPEED from character
        //int LUCK from character
        //int HURT from character
        //int RandomLocation;

        public void DeerHurt()
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer Noises = new SoundPlayer("peura.wav");
                Noises.Load();
                Noises.Play();
            }
            Console.WriteLine("Möö!");
        }
        public void Kick()
        {
            Console.WriteLine("Peura potkaisee sinua. Jatkat matkaasi haavoittuneena");
        }
        public void Hide()
        {
            Console.WriteLine("Et osunut ja peura juoksi piiloon");
        }
    }
    class Duck : Animal
    {
        //string NAME from character
        //int SPEED from character
        //int LUCK from character
        //int HURT from character
        //int RandomLocation;

        public void DuckHurt()
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer Noises = new SoundPlayer("ankka.wav");
                Noises.Load();
                Noises.Play();
            }
            Console.WriteLine("Kääk!");
        }
        public void Heristys()
        {
            Console.WriteLine("Ankka heristää sinulle nyrkkiään ja lentää sitten sinua päin ennen kuin katoaa.");
        }
        public void Swim()
        {
            Console.WriteLine("Ankka hyppää lampeen ja ui karkuun.");
        }
    }
    class Reindeer : Animal
    {
        //string NAME from character
        //int SPEED from character
        //int LUCK from character
        //int HURT from character
        //int RandomLocation;

        public void ReindeerHurt()
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer Noises = new SoundPlayer("poro.wav");
                Noises.Load();
                Noises.Play();
            }
            Console.WriteLine("Argh!");
        }
        public void Fly()
        {
            Console.WriteLine("Poro väistää ammuksesi ja lentää pois.");
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
                Console.WriteLine($"Valitsit {rounds} kilometriä.");
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
                    else if(saalis == "ankka")
                    {
                        preylocation = duck0.GetRandomLocation();
                    }
                    else
                    {
                        preylocation = poro0.GetRandomLocation();
                    }

                    Console.WriteLine($"Olet lähtenyt {saalis} metsälle. Kuljet pitkin pientä polkua. ");
                    Console.WriteLine($"Pohjoisessa sijaitsee vuori, jonka suunnalta kuuluu vuoripuron solina. ");
                    if (OperatingSystem.IsWindows())
                    {
                        SoundPlayer Noises = new SoundPlayer("puro.wav");
                        Noises.Load();
                        Noises.Play();
                    }
                    Console.Write($"Jatka kulkua");
                    Console.ReadLine();
                    Console.WriteLine($"Lännessa näet niityn, josta on kuultavissa leppoisa tuulevire, joka heiluttaa hellästi kukkasia.");
                    if (OperatingSystem.IsWindows())
                    {
                        SoundPlayer Noises = new SoundPlayer("tuuli.wav");
                        Noises.Load();
                        Noises.Play();
                    }
                    Console.Write($"Jatka kulkua");
                    Console.ReadLine();
                    Console.WriteLine($"Idässä näet tuoretta kuusimetsää, josta välillä kuuluu kuusitiasen sirputus. ");
                    if (OperatingSystem.IsWindows())
                    {
                        SoundPlayer Noises = new SoundPlayer("kuusitiainen.wav");
                        Noises.Load();
                        Noises.Play();
                    }
                    Console.Write($"Jatka kulkua");
                    Console.ReadLine();
                    Console.WriteLine($"Kuulet äänen.");
                    if (preylocation == 1 && OperatingSystem.IsWindows())
                    {
                        SoundPlayer Noises = new SoundPlayer("kuusitiainen.wav");
                        Noises.Load();
                        Noises.Play();
                    }
                    else if (preylocation == 2 && OperatingSystem.IsWindows())
                    {
                        SoundPlayer Noises = new SoundPlayer("tuuli.wav");
                        Noises.Load();
                        Noises.Play();
                    }
                    else if (preylocation == 3 && OperatingSystem.IsWindows())
                    {
                        SoundPlayer Noises = new SoundPlayer("puro.wav");
                        Noises.Load();
                        Noises.Play();
                    }
                    else
                    {
                        Console.Beep();
                    }
                    Console.ReadKey();
                    Console.WriteLine($"Se on {saalis}. Et osaa sanoa miltä suunnalta ääni tulee. Mihin suuntaan ammut?");

                    Console.WriteLine("Länsi (1), Pohjoinen (2), Itä (3) tai Alas (4).");
                    Console.ReadKey();
                    int.TryParse(Console.ReadLine(), out int suunta);
                    metsastaja.GetShoot();

                    if(suunta<=3)
                    {
                        if(preylocation == suunta)
                        {
                            //int tulos = metsastaja.GetAccuracy - {animal}.Luck
                            int tulos = 70-50;

                            if(tulos < 70)
                            {
                                Console.WriteLine($"{saalis} vain haavoittui!");
                                int actions = rnd.Next(2);
                                

                                switch(saalis)
                                {
                                    case "peura":
                                        deer0.DeerHurt();
                                        if(actions == 1)
                                        {
                                            deer0.Kick();
                                        }
                                        else
                                        {
                                            deer0.Hide();
                                        }
                                        break;
                                    case "ankka":
                                        duck0.DuckHurt();
                                        if(actions == 1)
                                        {
                                            duck0.Heristys();
                                        }
                                        else
                                        {
                                            duck0.Swim();
                                        }
                                        break;
                                    default:
                                        poro0.ReindeerHurt();
                                        poro0.Fly();
                                        break;
                                }
                            Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine($"Osuit {saalis}an!");

                                switch(saalis)
                                {
                                    case "peura":
                                        deer0.DeerHurt();
                                        Console.WriteLine($"Osuit {saalis}an! Mahtavaa!");
                                        break;
                                    case "ankka":
                                        duck0.DuckHurt();
                                        Console.WriteLine($"Osuit {saalis}an! Mahtavaa!");
                                        break;
                                    default:
                                        poro0.ReindeerHurt();
                                        Console.WriteLine($"Osuit {saalis}an! Mahtavaa!");
                                        break;
                                }
                            Console.ReadKey();
                            }
                        }
                        else
                        {
                            string animal;

                            if(saalis == "peura")
                            {
                                string[] osuttuelain = new string[]{"ankka", "mummo", "poro",};
                                animal = osuttuelain[rnd.Next(osuttuelain.Length)];
                            }
                            else if (saalis == "ankka")
                            {
                                string[] osuttuelain = new string[]{"peura", "mummo", "poro",};
                                animal = osuttuelain[rnd.Next(osuttuelain.Length)];
                            }
                            else
                            {
                                string[] osuttuelain = new string[]{"peura", "mummo", "ankka",};
                                animal = osuttuelain[rnd.Next(osuttuelain.Length)];
                            }

                            Console.WriteLine($"Ammuit {animal}a!");

                            //int tulos = metsastaja.GetAccuracy - {animal}.Luck
                            int tulos = 70-50;

                            if(tulos < 70)
                            {
                                Console.WriteLine($"{animal} vain haavoittui!");
                                int actions = rnd.Next(2);

                                switch(animal)
                                {
                                    case "peura":
                                        deer0.DeerHurt();
                                        if(actions == 1)
                                        {
                                            deer0.Kick();
                                        }
                                        else
                                        {
                                            deer0.Hide();
                                        }
                                        break;
                                    case "ankka":
                                        duck0.DuckHurt();
                                        if(actions == 1)
                                        {
                                            duck0.Heristys();
                                        }
                                        else
                                        {
                                            duck0.Swim();
                                        }
                                        break;
                                    case "poro":
                                        poro0.ReindeerHurt();
                                        poro0.Fly();
                                        break;
                                    default:
                                        mummo0.MummoHurt();
                                        if(actions == 1)
                                        {
                                            mummo0.GetShoot();
                                            mummo0.Ampu();
                                        }
                                        else
                                        {
                                            mummo0.CallPolice();
                                        }
                                        break;
                                }
                            Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Osuit {animal}an!");

                                switch(animal)
                                {
                                    case "peura":
                                        deer0.DeerHurt();
                                        Console.WriteLine("Osuit peuraan! Harmi, ettet ole peurametsällä.");
                                        break;
                                    case "ankka":
                                        duck0.DuckHurt();
                                        Console.WriteLine("Osuit ankkaan! Harmi, ettet ole ankkametsällä.");
                                        break;
                                    case "mummo":
                                        mummo0.MummoHurt();
                                        Console.WriteLine("Voi ei! Osuit naapurin dementoituneeseen mummoon!");
                                        mummo0.CallPolice();
                                        break;
                                    default:
                                        poro0.ReindeerHurt();
                                        Console.WriteLine("Osuit poroon! Millä Joulupukki nyt tulee vierailulle?");
                                        break;
                                }
                            Console.ReadKey();
                            }  
                        }
                    }
                    else if(suunta == 4)
                    {
                        metsastaja.MetsastajaHurt();
                        Console.WriteLine("Ammuit itseäsi jalkaan! Onko nyt hyvä?");
                        Console.ReadKey();
                    }
                    else
                    {
                        if (OperatingSystem.IsWindows())
                        {
                            SoundPlayer Noises = new SoundPlayer("tuuli.wav");
                            Noises.Load();
                            Noises.Play();
                        }
                        Console.WriteLine("Ammuit taivaalle! Minnehän luoti osuu?");
                        Console.ReadKey();
                    }
                }
            }
            while (Again());
        }
    }
}
