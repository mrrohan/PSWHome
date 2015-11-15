using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMPSW.Models
{
    public class Community
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Forum { get; set; }
    }
}