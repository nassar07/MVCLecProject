﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Day2Lab.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department Department { get; set; }

        public List<CrsResult> CrsResults { get; set; }

    }
}
