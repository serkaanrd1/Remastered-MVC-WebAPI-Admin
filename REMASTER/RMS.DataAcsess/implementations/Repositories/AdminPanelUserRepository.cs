using Infrastructure.DataAccess.EF;
using RMS.DataAcsess.implementations.EF.Context;
using RMS.DataAcsess.İnterfaces;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.DataAcsess.implementations.Repositories
{
    public class AdminPanelUserRepository : BaseRepository<AdminPanelUser, RemasteredContext>, IAdminPanelUserRepository
    {
        public async Task<AdminPanelUser> GetByUserNameAndPasswordAsync(string userName, string password, params string[] includeList)
        {
            return await GetAsync(x => x.UserName == userName && x.Password == password && x.IsActive.Value, includeList);
        }
    }
}
