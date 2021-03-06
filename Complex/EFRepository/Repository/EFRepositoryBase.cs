﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Linq.Expressions;
using System.Data.Entity.Core;
using Complex.Repository.Utility;

namespace Complex.Repository
{
    public abstract class EFRepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity :Complex.Entity.EntityBase 
    {
        private DbContextTransaction _dbContextTransaction = null;
        public EntitytoData EF ;
      
         public EFRepositoryBase()
         {
             EF = new EntitytoData();
         }
         public EFRepositoryBase(string connstr)
         { 
             EF = new EntitytoData(connstr);
         }
         public void ChangeDatabase(string connstr)
         { 
             EF = new EntitytoData(connstr); 
         }
        public DbSet<TEntity> Entities
        {
            get { return EF.Set<TEntity>(); }
        }
        public void OpenTransaction()
        { 
           this._dbContextTransaction = EF.Database.BeginTransaction();
        }
        public void Commit()
        {
            if ( this._dbContextTransaction.UnderlyingTransaction.Connection != null )
            {
                this._dbContextTransaction.Commit();
            }
        }
        public void Rollback()
        {
            if ( this._dbContextTransaction.UnderlyingTransaction.Connection != null )
            { 
                this._dbContextTransaction.Rollback();
            }
        }
        public int Insert(TEntity entity)
        { 
            Entities.Add(entity);
            return EF.SaveChanges();
        }

        public int Insert(IEnumerable<TEntity> entities)
        {
            Entities.AddRange(entities);
            return EF.SaveChanges();
        }
        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.AsNoTracking().Where(predicate);
        }
        public IQueryable<TEntity> GetAllNoCache()
        {
            return Entities.AsNoTracking().AsQueryable();
        }
        public IQueryable<TEntity> GetAll()
        {
            return Entities;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
        //  //  EF.Entry(entity).State = EntityState.Modified;
        //    var Tentity = GetByKey(key);
        ////   Tentity = TObject;

        //    var entry = EF.Entry(Tentity);
        //    EF.Set<TEntity>().Attach(TObject);
        //    entry.State = EntityState.Modified; 
            return EF.SaveChanges();
        }


        //key删除
        public int DeleteByKey(object id)
        {
            ///删除操作实现 
            Entities.Remove(GetByKey(id));
            return EF.SaveChanges();
        }
        //key
        public TEntity GetByKey(object key)
        { 
            return Entities.Find(key);
        }
        ////id
        //public TEntity GetById(int key)
        //{ 
        //    return Entities.Single(e => e.Id.Equals(key)); 
        //}
        ////id
        //public int DeleteById(int id)
        //{
        //    ///删除操作实现 
        //    Entities.Remove(GetById(id));
        //    return EF.SaveChanges();
        //}
        /// <summary>
        /// 分页 基本无法万能适用
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="page"></param>
        /// <param name="page_size"></param>
        /// <returns></returns>
        public List<TEntity> SearchFor_Page<TKey>(Expression<Func<TEntity, bool>> predicate, int page, int page_size, Expression<Func<TEntity, TKey>> order, bool asc)
        {
            if (asc)
            {
                return Entities.Where(predicate).OrderBy(order).Skip((page - 1) * page_size).Take(page_size).ToList();
            }
            else
            {
                return Entities.Where(predicate).OrderByDescending(order).Skip((page - 1) * page_size).Take(page_size).ToList();
            }
            
        }


        /// <summary>
        /// 分页  
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="page"></param>
        /// <param name="page_size"></param>
        /// <returns></returns>
        public List<TEntity> SearchSqLFor_Page(string predicate, int page, int page_size, string order, string asc,out int total)
        {
            string Sql = string.Empty;
            string SqlCount = string.Empty;
            if ( EF.Database.Connection.ToString().StartsWith("System.Data.SqlClient") )
            {
                Sql = string.Format(" SELECT TOP {0}  * FROM ( SELECT *, row_number() OVER (ORDER BY {1} {2}) AS [row_number]   FROM [dbo].[{5}] AS [Extent1]  where IsDelete='False' and {3} )  AS [Extent1]    WHERE [Extent1].[row_number] > {4}   ORDER BY [Extent1].{1} {2}", page_size, order.Replace("'", "''"), asc.Replace("'", "''"), predicate, ( page - 1 ) * page_size, typeof(TEntity).Name);
                //SqlCount = string.Format(" select COUNT(1) from {0} where {1}", typeof(T).Name, predicate);
                SqlCount = string.Format(" select COUNT(1) from {0} where IsDelete='False' and {1}", typeof(TEntity).Name, predicate);
            }
            else if ( EF.Database.Connection.ToString().StartsWith("Oracle.ManagedDataAccess.Client") )
            {
                Sql ="";
                throw new Exception("目前未实现");
            }
             List<TEntity> list =new List<TEntity>();
             try
             {
                 total = EF.Database.SqlQuery<int>(SqlCount).FirstOrDefault();
                 list = EF.Database.SqlQuery<TEntity>(Sql).ToList();
             }
             catch ( Exception )
             {
                 total = 0; 
             } 
             return list;
             
        }

        /// <summary>
        /// 分页 基本无法万能适用
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="page"></param>
        /// <param name="page_size"></param>
        /// <returns></returns>
        public List<TEntity> SearchFor_Page<TKey>(int page, int page_size, Expression<Func<TEntity, TKey>> order, bool asc)
        {
            if (asc)
            {
                return Entities.OrderBy(order).Skip((page - 1) * page_size).Take(page_size).ToList();
            }
            else
            {
                return Entities.OrderByDescending(order).Skip((page - 1) * page_size).Take(page_size).ToList();
            }
        }
        //public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector);
        //public static IOrderedQueryable<TSource> OrderByDescending<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(TEntity entities)
        {

            if ( EF == null ) throw new ArgumentNullException("dbContext");
            if ( entities == null ) throw new ArgumentNullException("entities");


            DbSet<TEntity> dbSet = EF.Set<TEntity>();
            try
            {
                System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> entry = EF.Entry(entities);
                if ( entry.State == EntityState.Detached )
                {
                    dbSet.Attach(entities);
                    entry.State = EntityState.Modified;
                }
            }
            catch ( InvalidOperationException )
            {

                TEntity oldEntity = dbSet.Find(entities.ID);
                EF.Entry(oldEntity).CurrentValues.SetValues(entities);
            }
            return SaveChanges();
        }


        public int Update(object Id, TEntity entities)  
        {
            if (EF == null) throw new ArgumentNullException("dbContext");
            if (entities == null) throw new ArgumentNullException("entities");


            DbSet<TEntity> dbSet = EF.Set<TEntity>();
            try
            {
                System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> entry = EF.Entry(entities);
                if (entry.State == EntityState.Detached)
                {
                    dbSet.Attach(entities);
                    entry.State = EntityState.Modified;
                }
            }
            catch (InvalidOperationException)
            {
                TEntity oldEntity = dbSet.Find(Id);
                EF.Entry(oldEntity).CurrentValues.SetValues(entities);
               
            }
           return SaveChanges();

        }






















        public int Insert<TEntity1>(TEntity1 entity) where TEntity1 : class
        {
            EF.Set<TEntity1>().Add(entity);
            return EF.SaveChanges();
        }


        public int Insert<TEntity1>(IEnumerable<TEntity1> entities) where TEntity1 : class
        {
            EF.Set<TEntity1>().AddRange(entities);
            return EF.SaveChanges();
        }




        public IQueryable<TEntity1> SearchFor<TEntity1>(Expression<Func<TEntity1, bool>> predicate) where TEntity1 : class
        {
            return EF.Set<TEntity1>().AsNoTracking().Where(predicate);
        }





        public IQueryable<TEntity1> GetAllNoCache<TEntity1>() where TEntity1 : class
        {
            return EF.Set<TEntity1>().AsNoTracking().AsQueryable();
        }



        public IQueryable<TEntity1> GetAll<TEntity1>() where TEntity1 : class
        {
            return EF.Set<TEntity1>();
        }
 



        //key删除
        public int DeleteByKey<TEntity1>(object id) where TEntity1 : class
        {
            ///删除操作实现 
            EF.Set<TEntity1>().Remove(GetByKey<TEntity1>(id));
            return EF.SaveChanges();
        }


        public TEntity1 GetByKey<TEntity1>(object key) where TEntity1 : class
        {
            return EF.Set<TEntity1>().Find(key);
        }



        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update<TEntity1>(TEntity1 entities) where TEntity1 : class
        {

            if ( EF == null ) throw new ArgumentNullException("dbContext");
            if ( entities == null ) throw new ArgumentNullException("entities");


            DbSet<TEntity1> dbSet = EF.Set<TEntity1>();
            try
            {
                System.Data.Entity.Infrastructure.DbEntityEntry<TEntity1> entry = EF.Entry(entities);
                if ( entry.State == EntityState.Detached )
                {
                    dbSet.Attach(entities);
                    entry.State = EntityState.Modified;
                }
            }
            catch ( InvalidOperationException e )
            {
                if (   typeof(TEntity1).GetProperties().Where(p => p.Name == "ID").Any() )
                {
                    dynamic dymodel = entities; 
                    TEntity oldEntity = dbSet.Find(dymodel.ID);
                    EF.Entry(oldEntity).CurrentValues.SetValues(entities);
                }
                else
                {
                    throw e;
                }
             

            }
            return SaveChanges();
        }

        /// <summary>
        /// 分页  
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="page"></param>
        /// <param name="page_size"></param>
        /// <returns></returns>
        public List<TEntity1> SearchSqLFor_PageGeneric<TEntity1>(string predicate, int page, int page_size, string order, string asc, out int total) where TEntity1 : class
        {
            string Sql = string.Empty;
            string SqlCount = string.Empty;
            if ( EF.Database.Connection.ToString().StartsWith("System.Data.SqlClient") )
            {
                Sql = string.Format(" SELECT TOP {0}  * FROM ( SELECT *, row_number() OVER (ORDER BY {1} {2}) AS [row_number]   FROM [dbo].[{5}] AS [Extent1]  where IsDelete='False' and {3} )  AS [Extent1]    WHERE [Extent1].[row_number] > {4}   ORDER BY [Extent1].{1} {2}", page_size, order.Replace("'", "''"), asc.Replace("'", "''"), predicate, ( page - 1 ) * page_size, typeof(TEntity1).Name);
                //SqlCount = string.Format(" select COUNT(1) from {0} where {1}", typeof(T).Name, predicate);
                SqlCount = string.Format(" select COUNT(1) from {0} where IsDelete='False' and {1}", typeof(TEntity1).Name, predicate);
            }
            else if ( EF.Database.Connection.ToString().StartsWith("Oracle.ManagedDataAccess.Client") )
            {
                Sql = "";
                throw new Exception("目前未实现");
            }
            List<TEntity1> list = new List<TEntity1>();
            try
            {
                total = EF.Database.SqlQuery<int>(SqlCount).FirstOrDefault();
                list = EF.Database.SqlQuery<TEntity1>(Sql).ToList();
            }
            catch ( Exception )
            {
                total = 0;
            }
            return list;

        }

        public int Update<TEntity1>(object Id, TEntity1 entities) where TEntity1 : class
        {

            if ( EF == null ) throw new ArgumentNullException("dbContext");
            if ( entities == null ) throw new ArgumentNullException("entities");


            DbSet<TEntity1> dbSet = EF.Set<TEntity1>();
            try
            {
                System.Data.Entity.Infrastructure.DbEntityEntry<TEntity1> entry = EF.Entry(entities);
                if ( entry.State == EntityState.Detached )
                {
                    dbSet.Attach(entities);
                    entry.State = EntityState.Modified;
                }
            }
            catch ( InvalidOperationException e )
            {
                TEntity1 oldEntity = dbSet.Find(Id);
                EF.Entry(oldEntity).CurrentValues.SetValues(entities);

            }
            return SaveChanges();

        }


    }
}
