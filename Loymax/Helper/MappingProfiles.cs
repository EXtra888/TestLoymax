using AutoMapper;
using Loymax.Models;
using Loymax.Dto;
using TestLoymax.Models;

namespace Loymax.Helper
{
    public class MappingProfiles :  Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<TransactionDto, Transaction>();
            CreateMap<TransactionTypeDto, TransactionType>();
        }

    }
}
