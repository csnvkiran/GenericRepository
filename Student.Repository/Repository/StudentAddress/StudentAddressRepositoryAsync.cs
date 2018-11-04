using System;
using System.Collections.Generic;
using System.Text;
using GR.Repository;
using Student.Repository.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;

namespace Student.Repository
{
    
   
    public class EntityReadStudentAddressRepositoryAsync : EntityRepositoryAsync<StudentAddress, StudentDBContext>, IEntityReadStudentAddressRepositoryAsync
    {
        public EntityReadStudentAddressRepositoryAsync(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }

    public class EntityStudentAddressRepositoryAsync : EntityRepositoryAsync<StudentAddress, StudentDBContext>, IEntityStudentAddressRepositoryAsync
    {
        public EntityStudentAddressRepositoryAsync(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }
}
