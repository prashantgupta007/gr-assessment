using System;
using Microsoft.Extensions.DependencyInjection;
using Gr.Enums;

namespace Gr.Domain.Implementation
{
    public class ProductFeedFactory : IProductFeedFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public ProductFeedFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IImportProductFeedService GetProductFeedFileTypeService(ProductFeedType productFeedType)
        {
            if (productFeedType == ProductFeedType.JSON)
            {
                return _serviceProvider.GetService<ImportProductFeedFromJSONService>();
            }
            else if (productFeedType == ProductFeedType.YAML)
            {
                return _serviceProvider.GetService<ImportProductFeedFromYAMLService>();
            }
            else
            {
                Console.WriteLine($"{productFeedType} product feed service is not implemented");
                throw new Exceptions.InvalidProductFeedProcessingEngineException($"{productFeedType} product feed service is not implemented");
            }
        }
    }
}
