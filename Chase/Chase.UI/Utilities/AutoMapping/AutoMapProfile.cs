using System.Threading.Tasks;
using AutoMapper;
using Chase.Entities.DTOs;
using Chase.Entities.Tangible;
using Microsoft.AspNetCore.Identity;

namespace Chase.UI.Utilities.AutoMapping
{
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            //bu işlemin amacı Run olunca hangi nesneleri birbiri ile mapleyecek onu göstermek için.
            CreateMap<DutyDto, Duty>();
            CreateMap<Duty, DutyDto>();
            CreateMap<UrgencyDto, Urgency>();
            CreateMap<Urgency, UrgencyDto>();
            CreateMap<AppUserDto, AppUser>();
            CreateMap<AppUser, AppUserDto>();
            CreateMap<ReportDto, Report>();
            CreateMap<Report, ReportDto>();
            CreateMap<DutyListAllDto, Duty>();
            CreateMap<Duty, DutyListAllDto>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<Report, ReportDto>();
            CreateMap<ReportDto, Report>();
            CreateMap<Declaration, DeclarationListDto>();
            CreateMap<DeclarationListDto, Declaration>();
            CreateMap<Message, MessageDto>();
            CreateMap<MessageDto, Message>();
            CreateMap<IdentityResult, AppUserListDto>();
            CreateMap<AppUserListDto, IdentityResult>();
            CreateMap<IdentityResult, AppUser>();
            CreateMap<AppUser, IdentityResult>();
            
            CreateMap<IdentityUser, AppUserListDto>();
            CreateMap<AppUserListDto, IdentityUser>();

            CreateMap<Task<IdentityResult>, AppUser>();
            CreateMap<AppUser,Task<IdentityResult>>();

            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportUpdateDto>();

        }
    }
}