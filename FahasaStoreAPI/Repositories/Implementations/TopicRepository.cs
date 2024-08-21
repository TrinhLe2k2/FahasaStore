using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Repositories.Interfaces;

namespace FahasaStoreAPI.Repositories.Implementations
{
    public class TopicRepository : BaseRepository<Topic, int>, ITopicRepository
    {
        public TopicRepository(FahasaStoreDBContext context) : base(context)
        {
        }
    }
}
