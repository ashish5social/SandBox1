using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandController
{
    class Repository : IRepository
    {
        public List<Band> GetBandsFromDB()
        {
            Band band1 = new Band { Name = "ABC", Location = "Bangalore" };
            Band band2 = new Band { Name = "DEF", Location = "Mumbai" };

            List<Band> bands = new List<Band>();
            bands.Add(band1);
            bands.Add(band2);
            return bands; 
        }
    }
}
