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
    
     public class EntityReadStudentContactRepository : EntityRepository<StudentContact, StudentDBContext>, IEntityReadStudentContactRepository
    {
        public EntityReadStudentContactRepository(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }

    public class EntityStudentContactRepository : EntityRepository<StudentContact, StudentDBContext>, IEntityStudentContactRepository
    {
        public EntityStudentContactRepository(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }
}
