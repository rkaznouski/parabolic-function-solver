using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParabolicFunction.Models
{
    public class EFPointRepository : IPointRepository
    {
        private ApplicationDbContext context;
        public EFPointRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Point> Points => context.Points;
    }

    public class EFDataRepository : IUserDataRepositoty
    {
        private ApplicationDbContext context;
        private EFDataRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<UserData> UserDatas => context.UserDatas; 
    }
}
