using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBradio
{
    class Hivas
    {
        public TimeSpan OraPerc { get; set; }
        public int AdasDB { get; set; }
        public string Nev { get; set; }
        public int IdoPercben => (int)OraPerc.TotalMinutes;

        public Hivas(string r)
        {
            var v = r.Split(';');
            OraPerc = new TimeSpan(
                hours: int.Parse(v[0]),
                minutes: int.Parse(v[1]),
                seconds: 0);
            AdasDB = int.Parse(v[2]);
            Nev = v[3];
        }
    }
}
