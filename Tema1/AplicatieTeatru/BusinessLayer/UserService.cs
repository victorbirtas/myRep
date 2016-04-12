using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class UserService
    {
        UsersDAO user = new UsersDAO();

        public String getRole(String username,String password)
        {
            String role = user.getUser(username, password);
            return role;
        }

        public void creareContAngajat(String nume,String username,String password)
        {
            user.insertAngajat(nume, username, password,"angajat");
        }

       
        public void resetPassword(String username,String newPassword)
        {
            user.resetPassword(username,newPassword);
        }

    }
}
