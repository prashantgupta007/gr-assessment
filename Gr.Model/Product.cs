using System.Collections.Generic;

namespace Gr.Model
{
    public class Product
    {
        public string Name { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public SocialMedia SocialMedia { get; set; }
    }
}
