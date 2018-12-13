using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catacombs_of_Bool
{
    public interface IItems
    {
        // Interface for items, applies to the abstract base class which makes it affect all subclasses.
        string name { get; set; }
        string description { get; set; }
    }
}
