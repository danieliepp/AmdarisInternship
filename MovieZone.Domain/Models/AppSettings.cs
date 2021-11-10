using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieZone.Domain.Models
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExipreDays { get; set; }
    }
}
