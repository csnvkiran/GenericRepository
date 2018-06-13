using System;
using System.Collections.Generic;
using System.Text;
using GR.Model;

namespace Student.Repository
{
    public class Gebder : Entity
    {
        public decimal GenderId { get; set; }

        public string GenderCode { get; set; }

        public string GenderDesc { get; set; }

        public string LangType { get; set; }

    }
}
