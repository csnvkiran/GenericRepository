using System;
using System.Collections.Generic;
using System.Text;
using GR.Repository.Interface;
using Student.Repository;

namespace Student.Repository.Interface
{
    public interface IEntityReadStudentAddressRepositoryAsync : IEntityReadRepositoryAsync<StudentAddress> { }

    public interface IEntityStudentAddressRepositoryAsync : IEntityRepositoryAsync<StudentAddress> { }

}
