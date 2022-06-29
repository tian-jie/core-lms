using CoreLMS.Core.Interfaces;
using CoreLMS.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLMS.Web.Areas.Admin.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly IAuthorService authorService;

        public IndexModel(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        public IList<AuthorViewModel> Authors { get;set; }

        public async Task OnGetAsync()
        {

        }
    }

    
}
