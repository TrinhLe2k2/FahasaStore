using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.Entities;

namespace FahasaStoreAPI.Services.Interfaces
{
    public interface ITopicService : IBaseService<Topic, TopicDto, int>
    {
    }
}
