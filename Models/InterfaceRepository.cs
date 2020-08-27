using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParabolicFunction.Models
{
    public interface IPointRepository 
    {
        IQueryable<Point> Points { get; }
    }

    public interface IUserDataRepositoty
    {
        IQueryable<UserData> UserDatas { get; }
    }
}
