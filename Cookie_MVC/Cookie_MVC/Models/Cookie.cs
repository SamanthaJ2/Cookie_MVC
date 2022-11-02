using System.Drawing;
using System.Xml.Linq;

namespace Cookie_MVC.Models
{
    public class Cookie
    {
        // properties
        public int? Id { get; set; }
        public string Name { get; set; } // Name of cookie
        public string Flavor { get; set; } // Flavor of cookie
        public int Quantity { get; set; } // Qty of dozens

        public Cookie(int? id, string name, string flavor, int qty)
        {
            Id = id; 
            Name = name;
            Flavor = flavor;
            Quantity = qty;
        }

        public Cookie()
        {
            return;
        }
    }
}
