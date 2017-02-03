﻿using AutoMapper;
using TeamTools.Logic.DTO;
using TeamTools.Logic.Data.Models;

namespace TeamTools.Web.App_Start
{
    public class AutomapperConfig
    {
        public static void CreateMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().PreserveReferences();
                cfg.CreateMap<Organization, OrganizationDTO>();
                cfg.CreateMap<Project, ProjectDTO>();
                cfg.CreateMap<Note, NoteDTO>();
                cfg.CreateMap<Message, MessageDTO>();
                cfg.CreateMap<ProjectTask, ProjectTaskDTO>();
            });
        }
    }
}