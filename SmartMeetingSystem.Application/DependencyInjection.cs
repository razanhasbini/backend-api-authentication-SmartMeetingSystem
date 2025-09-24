using Microsoft.Extensions.DependencyInjection;
using SmartMeetingSystem.Application.IService;
using SmartMeetingSystem.Application.Service;

namespace SmartMeetingSystem.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGadgetService, GadgetService>();
            services.AddScoped<IRoomGadgetService, RoomGadgetService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IMomService, MomService>();
            return services;
        }
    }
}
