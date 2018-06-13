using System;
using GR.Model;

namespace Student.Model
{
    public class StudentGeneral : Entity
    {
        public decimal StudentId { get; set; }

        public string StudentName { get; set; }

        public decimal Gender { get; set; }
    }
}
