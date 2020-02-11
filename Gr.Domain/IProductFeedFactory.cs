using Gr.Enums;

namespace Gr.Domain
{
    public interface IProductFeedFactory
    {
        IImportProductFeedService GetProductFeedFileTypeService(ProductFeedType productFeedType);
    }
}
