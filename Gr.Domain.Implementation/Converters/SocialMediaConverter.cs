using System.Collections.Generic;
using System.Linq;
using Entity = Gr.Data.Entities;

namespace Gr.Domain.Implementation.Converters
{
    public static class SocialMediaConverter
    {
        public static Entity.SocialMedia ToEntity(this Model.SocialMedia model)
        {
            return new Entity.SocialMedia
            {
                SocialMediaAccount = model.SocialMediaAccount,
                SocialMediaType = model.SocialMediaType
            };
        }

        public static IEnumerable<Entity.SocialMedia> ToEntity(this IEnumerable<Model.SocialMedia> models)
        {
            return models.Select(model => model.ToEntity());
        }

        public static Model.SocialMedia ToModel(this Entity.SocialMedia entity)
        {
            return new Model.SocialMedia
            {
                SocialMediaAccount = entity.SocialMediaAccount,
                SocialMediaType = entity.SocialMediaType
            };
        }

        public static IEnumerable<Model.SocialMedia> ToModel(this IEnumerable<Entity.SocialMedia> entities)
        {
            return entities.Select(entity => entity.ToModel());
        }
    }
}
