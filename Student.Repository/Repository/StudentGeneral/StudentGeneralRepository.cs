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
    
    //public class ModelStudentGeneralRepository : EntityRepository<StudentGeneral, StudentDBContext> ///, IModelStudentGeneralRepository
    //{
    //    public ModelStudentGeneralRepository(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    //}

    public class EntityReadStudentGeneralRepository : EntityRepository<StudentGeneral, StudentDBContext>, IEntityReadStudentGeneralRepository
    {
        public EntityReadStudentGeneralRepository(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }

    public class EntityStudentGeneralRepository : EntityRepository<StudentGeneral, StudentDBContext>, IEntityStudentGeneralRepository
    {
        public EntityStudentGeneralRepository(StudentDBContext dbcontext, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory) : base(dbcontext, loggerFactory, localizerFactory) { }

    }
}
