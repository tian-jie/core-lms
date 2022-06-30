using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CoreLMS.Web
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            var ApiName = "WebApi.Core";

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    // {ApiName} 定义成全局变量，方便修改
                    Version = "V1",
                    Title = $"{ApiName} 接口文档——Netcore 6.0",
                    Description = $"{ApiName} HTTP API V1",

                });
                c.OrderActionsBy(o => o.RelativePath);
            });

        }
    }
}
