using System.Collections.Generic;
using Gr.Model;

namespace Gr.Domain
{
    public interface IImportProductFeedService
    {
        bool ValidateSource();
        bool ValidateContent();
        IEnumerable<Product> ParseContent();
        void SaveContent(IEnumerable<Product> products);
    }
}
