using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtlModenaModel.Model.Classes;

namespace ZtlModenaService.Services
{
    public class SpecialContractsCustomerService : BaseService<XpkSpecialContractsCustomer>
    {
        public SpecialContractsCustomerService(string connectionString) : base(connectionString) { }

        public async Task<List<string>> GetSubScriptionTypeByCutomerId(int idCustomer)
        {
            List<XpkSpecialContractsCustomer> sub = await GetAsync(x => x.Equals(idCustomer));
            return sub.Select(x=> x.IdSubscriptionType.ToString()).ToList();
        }

    }
}
