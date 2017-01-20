using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicApi.Models
{
    public class TimeCard
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Hours { get; set; }
    }
}