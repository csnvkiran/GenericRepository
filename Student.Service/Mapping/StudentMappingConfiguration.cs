using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Student.Service.Mapping
{
    public class AutoMapperConfiguration
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ClientMappingProfile>();
            });
            return config;
        }
    }
}
