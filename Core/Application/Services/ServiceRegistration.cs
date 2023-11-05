using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;
using Application.Mapping;
using System.Collections.Generic;

using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Application.FluentValidation;

namespace Application.Services
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>
                {
                    new AutoMapperConfig()

                });
            });

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateAboutCommandRequestValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateAboutCommandRequestValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateAppointmentCommandRequestValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateAppointmentCommandRequestValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateContactCommandRequestValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateContactCommandRequestValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCourseCommandRequestValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateCourseCommandRequestValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateTeamCommandRequestValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateTeamCommandRequestValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateTestimonialCommandRequestValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateTestimonialCommandRequestValidator>());




        }
    }
}
