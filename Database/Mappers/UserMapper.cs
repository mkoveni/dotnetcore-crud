using AutoMapper;
using example_app.Database.Models;
using example_app.Database.Resources;
using System.Linq;

namespace example_app.Database.Mappers
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<Role, RoleResource>();
            CreateMap<User, UserResource>()
                .ForMember(ur => ur.Name, opt => opt.MapFrom(u => u.Name))
                .ForMember(ur => ur.Email, opt => opt.MapFrom(u => u.Email))
                .ForMember(ur => ur.Password, opt => opt.MapFrom(u => u.Password))
                .ForMember(ur => ur.RoleId, opt => opt.MapFrom(u => u.RoleId))
                .ForMember(ur => ur.Role, opt => opt.MapFrom(u => u.Role));



            //Resource to Model
            CreateMap<UserResource, User>()
                .ForMember(u => u.Name, opt => opt.MapFrom( ur => ur.Name))
                .ForMember(u => u.Email, opt => opt.MapFrom( ur => ur.Email))
                .ForMember(u => u.Password, opt => opt.MapFrom( ur => ur.Password))
                .ForMember(u => u.RoleId, opt => opt.MapFrom(ur => ur.RoleId));          
        }
    }
}