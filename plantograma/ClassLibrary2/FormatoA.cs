using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FormatoA
    {
        public double width { get; set; }
        public double height { get; set; }
        public FormatoA(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public double getArea()
        {
            return width * height;
        }
    }
}
