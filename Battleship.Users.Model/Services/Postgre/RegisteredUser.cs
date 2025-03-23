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
    public class RegisteredUser : INewUserRegisteredable
    {
        private string _connectToDb = "";
        public RegisteredUser(string connect)
        { 
            _connectToDb = connect;
        }
        public async Task<bool> Exec(UserRegistration newUser)
        {
            using (UserDbContext context = new UserDbContext(_connectToDb))
            {
                try
                {
                    UserDB newUserDB = new UserDB();
                    newUserDB.IsDeleted = false;
                    newUserDB.Salt = 0;
                    newUserDB.Mail = newUser.Email;
                    newUserDB.Name = newUser.Login;
                    newUserDB.PasswordHash = newUser.PasswordHash;
                    newUserDB.Guid = Guid.NewGuid();
                    context.Users.Add(newUserDB);
                    await context.SaveChangesAsync();
                    return true;
                }catch (Exception ex) 
                {
                    return false;
                }
            }
            return false;
        }
    }
}
