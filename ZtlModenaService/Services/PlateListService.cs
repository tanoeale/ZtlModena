using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZtlModenaModel.Model.Classes;

namespace ZtlModenaService.Services
{
    public class PlateListService : BaseService<XpkPlateList>
    {
        public PlateListService(string connectionString) : base(connectionString) { }

        public async Task<List<XpkPlateList>> GetPlateListByUserEnte(List<string> idSubscriptionType)
        {
            return await GetAsync(x => x.ExportToList != null && x.TypeCode != null && x.ExportToList.Equals("1") && idSubscriptionType.Contains(x.TypeCode));
        }
    }
}
