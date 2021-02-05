using Agent.Core.Dtos;
using Agent.Core.Entities;
using Agent.Web.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agent.Web.Mappers
{
    public class AutomapperMaps : Profile
    {
        public AutomapperMaps()
        {
            CreateMap<Catalogue, CatalogueViewModel>().ReverseMap();
            CreateMap<Book, BookViewModel>().ReverseMap();
        }
    }
}
