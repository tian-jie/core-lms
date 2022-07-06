using CoreLMS.Core.Interfaces;
using Kevin.T.Clockify.Data.Entities;
using System.Threading.Tasks;

namespace CoreLMS.Application.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IAppDbContext unitOfWork)
            : base(unitOfWork)
        {

        }


        public async Task UpdateSharepointPeopleAsync(string date, string sharepointText)
        {
            //_repository
        }

    }
}
