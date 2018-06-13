using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;
using GR.Service;
using GR.Repository.Interface;
using GR.Repository;
using Student.Data;
using Student.Repository;
using Student.Repository.Interface;
using Student.Service.Interface;
using FluentValidation;
namespace Student.Service
{
    public class StudentGeneralService : EntityService<StudentGeneral, StudentGeneralViewModel, StudentGeneralModel>, IStudentGeneralService
    {

        public StudentGeneralService(IUnitOfWork unitOfWork,  IEntityReadStudentGeneralRepository  readRepository, IEntityStudentGeneralRepository repository, ILoggerFactory loggerFactory, IStringLocalizerFactory localizerFactory, IValidator<StudentGeneralModel> validator ) : base(unitOfWork, readRepository, repository, loggerFactory, localizerFactory, validator)
        {
        }
        

    }



}
