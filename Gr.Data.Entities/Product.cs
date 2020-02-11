using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gr.Data.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual SocialMedia SocialMedia { get; set; }
    }
}
