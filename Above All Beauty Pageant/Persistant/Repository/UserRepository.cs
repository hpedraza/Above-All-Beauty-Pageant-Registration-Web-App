using Above_All_Beauty_Pageant.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Above_All_Beauty_Pageant.Persistant.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AboveAllContext _context;
        public UserRepository(AboveAllContext db)
        {
            _context = db;
        }

        public string GetUsersFullName(string userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            return string.Format("{0} {1}",user.FirstName,user.LastName);
        }
    }
}