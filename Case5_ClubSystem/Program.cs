
using Case5_ClubSystem.AppDbContext;
using Case5_ClubSystem.Repos.Implementation;
using Case5_ClubSystem.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Case5_ClubSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<ClubDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            builder.Services.AddScoped<IMemberRepository, MemberRepo>();
            builder.Services.AddScoped<IFacilityRepository, FacilityRepo>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepo>();
            builder.Services.AddScoped<IBookingRepository, BookingRepo>();
            builder.Services.AddScoped<IMembershipRepository, MembershipRepo>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
