using System;
using System.Collections.Generic;
using System.Text;
using Student.Repository;
using GR.Service.Interface;
using Student.Data;

namespace Student.Service.Interface
{
   public interface IStudentGeneralServiceAsync : IEntityServiceAsync<StudentGeneral>, IModelServiceAsync<StudentGeneral>, IEntityServiceCUDAsync<StudentGeneral, StudentGeneralModel>
    {
        //IEnumerable<StudentGeneralResponse> GetAll();

        //IEnumerable<StudentGeneralResponse> GetBy();

        //StudentGeneralResponse GetByID();

    }
}
