using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FamilyData.Data
{
    public class Job
    {
        [Key] public string JobTitle { get; set; }
        public int Salary { get; set; }
    }
}