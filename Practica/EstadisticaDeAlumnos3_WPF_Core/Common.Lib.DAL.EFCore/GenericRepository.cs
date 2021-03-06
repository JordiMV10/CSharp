﻿using Common.Lib.Context.Interfaces;
using Common.Lib.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Lib.DAL.EFCore
{
    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        private readonly ProjectDbContext _dbContext;
        public GenericRepository(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual SaveResult<T> Add(T entity)
        {
            var output = new SaveResult<T>();

            if (entity.Id != default)
                throw new Exception("la entidad ya tiene id");

            entity.Id = Guid.NewGuid();
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            output.IsSuccess = true;
            output.Entity = entity;

            return output;
        }

        public T Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> QueryAll()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public SaveResult<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
}
