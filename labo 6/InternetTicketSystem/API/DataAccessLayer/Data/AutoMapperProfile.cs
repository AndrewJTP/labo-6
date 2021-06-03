using AutoMapper;
using InternetTicketSystem.Data.Entities;
using InternetTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetTicketSystem.Data
{
    public class AutoMapperProfile:Profile
    {


        public AutoMapperProfile()
        {
            this.CreateMap <TicketEntity, TicketModel > ()
            .ReverseMap();

            this.CreateMap<TicketModel, TicketEntity>()
                   .ReverseMap();
        }
    }
}
