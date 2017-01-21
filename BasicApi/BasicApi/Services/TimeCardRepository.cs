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
            TimeCard card = new TimeCard();
            var currentData = ((TimeCard[])ctx.Cache[CacheKey]).ToList();
            //var currentDataEmployee = ((Employee[])ctx.Cache[CacheKey]).ToList();
            currentData.Add(card);
            ctx.Cache[CacheKey] = currentData.ToArray();
        }
        public TimeCard[] GetTimeCards(string id)
        {
            var ctx = HttpContext.Current;
            var currentData = ((TimeCard[])ctx.Cache[CacheKey]).ToList();
            return currentData.FindAll(x => x.Id == id).ToArray();
        }
    }
}