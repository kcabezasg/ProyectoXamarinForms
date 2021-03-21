using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppWMS.Models
{
   public class UserModel : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserModel()
        {
        }
    
    }
}
