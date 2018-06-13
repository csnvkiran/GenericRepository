using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Student.Data;

namespace Student.Service.Interface
{
    interface IStudentGenralValidator: IValidator<StudentGeneralModel>
    {
    }
}
