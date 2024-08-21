using AutoMapper;
using FahasaStoreAPI.Base.Implementations;
using FahasaStoreAPI.Base.Interfaces;
using FahasaStoreAPI.Models.DTOs.Entities;
using FahasaStoreAPI.Models.Entities;
using FahasaStoreAPI.Repositories.Interfaces;
using FahasaStoreAPI.Services.Interfaces;

namespace FahasaStoreAPI.Services.Implementations
{
    public class TopicService : BaseService<Topic, TopicDto, int>, ITopicService
    {
        public TopicService(ITopicRepository repository, IMapper mapper, ICloudinaryService cloudinaryService) : base(repository, mapper, cloudinaryService)
        {
        }
    }
}
