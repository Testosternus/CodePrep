using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePrep.Models
{
    public class SlayerBeastVM
    {
        public IEnumerable<ResponseBasic> Beasts { get; set; }
        public int CategoryID { get; set; }
    }
}
