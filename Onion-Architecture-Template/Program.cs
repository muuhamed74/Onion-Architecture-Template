
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Onion_Architecture_Template.Extensions;
using Onion_Architecture_Template.Helpers.Errors;
using Onion_Architecture_Template.Helpers.Mapping;
using Onion_Architecture_Template.MiddleWares;

namespace Onion_Architecture_Template
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            await builder.Services.AddAppServices(builder.Configuration);


            builder.Services.AddAutoMapper(cfg =>{cfg.AddProfile<MappingProfiles>();});


            //for cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
            });



            //for validation error
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(e => e.Value.Errors)
                        .Select(e => e.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });






            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseStaticFiles();
            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
