using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestProj.DAL.EF;
using TestProj.DAL.Entities;
using TestProj.DAL.Interfaces;

namespace TestProj.DAL.Repositories
{
    public class OperationRepository : IRepository<Operation>
    {
        private readonly ApplicationContext dbContext;

        public OperationRepository(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Operation GetItem(int id)
        {
            return dbContext.Operations.Find(id);
        }

        public IEnumerable<Operation> GetItemList()
        {
            return dbContext.Operations;
        }

        public Operation Create(Operation model)
        {
            dbContext.Operations.Add(model);
            dbContext.SaveChanges();
            return model;
        }

        public Operation Delete(int id)
        {
            Operation model = GetItem(id);
            if (model != null)
            {
                dbContext.Operations.Remove(model);
                dbContext.SaveChanges();
            }
            return model;
        }

        public Operation Update(Operation modelChanges)
        {
            var model = dbContext.Operations.Attach(modelChanges);
            model.State = EntityState.Modified;
            dbContext.SaveChanges();
            return modelChanges;
        }
    }
}
