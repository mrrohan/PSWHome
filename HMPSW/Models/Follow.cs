using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMPSW.Models
{
    public class Follow
    {
        private int followed;
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        public int Followed
        {
            get { return followed; }
            set { followed = value; }
        }


        private int follower;

        public int Follower
        {
            get { return follower; }
            set { follower = value; }
        }

        public virtual Person Person { get; set; }
    }
}