using System.ComponentModel.DataAnnotations;

namespace AngularMVC.Models
{
    public class MyImage
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public byte[] Image { get; set; }
    }
}