using MyBlog.Web.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Web.MiddleWare
{
    public class MyblogException : Exception
    {
        public EnumMyblogException EnumiTPSEx
        {
            get;
        }

        private int _code;

        public int Code
        {
            get
            {
                if (_code > 0)
                {
                    return _code;
                }
                return (int)EnumiTPSEx;
            }
        }

        public MyblogException(int Code, string message) : base(message)
        {
            _code = Code;
        }

        public MyblogException(EnumMyblogException enumiTPSEx) : base(enumiTPSEx.ToString())
        {
            EnumiTPSEx = enumiTPSEx;
        }

        public MyblogException(EnumMyblogException enumiTPSEx, string message) : base(message)
        {
            EnumiTPSEx = enumiTPSEx;
        }

        public MyblogException(EnumMyblogException enumiTPSEx, Exception ex) : base(enumiTPSEx.ToString(), ex)
        {
            EnumiTPSEx = enumiTPSEx;
        }

        public MyblogException(EnumMyblogException enumiTPSEx, string message, Exception ex) : base(message, ex)
        {
            EnumiTPSEx = enumiTPSEx;
        }

        public override string ToString()
        {
            return $"[Code={Code}][Message={Message}][InnerMessage={(InnerException == null ? string.Empty : InnerException.Message)}]";
        }
    }
}
