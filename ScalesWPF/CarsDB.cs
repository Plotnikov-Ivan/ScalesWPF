using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScalesWPF
{
    public class CarsDB
    {
        public void AddCar(Cars item) 
        {
            using (InitDB db = new InitDB())
            {
                db.Cars.Add(item);
                db.SaveChanges();
            }
        }

        public List<Cars> GetAllCars() 
        {
            using (InitDB db = new InitDB())
            {
                return db.Cars.ToList();
            }
        }

        public void ChangeCar(string Num, int new_BRUTTO, int new_ContW, int new_NETTO, DateTime ContDate, DateTime new_BRUTTODate) 
        {                                                            
            using (InitDB db = new InitDB())                 
            {
                Cars cr = db.Cars.FirstOrDefault(c => c.Num == Num && c.ContainerDate == ContDate.ToUniversalTime());
                if (cr != null)
                    {
                        cr.BRUTTO= new_BRUTTO;
                        cr.ContainerWeight=new_ContW;
                        cr.NETTO   = new_NETTO;
                        cr.BRUTTODate =new_BRUTTODate;
                        db.SaveChanges();
                    }
            }
        }
    }
}
