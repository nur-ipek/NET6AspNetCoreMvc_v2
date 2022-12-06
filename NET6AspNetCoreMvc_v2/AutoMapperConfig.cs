using AutoMapper;
using NET6AspNetCoreMvc_v2.Entities;
using NET6AspNetCoreMvc_v2.Models;

namespace NET6AspNetCoreMvc_v2
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
