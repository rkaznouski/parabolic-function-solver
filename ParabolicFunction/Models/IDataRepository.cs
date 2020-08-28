using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParabolicFunction.Models;

namespace ParabolicFunction.Models
{
    public interface IDataRepository
    {
        UserData GetUserData(int id);
        IEnumerable<UserData> GetAllUserData();
        void Add(UserData userData);
        void Delete(int id);
    }
}
