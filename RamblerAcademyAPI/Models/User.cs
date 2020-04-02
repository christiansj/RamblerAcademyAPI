using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

      
        public String Email { get; set; }

        public String Password { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
