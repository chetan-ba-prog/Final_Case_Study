using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using UserManagement_1.Data;
using UserManagement_1.Repository;

namespace UserManagement_1
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
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddDbContext<SellerDBContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefultConnection")));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddDbContext<CustomerDBContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefultConnection")));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddDbContext<ProductDBContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefultConnection")));

            services.AddScoped<ICartRepository, CartRepository>();
            services.AddDbContext<CartDBContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefultConnection")));

            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddDbContext<OrdersDBContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefultConnection")));

            services.AddScoped<IPaymentsRepository, PaymentsRepository>();
            services.AddDbContext<PaymentsDBContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefultConnection")));

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddDbContext<InvoiceDBContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefultConnection")));

            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddDbContext<RatingDBContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefultConnection")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShoppingCart", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SuperMarket v1"));
            }

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
