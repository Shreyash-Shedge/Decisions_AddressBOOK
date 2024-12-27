using AddressBook.ORM.Interfaces;
using AddressBook.ORM.OrmLayer;

namespace AddressBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();

            // Database layer
            builder.Services.AddScoped<IDbHelper, DbHelper>();
            builder.Services.AddScoped<IPhoneDbHelper, PhoneDbHelper>();
            builder.Services.AddScoped<IEmailDbHelper, EmailDbHelper>();
            builder.Services.AddScoped<IGenericHelper, GenericHelper>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle'
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
