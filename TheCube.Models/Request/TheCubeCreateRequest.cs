using System.ComponentModel.DataAnnotations;

namespace TheCube.Models.Request
{
    public class TheCubeCreateRequest
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Results { get; set; }
    }
}
