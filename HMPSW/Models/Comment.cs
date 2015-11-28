using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMPSW.Models
{
    public class Comment
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        private string comment_text;

        public string Comment_text
        {
            get { return comment_text; }
            set { comment_text = value; }
        }

        public virtual Post Post { get; set; }
        public virtual ApplicationUser Person { get; set; }
    }
}