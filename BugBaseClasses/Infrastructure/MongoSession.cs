using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Norm;
using Norm.Collections;
using Norm.Linq;
using Norm.Responses;
using BugBaseClasses.Model;


namespace BugBaseClasses.Infrastructure
{
    public class MongoSession<TEntity> : IDisposable
    {
        private readonly MongoQueryProvider provider;

        public MongoSession()
        {
            var mongo = new Mongo("BugBase3", "localhost", "27017", "");
            this.provider = new MongoQueryProvider(mongo);
        }

        public IQueryable<TEntity> Queryable
        {
            get { return new MongoQuery<TEntity>(this.provider); }
        }

        public IQueryable<Bug> Bugs
        {
            get { return new MongoQuery<Bug>(this.provider); }
        }


        public MongoQueryProvider Provider
        {
            get { return this.provider; }
        }

        public void Add<T>(T item) where T : class, new()
        {
            this.provider.DB.GetCollection<T>().Insert(item);
        }

        public void Dispose()
        {
            this.provider.Server.Dispose();
        }
        public void Delete<T>(T item) where T : class, new()
        {
            this.provider.DB.GetCollection<T>().Delete(item);
        }

        public void Drop<T>()
        {
            this.provider.DB.DropCollection(typeof(T).Name);
        }

        public void Save<T>(T item) where T : class,new()
        {
            this.provider.DB.GetCollection<T>().Save(item);
        }


    }   
}