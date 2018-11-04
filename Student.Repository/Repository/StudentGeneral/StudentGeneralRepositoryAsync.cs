using System;
using System.Collections.Generic;
using System.Text;
using GR.Repository;
using Student.Repository.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;

namespace Student.Repository
{
    
    //public class ModelStudentGeneralRepositoryAsync : EntityRepositoryAsync<StudentGeneral, StudentDBContext> //, IModelStudentGeneralRepositoryAsync
    //{
    //    public ModelStudentGeneralRepositoryAsync(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    //}

    public class EntityReadStudentGeneralRepositoryAsync : EntityRepositoryAsync<StudentGeneral, StudentDBContext>, IEntityReadStudentGeneralRepositoryAsync
    {
        public EntityReadStudentGeneralRepositoryAsync(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }

    public class EntityStudentGeneralRepositoryAsync : EntityRepositoryAsync<StudentGeneral, StudentDBContext>, IEntityStudentGeneralRepositoryAsync
    {
        public EntityStudentGeneralRepositoryAsync(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }
}
