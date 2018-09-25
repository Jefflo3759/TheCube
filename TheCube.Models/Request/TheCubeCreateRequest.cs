using System.ComponentModel.DataAnnotations;

namespace TheCube.Models.Request
{
    public class TheCubeCreateRequest
    {
        [Required]
        public int Size { get; set; }
        [Required]
        public int Color { get; set; }
        [Required]
        public int Float { get; set; }
    }
}
