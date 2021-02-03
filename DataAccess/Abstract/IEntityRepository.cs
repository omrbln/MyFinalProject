﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic canstraint - jenerik kısıt
    //class : referans tip
    //IEntity : IEntity olabilir veya IEntity implemete eden bir nesne olabilir
    // new() : new'lenebilir olmalı (IEntity new'lenemez olduğu için onu devre dışı bıraktık)
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter );
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}