using Application.Dtos.Human;
using Application.Features.Human.Command;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOS

            CreateMap<Human, HumanResponse>();

            #endregion

            #region Commands

            CreateMap<CreateHumanCommand, Human>();

            #endregion
        }
    }
}
