using Battleship.Users.Common.DTO;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Battleship.Users.Model.Data.Postgre
{
    /// <summary>
    /// Для работы с пользователями из БД через EF
    /// </summary>
    [Table("Users")]
    public class UserDB
    {
        [Key]
        [Column("Id")]
        public int ShortID { get; set; }
        [Column("Guid")]
        public Guid Guid { get; set; }
        [Column("UserName")]
        public string Name { get; set; } = "";
        [Column("UserPass")]
        public string PasswordHash { get; set; }
        [Column("Mail")]
        public string Mail { get; set; }
        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }
        [Column("Salt")]
        public int Salt { get; set; }
    }
}
