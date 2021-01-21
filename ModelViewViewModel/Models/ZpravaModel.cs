using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViewViewModel.Models
{
    public class ZpravaModel
    {
        static ZpravaModel instance = null;

        // Singleton design pattern
        private ZpravaModel()
        {
            VsechnyZpravy = new List<string>();
        }

        public static ZpravaModel ZpravaDatabase
        {
            // Lazy model - až někdo bude potřebovat databázi zpráv,
            // tak se vytvoří, ale ne dřív!
            get
            {
                if(instance == null)
                {
                    instance = new ZpravaModel();
                }
                
                return instance;
            }
        }

        public List<string> VsechnyZpravy;
    }
}
