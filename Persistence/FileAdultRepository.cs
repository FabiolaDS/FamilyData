using System;
using System.Collections.Generic;
using System.Linq;
using FamilyData.Data;

namespace FamilyData.Persistence
{
    public class FileAdultRepository : IAdultRepository
    {

        private FileContext context;

        public FileAdultRepository(FileContext context)
        {
            this.context = context;
        }

        public List<Adult> GetAll()
        {
            return context.Adults;
        }

        public void Save(Adult a)
        {
            a.Id = (context.Adults.Count == 0) ? 1 : context.Adults.Last().Id + 1;    // ternary operator: <expression> ? <if-true> : <if-false>
            context.Adults.Add(a);
            
            context.SaveChanges();
        }

        public void Update(Adult a)
        {
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            for (int i = 0; i < context.Adults.Count; i++)
            {
                if (context.Adults[i].Id == id)
                {
                    context.Adults.RemoveAt(i);
                    
                    context.SaveChanges();
                    
                    return;
                }
            }

            throw new ArgumentException();
        }

        public Adult GetAdult(int id)
        {
            return context.Adults.Find(a => a.Id == id);
            
        }

        public List<Adult> FindByNameContains(string str)
        {
            return context.Adults.FindAll(
                a => $"{a.FirstName} {a.LastName}".ToLower().Contains(str.ToLower()));
        }
    }
}