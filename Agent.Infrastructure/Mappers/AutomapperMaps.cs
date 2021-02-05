using Agent.Core.Dtos;
using AutoMapper;
using OnePay.TransactionApi.Dtos;

namespace Agent.Infrastructure.Mappers
{
    public class AutomapperMaps : Profile
    {
        public AutomapperMaps()
        {
            CreateMap<InquiryDetail, InquiryDetailDto>().ReverseMap();
        }
    }
}
