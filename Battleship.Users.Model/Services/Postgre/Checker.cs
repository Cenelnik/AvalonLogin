using Battleship.Users.Common.DTO;
using Battleship.Users.Common.IServices;
using Battleship.Users.Model.Data.Postgre;
using Microsoft.EntityFrameworkCore;
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
        
        public async Task<bool> CheckPass(UserLogin user)
        {
            try
            {
                using (UserDbContext context = new UserDbContext(_connectToDb))
                {
                    UserDB userDb = await context.Users.Where(u => u.Mail == user.Mail).FirstOrDefaultAsync();
                    if (userDb != null)
                    {
                        return userDb.PasswordHash == user.PasswordHash;
                    }
                    else
                    {
                        //
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<string> GetToken(UserLogin user)
        {
            throw new NotImplementedException();
        }
    }
}
