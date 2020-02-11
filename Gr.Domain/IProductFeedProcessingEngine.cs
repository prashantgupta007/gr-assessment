using Gr.Enums;

namespace Gr.Domain
{
    public interface IProductFeedProcessingEngine
    {
        void ImportProductFeed(ProductFeedType productFeedType);
    }
}
