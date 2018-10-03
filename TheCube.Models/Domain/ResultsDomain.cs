using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCube.Models.Domain
{
    public class ResultsDomain
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Results { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
