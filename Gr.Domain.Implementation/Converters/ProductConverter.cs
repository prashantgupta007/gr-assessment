using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Entity = Gr.Data.Entities;
using Gr.Enums;

namespace Gr.Domain.Implementation.Converters
{
    public static class ProductConverter
    {
        public static Entity.Product ToEntity(this Model.Product model)
        {
            return new Entity.Product
            {
                Name = model.Name,
                Categories = model.Categories.ToEntity().ToList(),
                SocialMedia = model.SocialMedia.ToEntity()
            };
        }

        public static IEnumerable<Entity.Product> ToEntity(this IEnumerable<Model.Product> models)
        {
            return models.Select(model => model.ToEntity());
        }

        public static Model.Product ToModel(this Entity.Product entity)
        {
            return new Model.Product
            {
                Name = entity.Name,
                Categories = entity.Categories.ToModel(),
                SocialMedia = entity.SocialMedia.ToModel()
            };
        }

        public static IEnumerable<Model.Product> ToModel(this IEnumerable<Entity.Product> entities)
        {
            return entities.Select(entity => entity.ToModel());
        }

        public static IEnumerable<Model.Product> ToModel(JObject jObject)
        {
            var products = new List<Model.Product>();
            foreach (var item in jObject.AsJEnumerable()["products"])
            {
                var product = new Model.Product();
                product.Name = item["title"]?.ToString();
                product.SocialMedia = new Model.SocialMedia { SocialMediaAccount = item["twitter"]?.ToString(), SocialMediaType = SocialMediaType.Twitter };
                product.Categories = item["categories"]?.ToArray().Select(r => new Model.Category { CategoryName = r.ToString() });
            }

            return products;
        }
    }
}
