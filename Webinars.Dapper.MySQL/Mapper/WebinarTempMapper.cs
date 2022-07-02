using System;
using System.Collections.Generic;
using AutoMapper;
using Webinars.Dapper.MySQL.Converter;
using Webinars.Dapper.MySQL.TempClass;
using Webinars.Domain.Entities;
using Webinars.Domain.ValueObjects;
using Webinars.Domain.ValueObjects.Common;
using Webinars.Domain.ValueObjects.Ids;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.Dapper.MySQL.Mapper;

public class WebinarTempMapper : Profile
{
    public WebinarTempMapper()
    {

        CreateMap<string, WebinarName>().ConstructUsing(x => new WebinarName(x)).ReverseMap();
        CreateMap<string, Description>().ConstructUsing(x => new Description(x)).ReverseMap();
        CreateMap<DateTime, CreatedTime>().ConstructUsing(x => new CreatedTime(x)).ReverseMap();
        CreateMap<int, Category>().ConstructUsing(x => new Category((CatergoryStatus) x)).ReverseMap();
        CreateMap<int, WebinarId>().ConstructUsing(x => new WebinarId(x)).ReverseMap();
        CreateMap<WebinarTemp,Webinar>().ConvertUsing<WebinarTempConverter>();

    }
}
