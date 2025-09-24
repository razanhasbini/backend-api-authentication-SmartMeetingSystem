using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartMeetingSystem.Application.IRepository;
using SmartMeetingSystem.Infrastructure.Repository;

namespace SmartMeetingSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration _)
        {
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGadgetRepository, GadgetRepository>();
            services.AddScoped<IRoomGadgetRepository, RoomGadgetRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IMomRepository, MomRepository>();
            return services;
        }
    }
}
