using FahasaStore.Models;

namespace FahasaStoreApp.Models.ViewModels
{
    public class HomeLayoutVM
    {
        public PagedVM<CategoryDetail> CategoryPaged { get; set; } = new PagedVM<CategoryDetail>();
        public WebsiteDetail Website { get; set; } = new WebsiteDetail();
        public PagedVM<PlatformExtend> PlatformPaged { get; set; } = new PagedVM<PlatformExtend>();
        public PagedVM<TopicDetail> TopicPaged { get; set; } = new PagedVM<TopicDetail>();
    }
}
