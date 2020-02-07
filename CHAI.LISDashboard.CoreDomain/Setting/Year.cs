using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.CoreDomain;

namespace CHAI.LISDashboard.CoreDomain.Setting
{  
    public partial class Year : IEntity
    {
        private int _year = 0;

        public int Id
        {
            get; set;          
        }

        public int YearName { get { return _year; } set { _year = value; } }

    }
}
