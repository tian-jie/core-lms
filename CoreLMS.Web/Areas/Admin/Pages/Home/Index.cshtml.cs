using CoreLMS.Core.Interfaces;
using CoreLMS.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace CoreLMS.Web.Areas.Admin.Pages.Home
{
    public class IndexModel : PageModel
    {
        private readonly IAuthorService authorService;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

        public IndexModel(IAuthorService authorService, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            this.authorService = authorService;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        public IList<RouteViewModel> Routers { get;set; }


        /// <summary>
        /// 获取路由列表
        /// </summary>
        /// <returns></returns>
        public void OnGetAsync()
        {
            Routers = _actionDescriptorCollectionProvider.ActionDescriptors.Items.Select(x => new RouteViewModel
            {
                Action = x.RouteValues["Action"],
                Controller = x.RouteValues["Controller"],
                Name = x.AttributeRouteInfo.Name,
                Method = x.ActionConstraints?.OfType<HttpMethodActionConstraint>().FirstOrDefault()?.HttpMethods.First(),
                Template = x.AttributeRouteInfo.Template
            }).ToList();        
        }


    }

    
}
