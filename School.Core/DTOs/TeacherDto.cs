﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.DTOs
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public int Status { get; set; }
    }
}
