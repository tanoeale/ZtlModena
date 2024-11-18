using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtlModenaModel.Model.Classes;

namespace ZtlModenaService.Services
{
    public class AspNetUserService :BaseService<AspNetUser>
    {
        public AspNetUserService(string connectionString) : base(connectionString) { }

        public async Task<AspNetUser?> GetUserbById(int id)
       => await GetFirstOrDefaultAsync(x => x.Id == id);
        public async Task<AspNetUser?> GetUserbByFiscalCode(string fiscalcode)
       => await GetFirstOrDefaultAsync(x => x.FiscalCode == fiscalcode);

    }
}
