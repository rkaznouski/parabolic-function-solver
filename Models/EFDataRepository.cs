using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ParabolicFunction.Models
{
    public class EFDataRepository : IDataRepository
    {   
        private ApplicationDbContext context;

        public EFDataRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public UserData GetUserData(int id)
        {
            return context.UserDatas.Find(id);
        }
        public IEnumerable<UserData> GetAllUserData()
        {
            return context.UserDatas;
        }
        public void Add(UserData userData)
        {
            userData.Id = 0;
            context.UserDatas.Add(userData);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.UserDatas.Remove(new UserData { Id = id });
        }
    }
}
