using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentileClient.JSON_Template_Classes
{
    class CosmeticsObject
    {
        public string pack_id { get; set; }
        public string subpack { get; set; }
        public int[] version { get; set; }
    }
}
