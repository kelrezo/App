using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicApi.Models;

namespace BasicApi.Services
{
    public class EntityRepository
    {
        private const string CacheKey = "EntityStore";
        private int count;
        public EntityRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var contacts = new Entity[]
                    {
                        new Entity
                        {
                            Id = 1, Name = "Glenn Block"
                        },
                        new Entity
                        {
                            Id = 2, Name = "Dan Roth"
                        }
                    };
                    ctx.Cache[CacheKey] = contacts;
                }
            }
        }
        public Entity[] GetAllEntities()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Entity[])ctx.Cache[CacheKey];
            }

            return new Entity[]
            {
                new Entity
                {
                    Id = 0,
                    Name = "Placeholder"
                }
            };
        }
        public bool SaveContact(Entity entity)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Entity[])ctx.Cache[CacheKey]).ToList();
                    entity.Id = currentData.Count+1;
                    currentData.Add(entity);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }

        public bool RemoveEntity(int id)
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                try
                {
                    var currentData = ((Entity[])ctx.Cache[CacheKey]).ToList();
                
                    Entity obj = currentData.Find(x=> x.Id ==id);
                    currentData.Remove(obj);
                    ctx.Cache[CacheKey] = currentData.ToArray();
                    return true;                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                    
                }
            }
            return false;

        }
        public static bool FindEntity(Entity obj, int id)
        {
            return obj.Id == id;
        }
    }
}