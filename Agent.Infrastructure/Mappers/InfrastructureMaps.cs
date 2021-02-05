using Agent.Core.Dtos;
using AutoMapper;
using OnePay.TransactionApi.Dtos;

namespace Agent.Infrastructure.Mappers
{
    public class InfrastructureMaps : Profile
    {
        public InfrastructureMaps()
        {
            CreateMap<InquiryDetail, InquiryDetailDto>().ReverseMap();
        }
    }
}
