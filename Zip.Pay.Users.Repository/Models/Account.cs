
using Zip.Pay.Users.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Zip.Pay.Users.Repository.Model
{
    [Table(name: "Account")]
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Credit { get; set; }
        public virtual User User { get; set; }
    }
}