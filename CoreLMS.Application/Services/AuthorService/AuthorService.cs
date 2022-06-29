using CoreLMS.Core.DataTransferObjects;
using CoreLMS.Core.Entities;
using CoreLMS.Core.Interfaces;
using CoreLMS.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLMS.Application.Services
{
    public partial class AuthorService : BaseService<Author>, IAuthorService
    {   
        public AuthorService(IAppDbContext unitOfWork)
            : base(unitOfWork)
        {
        }



    }
}
