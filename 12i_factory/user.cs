using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12i_factory
{
    public class user
    {
        public static List<user> users = new List<user>();
        public string username { get; set; }
        public string password { get; set; }
        public int points { get; set; }
        public int id { get; set; }
        public user(string username, string password, int points, int id) {
            this.username = username;
            this.password = password;
            this.points = points;
            this.id = id;
            users.Add(this);
        }
    }
}
