using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Student.Data;
using Student.Repository;

namespace Student.Service.Mapping
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<StudentGeneralModel, StudentGeneral>();
            //.ReverseMap()
        }
    }

}
