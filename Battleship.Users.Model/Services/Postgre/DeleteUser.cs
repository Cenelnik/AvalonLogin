using Battleship.Users.Common.DTO;
using Battleship.Users.Common.IServices;
using Battleship.Users.Model.Data.Postgre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Users.Model.Services.Postgre
{
    public class DeleteUser : IOldUserDeletable
    {
        private string _connectToDb = "";
        public DeleteUser( string connect) 
        {
            _connectToDb = connect;
        }
        public bool Exec(UserGame user)
        {
            using (UserDbContext context = new UserDbContext(_connectToDb))
            {
                UserDB userDb = context.Users.Where(u => u.Mail == user.Mail).FirstOrDefault();
                if (userDb != null)
                {
                    context.Users.Remove(userDb);
                    return true;
                }
            }
            return false;
        }
    }
}
