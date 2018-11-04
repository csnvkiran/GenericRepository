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
    
     public class EntityReadStudentIdentityRepository : EntityRepository<StudentIdentity, StudentDBContext>, IEntityReadStudentIdentityRepository
    {
        public EntityReadStudentIdentityRepository(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }

    public class EntityStudentIdentityRepository : EntityRepository<StudentIdentity, StudentDBContext>, IEntityStudentIdentityRepository
    {
        public EntityStudentIdentityRepository(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }
}
