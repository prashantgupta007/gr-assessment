using System.Collections.Generic;
using System.Linq;
using Entity = Gr.Data.Entities;

namespace Gr.Domain.Implementation.Converters
{
    public static class CategoryConverter
    {
        public static Entity.Category ToEntity(this Model.Category model)
        {
            return new Entity.Category
            {
                CategoryName = model.CategoryName
            };
        }

        public static IEnumerable<Entity.Category> ToEntity(this IEnumerable<Model.Category> models)
        {
            return models.Select(model => model.ToEntity());
        }

        public static Model.Category ToModel(this Entity.Category entity)
        {
            return new Model.Category
            {
                CategoryName = entity.CategoryName
            };
        }

        public static IEnumerable<Model.Category> ToModel(this IEnumerable<Entity.Category> entities)
        {
            return entities.Select(entity => entity.ToModel());
        }
    }
}
