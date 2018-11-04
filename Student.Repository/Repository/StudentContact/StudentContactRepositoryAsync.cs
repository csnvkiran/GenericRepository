using System;
using System.Collections.Generic;
using System.Text;
using GR.Repository;
using Student.Repository.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;

namespace Student.Repository
{
    
   
    public class EntityReadStudentContactRepositoryAsync : EntityRepositoryAsync<StudentContact, StudentDBContext>, IEntityReadStudentContactRepositoryAsync
    {
        public EntityReadStudentContactRepositoryAsync(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }

    public class EntityStudentContactRepositoryAsync : EntityRepositoryAsync<StudentContact, StudentDBContext>, IEntityStudentContactRepositoryAsync
    {
        public EntityStudentContactRepositoryAsync(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }
}
