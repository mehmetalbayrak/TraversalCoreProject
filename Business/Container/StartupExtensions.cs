using Business.Abstract;
using Business.Concrete;
using Business.Validation;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Dto.DTOs.AnnouncementDtos;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
namespace Business.Container
{
    public static class StartupExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();

            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IDestinationDal, EfDestinationDal>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EfReservationDal>();

            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EfGuideDal>();

            services.AddScoped<IContactUsService, ContacUsManager>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

            services.AddScoped<IExcelService, ExcelManager>();

            services.AddScoped<IPdfService, PdfManager>();

        }
        public static void CustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AddAnnouncementDto>, AnnouncementValidator>();
        }
    }
}
