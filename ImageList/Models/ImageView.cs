using System.ComponentModel.DataAnnotations;

namespace ImageList.Models
{
    public class ImageView
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
        public int Size { get; set; }
        [Timestamp]
        public DateTime CreationDate { get; set; }
        public string Extension { get; set; }
        [Key]
        public Guid GUID { get; set; }
    }
}
