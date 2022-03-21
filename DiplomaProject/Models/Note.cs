using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomaProject.Models
{
    public class Note
    {
        public int id { get; set; }
        [Display(Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime noteDate { get; set; }
        [Display(Name = "Настрій")]
        public int moodId { get; set; }
        [Display(Name = "Вагоме заняття протягом дня")]
        public int activityId { get; set; }
        [Display(Name = "Плани на наступний день")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string plans { get; set; }
        [Display(Name = "Чи були виконані минулі плани")]
        public bool plansDone { get; set; }
        [Display(Name = "Думки протягом дня")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string thoughts { get; set; }

        [Display(Name = "Email")]
        [ForeignKey("User")]
        public string userId { get; set; }

        [Display(Name = "Користувач")]
        public virtual User User { get; set; }
        [Display(Name = "Настрій")]
        public virtual Mood Mood { get; set; }
        [Display(Name = "Вагоме заняття протягом дня")]
        public virtual Activity Activity { get; set; }
    }
}
