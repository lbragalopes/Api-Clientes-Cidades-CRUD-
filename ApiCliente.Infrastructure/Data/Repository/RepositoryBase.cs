using ApiCliente.Core.Interface.Repository;
using ApiCliente.Infrastructure.Data.Repository.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCliente.Infrastructure.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext sqlContext;

        public RepositoryBase(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public void Add(TEntity obj)
        {
            try
            {
                sqlContext.Set<TEntity>().Add(obj);
                sqlContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual TEntity GetById(int id)
        {
            return sqlContext.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return sqlContext.Set<TEntity>().ToList();
        }

        public virtual void Update(TEntity obj)
        {

            try
            {
                sqlContext.Entry(obj).State = EntityState.Modified;
                sqlContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual void Remove(TEntity obj)
        {
            try
            {
                sqlContext.Set<TEntity>().Remove(obj);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}