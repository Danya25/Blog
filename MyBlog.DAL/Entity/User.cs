using System.Collections.Generic;

namespace MyBlog.DAL.Entity
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

    }
}
