﻿using CMS_Backend.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS_Backend.Models
{
    public class StudentInfo
    {
        [Key]
        public int id { get; set; }

        public string? std_unique_id { get; set; }
        public string? std_father_name { get; set; }
        public string? std_mother_name { get; set; }
        public DateTime? std_date_of_birth { get; set; }
        public EnumHelper.Gender Gender { get; set; }

        [Column(TypeName = "TEXT")]
        public string? std_residential_address { get; set; }

        [Column(TypeName = "TEXT")]
        public string? std_permanent_address { get; set; }

        public EnumHelper.Status addmission_status { get; set; } = EnumHelper.Status.Pending;
        //public int? collegeId { get; set; }
        public int? user_id { get; set; }
        public int? course_id { get; set; }

        //[ForeignKey("collegeId")]
        //public College? College { get; set; }

        [ForeignKey("user_id")]
        public User? user { get; set; }

        [ForeignKey("course_id")]
        public Course? course { get; set; }
    }
}
