using Gr.Enums;
using System.ComponentModel.DataAnnotations;

namespace Gr.Data.Entities
{
    public class SocialMedia
    {
        [Key]
        public string SocialMediaAccount { get; set; }
        [Required]
        public SocialMediaType SocialMediaType { get; set; }
    }
}
