using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParabolicFunction.Models
{
    public class Point
    {
        public int Id { get; set; }
        public int ChartID { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }
        public UserData UserData { get; set; }
    }
}
