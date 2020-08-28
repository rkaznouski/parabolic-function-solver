using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParabolicFunction.Models
{
    public class Point
    {
        public int Id { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }

        public int ChartId { get; set; }    //foreign key
        public UserData Chart { get; set; }  //navi prop
    }
}
