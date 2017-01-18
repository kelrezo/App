using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicApi.Models
{
    [Serializable]
    public class Entity
    {
        private readonly string name;
        private readonly int age;
        private readonly bool dead;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
        }

        public bool Dead
        {
            get
            {
                return dead;
            }
        }
    }
}