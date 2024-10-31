using AutoMapper;
using Movie_API.Models;

namespace Movie_API
{
    public class MappingConfiguration:Profile
    {
        public MappingConfiguration()
        {
            CreateMap<AllModels, MovieDetail>();
            CreateMap<AllModels, Actor>();

        }
    }
}
