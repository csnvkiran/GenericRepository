using System;
using System.Collections.Generic;
using System.Text;
using GR.Repository;
using Student.Repository.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;

namespace Student.Repository
{
    
   
    public class EntityReadStudentIdentityRepositoryAsync : EntityRepositoryAsync<StudentIdentity, StudentDBContext>, IEntityReadStudentIdentityRepositoryAsync
    {
        public EntityReadStudentIdentityRepositoryAsync(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }

    public class EntityStudentIdentityRepositoryAsync : EntityRepositoryAsync<StudentIdentity, StudentDBContext>, IEntityStudentIdentityRepositoryAsync
    {
        public EntityStudentIdentityRepositoryAsync(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }
}
