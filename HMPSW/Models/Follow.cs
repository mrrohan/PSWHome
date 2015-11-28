using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMPSW.Models
{
    public class Follow
    {
        public int ID { get; set; }

        public virtual ApplicationUser PersonFollowed { get; set; }

        public virtual ApplicationUser PersonFollower { get; set; }
    }
}