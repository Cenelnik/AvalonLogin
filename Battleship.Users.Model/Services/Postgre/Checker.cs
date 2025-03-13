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
    public class Checker : IUserCheckable
    {
        private string _connectToDb = "";
        public Checker(string connect) 
        {
            _connectToDb = connect;
        }
        
        public bool CheckPass(UserLogin user)
        {
            using (UserDbContext context = new UserDbContext(_connectToDb))
            { 
                UserDB userDb = context.Users.Where(u => u.Mail == user.Mail).FirstOrDefault();
                if (userDb != null)
                {
                    return userDb.PasswordHash == user.PasswordHash;
                }
                else 
                {
                    //
                }
            }
            return false;
        }

        public string GetToken(UserLogin user)
        {
            throw new NotImplementedException();
        }
    }
}
