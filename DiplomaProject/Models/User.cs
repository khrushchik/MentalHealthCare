using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DiplomaProject.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public virtual string Surname { get; set; }

        public virtual ICollection<Note> Notes { get; set; }

    }
}
