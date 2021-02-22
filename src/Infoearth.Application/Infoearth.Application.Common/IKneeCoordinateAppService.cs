//using Abp.Application.Services;
//using Abp.Application.Services.Dto;
//using Abp.Authorization;
//using AutoMapper;
using Infoearth.Application.Common.Dtos;
//using InfoEarthFrame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoearth.Application.Common
{
    public interface IKneeCoordinateAppService 
    {
        KneeCoordinateOutput GeoCoordinateList(KneeCoordinateInput input);
    }
}
