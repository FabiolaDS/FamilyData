using System.Collections.Generic;
using FamilyData.Data;

namespace FamilyData.Persistence
{
    public interface IAdultRepository
    {
        List<Adult> GetAll();
        Adult GetAdult(int id);

        void Save(Adult a);

        void Update(Adult a);

        void Delete(int id);

        List<Adult> FindByNameContains(string str);
    }
}