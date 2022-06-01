using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hesh
{
    class Data
    {

        int series;
        public string Name { get; protected set; }
        public string Phone { get; protected set; }
        public string DateOfBirthday { get; protected set; }

        public Data(int series, string name, string phone, string bdate)
        {
            this.series = series;
            this.Name = name;
            this.Phone = phone;
            this.DateOfBirthday = bdate;
        }
    }
}
