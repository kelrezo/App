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
    }
}