using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaProject.Models
{
    public class Mood
    {
        [Display(Name = "Настрій")]
        public int id { get; set; }
        [Display(Name = "Настрій")]
        public string moodName { get; set; }
        [Display(Name = "Настрій")]
        public string moodPicture { get; set; }

        public virtual ICollection<Note> Notes { get; set; }
    }
}
