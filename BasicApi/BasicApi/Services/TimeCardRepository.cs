using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicApi.Models;

namespace BasicApi.Services
{
    public class TimeCardRepository
    {
        private const string CacheKey = "TimeCardStorage";
        private const string CacheKeyE = "EntityStorage";
        public TimeCardRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var TimeCards = new TimeCard[]
                    { };
                    ctx.Cache[CacheKey] = TimeCards;
                }
            }
        }

        public void AddTimeCard(TimeCard time)
        {
            var ctx = HttpContext.Current;
            var currentData = ((TimeCard[])ctx.Cache[CacheKey]).ToList();
            currentData.Add(time);
            ctx.Cache[CacheKey] = currentData.ToArray();
        }
        public TimeCard[] GetTimeCards(string id = null)
        {
            var ctx = HttpContext.Current;
            var currentData = ((TimeCard[])ctx.Cache[CacheKey]).ToList();
            if (id == null)
            {
                return currentData.OrderBy(x => x.Date).ToArray();
            }        
            currentData = currentData.FindAll(x => x.Id == id);
            return currentData.OrderBy(x => x.Date).ToArray();
        }
        public void RemoveTimeCards(string id)
        {
            var ctx = HttpContext.Current;
            var currentData = ((TimeCard[])ctx.Cache[CacheKey]).ToList();       
            currentData.RemoveAll(x => x.Id == id);
            ctx.Cache[CacheKey] = currentData.ToArray();
        }
    }
}