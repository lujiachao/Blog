using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Model
{
    [Table("Casevideo")]
    public class Casevideo : BaseModel
    {
        public DateTime CreateDate
        {
            set;
            get;
        }

        public string Img
        {
            set;
            get;
        }

        public string Url
        {
            set;
            get;
        }

        public string Body
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public int Showdefault
        {
            get;
            set;
        }

        public int Visitnum
        {
            get; set;
        }

        public double Price
        {
            get; set;
        }

        public string Keyword
        {
            get; set;
        }

        public string Descn
        {
            get; set;
        }

        public string Remark
        {
            get; set;
        }
        public int Xsnum
        {
            set;
            get;
        }

        public double Sort
        {
            set;
            get;
        }
    }
}
