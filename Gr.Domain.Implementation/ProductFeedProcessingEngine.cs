using System;
using Gr.Enums;

namespace Gr.Domain.Implementation
{
    public class ProductFeedProcessingEngine : IProductFeedProcessingEngine
    {
        private readonly IProductFeedFactory _productFeedFactory;

        public ProductFeedProcessingEngine(IProductFeedFactory productFeedFactory)
        {
            _productFeedFactory = productFeedFactory ?? throw new ArgumentNullException(nameof(productFeedFactory));
        }

        public void ImportProductFeed(ProductFeedType productFeedType)
        {
            Console.WriteLine($"\nImporting {productFeedType}...\n");

            var _productFeedService = _productFeedFactory.GetProductFeedFileTypeService(productFeedType);

            if (_productFeedService.ValidateSource())
            {
                if (_productFeedService.ValidateContent())
                {
                    var products = _productFeedService.ParseContent();
                    _productFeedService.SaveContent(products);
                    Console.WriteLine($"\n{productFeedType} product feed has been parsed successfuly.\n");
                    Console.WriteLine($"****************************************************\n\n");
                }
                else
                    Console.WriteLine($"\nSource content for {productFeedType} product feed is not in valid format, Please verify it and try again\n");
            }
            else
                Console.WriteLine($"\nSource file for {productFeedType} product feed is not valid, Please verify it and try again\n");
        }
    }
}
