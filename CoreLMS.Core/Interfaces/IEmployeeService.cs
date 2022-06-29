using CoreLMS.Core.DataTransferObjects;
using CoreLMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreLMS.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task UpdateSharepointPeopleAsync(string date, string sharepointText);


    }
}
