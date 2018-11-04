using System;
using System.Collections.Generic;
using System.Text;
using GR.Repository.Interface;
using Student.Repository;

namespace Student.Repository.Interface
{
    public interface IEntityReadStudentIdentityRepositoryAsync : IEntityReadRepositoryAsync<StudentIdentity> { }

    public interface IEntityStudentIdentityRepositoryAsync : IEntityRepositoryAsync<StudentIdentity> { }

}
