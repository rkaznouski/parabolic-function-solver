using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParabolicFunction.Models
{
    public class FakePointRepository : IPointRepository
    {
        public IQueryable<Point> Points => new List<Point>
        {
            new Point { ChartID = 1, PointX = 3, PointY = 9},
            new Point { ChartID = 2, PointX = 4, PointY = 16},
            new Point { ChartID = 3, PointX = 5, PointY = 25}
        }.AsQueryable<Point>();
    }

    public class FakeUserDataRepository : IUserDataRepositoty
    {
        public IQueryable<UserData> UserDatas => new List<UserData>
        {
            new UserData {  A = 2, B = 4, C = 15 },
            new UserData { A = 4, B = 5, C = 8 },
            new UserData { A = 6, B = 78, C = 5 }
        }.AsQueryable<UserData>();
    }
}
