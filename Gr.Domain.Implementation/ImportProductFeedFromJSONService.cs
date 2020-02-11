using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Gr.Data;
using Gr.Enums;
using Gr.Exceptions;
using Gr.Model;

namespace Gr.Domain.Implementation
{
    public class ImportProductFeedFromJSONService : IImportProductFeedService
    {
        private readonly IProductRepository _productRepository;
        private readonly string _fileSource;
        public ImportProductFeedFromJSONService(Func<SupportedDataBaseType, IProductRepository> productRepository)
        {
            //// SupportedDataBaseType should have taken from configuration file as Current Database Type
            _productRepository = productRepository(SupportedDataBaseType.MySql) ?? throw new ArgumentNullException(nameof(IProductRepository));
            
            //// File path should be taken from Configuration
            _fileSource = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\feed-products\softwareadvice.json"));
        }

        public bool ValidateSource()
        {
            var result = false;
            if (File.Exists(_fileSource))
            {
                result = true;
            }
            return result;
        }

        public bool ValidateContent()
        {
            var isValid = false;
            try
            {
                JObject productFeedJSON = JObject.Parse(File.ReadAllText(_fileSource));

                string myschemaJson = @"{
                'description': 'Product Feed', 'type': 'object',
                'properties':
                    {
                       'products': {'type': 'array'},
                       'categories': {'type': 'array'},
                       'twitter': {'type': 'string'},
                       'title': {'type': 'string'}
                    }
                }";

                JSchema schema = JSchema.Parse(myschemaJson);
                isValid = productFeedJSON.IsValid(schema);
            }
            catch (InvalidJSONSchemaException ex)
            {
                Console.WriteLine($"Exception occured while parsing JSON. Exception: {ex}");
            }
            return isValid;
        }

        public IEnumerable<Product> ParseContent()
        {
            JObject productFeedJSON = JObject.Parse(File.ReadAllText(_fileSource));
            return Converters.ProductConverter.ToModel(productFeedJSON);
        }

        public void SaveContent(IEnumerable<Product> products)
        {
            //DB operation by calling _productRepository
        }
    }
}
