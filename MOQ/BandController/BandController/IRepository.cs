using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandController
{
    public interface IRepository
    {
        List<Band> GetBandsFromDB(); 
    }
}
