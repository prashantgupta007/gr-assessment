using System;
using System.Collections.Generic;
using Gr.Data;
using Gr.Enums;
using Gr.Model;

namespace Gr.Domain.Implementation
{
    public class ImportProductFeedFromCSVService : IImportProductFeedService
    {
        private readonly IProductRepository _productRepository;
        private readonly string _fileSource;
        public ImportProductFeedFromCSVService(Func<SupportedDataBaseType, IProductRepository> productRepository)
        {
            //// SupportedDataBaseType should have taken from configuration file as Current Database Type
            _productRepository = productRepository(SupportedDataBaseType.MySql) ?? throw new ArgumentNullException(nameof(IProductRepository));

            //// File path should be taken from Configuration
            _fileSource = "https://someurl/feed-product/products.csv";
        }

        public bool ValidateSource()
        {
            //Validate file source through http client
            throw new System.NotImplementedException();
        }

        public bool ValidateContent()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> ParseContent()
        {
            throw new System.NotImplementedException();
        }

        public void SaveContent(IEnumerable<Product> products)
        {
            throw new System.NotImplementedException();
        }
    }
}
