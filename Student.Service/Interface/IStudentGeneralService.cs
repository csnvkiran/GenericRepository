using System;
using System.Collections.Generic;
using System.Text;
using Student.Repository;
using Student.Data;
using GR.Service.Interface;

namespace Student.Service.Interface
{
   public interface IStudentGeneralService : IEntityService<StudentGeneral>, IModelService<StudentGeneral>, IEntityServiceAED<StudentGeneral, StudentGeneralModel>
    {

    }
}
