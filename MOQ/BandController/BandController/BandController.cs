using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandController
{
    public class BandController
    {
        IRepository repository; 
        public BandController(IRepository repository)
        {
            this.repository = repository; 
        }

        public bool IsIndianBand()
        {
            var bands = repository.GetBandsFromDB();
            foreach (Band band in bands) {
                if (band.Location == "Bangalore" || band.Location == "Mumbai")
                {
                    Console.WriteLine("True");
                    return true; 
                }  else
                {
                    Console.WriteLine("False");
                    return false; 
                }
            }
        } 

    }
}
