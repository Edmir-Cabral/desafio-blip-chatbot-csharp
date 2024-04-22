using AutoMapper;
using DesafioBlipAPI.Controllers.Response;
using DesafioBlipAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DesafioBlipAPI.Controllers.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GitHubBlipRepositorioCSharp, GitHubBlipRepositorioCSharpResponse>()
                .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.Owner.AvatarUrl));
        }
    }
}
