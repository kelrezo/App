using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicApi.Models;

namespace BasicApi.Services
{
    public class TimeCardRepository
    {
        private const string CacheKey = "TimeStore";
        public TimeCardRepository()
        {

            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var TimeCards = new TimeCard[]
                    {

                    };
                    ctx.Cache[CacheKey] = TimeCards;
                }
            }
        }

        public void AddTimeCard(string id,float hours)
        {
            var ctx = HttpContext.Current;
            TimeCard card = new TimeCard();
            var currentData = ((TimeCard[])ctx.Cache[CacheKey]).ToList();
            card.Id = id;
            card.Hours = hours;
            card.Date = DateTime.Now;
            currentData.Add(card);
        }
        public TimeCard[] GetTimeCards()
        {
            var ctx = HttpContext.Current;
            var currentData = ((TimeCard[])ctx.Cache[CacheKey]).ToList();
            return currentData.ToArray();
        }
    }
}