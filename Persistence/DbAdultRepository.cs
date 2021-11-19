using System.Collections.Generic;
using System.Linq;
using FamilyData.Data;
using Microsoft.EntityFrameworkCore;

namespace FamilyData.Persistence
{
    public class DbAdultRepository: IAdultRepository
    {
        private AdultDbContext dbContext;

        public DbAdultRepository(AdultDbContext adultDbContext)
        {
            dbContext = adultDbContext;
        }

        public List<Adult> GetAll()
        {
            return dbContext.Adults.ToList();
        }

        public Adult GetAdult(int id)
        {
            return dbContext.Adults.First(a => a.Id==id);
        }

        public void Save(Adult a)
        {

            dbContext.Adults.Add(a);
            dbContext.SaveChanges();

        }

        public void Update(Adult a)
        {
            dbContext.Adults.Update(a);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            dbContext.Adults.Remove(GetAdult(id));
            dbContext.SaveChanges();
        }

        public List<Adult> FindByNameContains(string str)
        {
            return dbContext.Adults.ToList().FindAll(
                a => $"{a.FirstName} {a.LastName}".ToLower().Contains(str.ToLower()));
        }
    }
}