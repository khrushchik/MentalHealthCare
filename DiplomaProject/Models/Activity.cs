using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaProject.Models
{
    public class Activity
    {
        public int id { get; set; }
        [Display(Name = "Активність")]
        public string activityName { get; set; }
        public bool typeActivity { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
