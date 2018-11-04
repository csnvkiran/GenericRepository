using System;
using System.Collections.Generic;
using System.Text;
using GR.Repository;
using Student.Repository.Interface;
using Student.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;

namespace Student.Repository
{
    
     public class EntityReadStudentAddressRepository : EntityRepository<StudentAddress, StudentDBContext>, IEntityReadStudentAddressRepository
    {
        public EntityReadStudentAddressRepository(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }

    public class EntityStudentAddressRepository : EntityRepository<StudentAddress, StudentDBContext>, IEntityStudentAddressRepository
    {
        public EntityStudentAddressRepository(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }
}
