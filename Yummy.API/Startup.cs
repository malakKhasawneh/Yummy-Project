using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yummy.Core.Common;
using Yummy.Core.Repository;
using Yummy.Core.Services;
using Yummy.Infra.Common;
using Yummy.Infra.Repository;
using Yummy.Infra.Services;

namespace Yummy.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(y =>
            {
                y.RequireHttpsMetadata = false;
                y.SaveToken = true;
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]")),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };

            });
            services.AddScoped<IJwtUserAuthService, JwtUserAuthService>();

            services.AddScoped<IDBContext, DBContext>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IMasterCardRepository, MasterCardRepository>(); 
            services.AddScoped<IMealRepository, MealRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IOrder_MealRepository, Order_MealRepository>();
            services.AddScoped<IRestaurantCategoryRepository, RestaurantCategoryRepository>();
            services.AddScoped<IRestaurantEmployeeRepository, RestaurantEmployeeRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();


            services.AddScoped<ICartServices, CartServices>();
            services.AddScoped<ICustomerServices, CustomerServices>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped<IMasterCardServices, MasterCardServices>();
            services.AddScoped<IMealServices, MealServices>();
            services.AddScoped<IMenuServices, MenuServices>();
            services.AddScoped<IOfferServices, OfferServices>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IPaymentServices, PaymentServices>();
            services.AddScoped<IOrder_MealServices, Order_MealServices>();
            services.AddScoped<IRestaurantCategoryServices, RestaurantCategoryServices>();
            services.AddScoped<IRestaurantEmployeeServices, RestaurantEmployeeServices>();
            services.AddScoped<IRestaurantServices, RestaurantServices>();
            services.AddScoped<IReviewServices, ReviewServices>();
            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<ITestimonialServices, TestimonialServices>();





            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
