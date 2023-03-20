using AutoMapper;
using ChatAppBackend.API.Models;
using ChatAppBackend.Data.Entities;

namespace ChatAppBackend.API.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<DbMessage, MessageV1>();

        CreateMap<DbChannel, ChannelV1>();
    }
}
