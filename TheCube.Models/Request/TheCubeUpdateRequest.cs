using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCube.Models.Request
{
    public class TheCubeUpdateRequest : TheCubeCreateRequest
    {

        [Required]
        public int Id { get; set; }
 
    }
}
