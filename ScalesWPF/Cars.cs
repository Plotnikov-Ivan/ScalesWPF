using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalesWPF
{
    public class Cars
    {
        public string Num { get; set; }
        public int BRUTTO { get; set; }
        public int ContainerWeight { get; set; }
        public int NETTO { get; set; }
        public DateTime ContainerDate { get; set; }
        public DateTime BRUTTODate { get; set; }

        public Cars(string new_Num, int new_BRUTTO, int new_ContW, int new_NETTO, DateTime ContDate, DateTime new_BRUTTODate)
        {
            Num = new_Num;
            BRUTTO = new_BRUTTO;
            ContainerWeight = new_ContW;
            NETTO = new_NETTO;
            ContainerDate = ContDate.ToUniversalTime();
            BRUTTODate = new_BRUTTODate.ToUniversalTime();
        }

        public Cars() { }


    }
}
