using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class MainMenuNaive
    {
        readonly List<string> mainAppMenu;

        public MainMenuNaive()
        {
            mainAppMenu = new List<string>(new string[] { "Kleště", "Kladiva", "Pily", "Kovadliny" });
        }

        public void View()
        {
            Console.WriteLine(string.Join(",", mainAppMenu));
        }
    }

    class MainMenu
    {
        static List<string> mainAppMenu;
        static MainMenu singleInstance = null;

        // vylepšení pro thread safe
        private static readonly object lockingObject = new object();

        private MainMenu()
        {
            mainAppMenu = new List<string>(new string[] { "Kleště", "Kladiva", "Pily", "Kovadliny" });
        }

        //Bez locku není "thread safe"
        public static MainMenu Instance 
        {
            get
            {
                // thread safe
                // pokud pojedou 2 vlákna, které by mohly paralelně vytvořit instanci,
                // první uzamkne část vytvoření instance
                // a druhé může pokračovat až po odemknutí locku
                // druhé vlákno už vyhodnotí podmínku jako false
                // a nová instance se nevytvoří
                // Nepříliš efektivní
                lock (lockingObject)
                {
                    if (singleInstance == null)
                    {
                        singleInstance = new MainMenu();
                    }
                }

                return singleInstance;
            }
        }
        public void View()
        {
            Console.WriteLine(string.Join(",", mainAppMenu));
        }
    }
    class Program
    {
        static void Main()
        {
            MainMenuNaive tools1 = new MainMenuNaive();
            tools1.View();

            // Tohle je problém, který chceme vyřešit
            // Ani ten nejhorší programátor by neměl mít šanci 
            // vytvořit 2. hlavní menu, 2. hlavní databázi, 2. superusera atd.:
            MainMenuNaive tools2 = new MainMenuNaive();
            tools2.View();

            if (ReferenceEquals(tools1, tools2) == false)
                Console.WriteLine("V paměti jsou dvě instance MainMenuNaive");
            else
                Console.WriteLine("V paměti je jedna instance MainMenuNaive");

            Console.WriteLine("==================================================");

            // Jakmile se jednou vytvoří MainMenu, už se nezmění.
            // MainMenu je jedinečné a jediné - proto Singleton
            // Protože není přístupný konstruktor, nevolá se 2x new
            MainMenu unique1 = MainMenu.Instance;
            unique1.View();

            // druhá instance se nevytvoří
            MainMenu unique2 = MainMenu.Instance;  
            unique2.View();

            if (ReferenceEquals(unique1, unique2) == false)
                Console.WriteLine("V paměti jsou dvě instance MainMenu");
            else
                Console.WriteLine("V paměti je jedna instance MainMenu");
        }
    }
}
