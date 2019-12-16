using System;
using System.Collections.Generic;
using System.Text;
using Common.Domain.Constants;

namespace Common.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    public class DbParamAttribute : Attribute
    {
        public ParamDirection Direction { get; set; }



        public bool Ignore { get; set; }



        public bool ConvertToCommaSeparated { get; set; }
    }
}
