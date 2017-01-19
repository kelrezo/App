using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
namespace BasicApi
{
 
    public class Entity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Dead { get; set; }
    }
}