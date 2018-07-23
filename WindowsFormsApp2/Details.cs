using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WindowsFormsApp2
{
    public class Details
    {
        
        public string amount { get; set; }
        public string balance { get; set; }
        public string purpose { get; set; }
        public string id { get; set; }
        //public DateTime DOB { get; set; }

        public string GetInfo(int option)
        {
            switch (option)
            {
                case 1:
                    return String.Format("{0}", amount);
                    break;
                case 2:
                    return String.Format("{" + option + "}", balance);
                    break;
                case 3:
                    return String.Format("{" + option + "}", purpose);
                    break;
                case 4:
                    return string.Format("{" + option + "}", id);
                    break;

                default:
                    return string.Format("{" + option + "}", id);
                    break;
            }
            
        }
    }

    
}
