using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCube.Models.Domain
{
    public class CubeDomain
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string text { get; set; }
        public int DisplayOrder { get; set; }
        public string Answer { get; set; }
        public string Result { get; set; }
        public string Type { get; set; }

    }
}
