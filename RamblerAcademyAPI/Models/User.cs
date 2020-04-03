using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RamblerAcademyAPI.Models
{
    public class User
    {
        public User(string id, string firstName, string lastName, string email, string password, int roleId)
        {
            SetId(id);
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            RoleId = roleId;
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

      
        public string Email { get; set; }

        public string Password { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }


        private void SetId(string id)
        {
            if (id.Length != 6)
            {
                throw new System.FormatException("Invalid User Id Length");
            }

            byte[] asciiBytes = Encoding.ASCII.GetBytes(id);
            for (int i = 0; i < 3; i++)
            {
                IdAsciiCheck(asciiBytes[i], 97, 122);
            }

            for (int i = 3; i < asciiBytes.Length; i++)
            {
                IdAsciiCheck(asciiBytes[i], 48, 57);
            }

            Id = id;
        }

        private void IdAsciiCheck(byte b, int min, int max)
        {
            if (b < min || b > max)
            {
                throw new System.FormatException("Invalid User Id");
            }
        }
    }
}
