using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ImageList.Models
{
    public class ImageView
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
        public int Size { get; set; }
        public string CreationDate { get; set; }

        public string Extension { get; set; }
        [Key]
        public Guid GUID { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
