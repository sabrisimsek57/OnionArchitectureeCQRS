using Application.Dtos.AboutDto;
using Application.Dtos.Appointment;
using Application.Dtos.ContactDto;
using Application.Dtos.CourseDto;
using Application.Dtos.TeamDto;

using Application.Dtos.TestimonialDto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {

            CreateMap<ResultTeamDto, Team>().ReverseMap();
            CreateMap<CreateTeamDto, Team>().ReverseMap();
            CreateMap<UpdateTeamDto, Team>().ReverseMap();
            CreateMap<UpdateTeamDto, ResultTeamDto>().ReverseMap();

            CreateMap<ResultTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<CreateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto, ResultTestimonialDto>().ReverseMap();

            CreateMap<ResultCourseDto, Course>().ReverseMap();
            CreateMap<CreateCourseDto, Course>().ReverseMap();
            CreateMap<UpdateCourseDto, Course>().ReverseMap();
            CreateMap<ResultNoCourseDto, Course>().ReverseMap();
            CreateMap<UpdateCourseDto, ResultCourseDto>().ReverseMap();
         

            CreateMap<ResultAppointmentDto, Appointment>().ReverseMap();         
            CreateMap<CreateAppointmentDto , Appointment>().ReverseMap();
            CreateMap<UpdateAppointmentDto, Appointment>().ReverseMap();
            CreateMap<UpdateAppointmentDto, ResultCourseDto>().ReverseMap();
            CreateMap<ResultNoAppointmentDto, Appointment>().ReverseMap();


            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, ResultAboutDto>().ReverseMap();

            CreateMap<ResultContactDto, Contact>().ReverseMap();
            CreateMap<CreateContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, Contact>().ReverseMap();
            CreateMap<UpdateContactDto, ResultContactDto>().ReverseMap();



        }
    }
}
