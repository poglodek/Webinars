using System;
using System.Reflection;
using AutoMapper;
using FluentAssertions;
using Webinars.CQRS.Mapper;
using Webinars.Dapper.MySQL.Converter;
using Webinars.Dapper.MySQL.Mapper;
using Webinars.Dapper.MySQL.TempClass;
using Webinars.Domain.Entities;
using Webinars.Domain.ValueObjects.Webinar;
using Xunit;

namespace Webinars.IntegrationTests.Presistence.Mapper
{
    public class WebinarMapperTest
    {
        private IMapper _mapper;
        private WebinarTempConverter converter;

        public WebinarMapperTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new WebinarTempMapper());
                cfg.AddProfile(new MapperDto());
                cfg.AddProfile(new MapperProperty());
                cfg.AddProfile(new ViewModelMapper());
                cfg.ConstructServicesUsing(x =>
                {
                    if (x == typeof(WebinarTempConverter))
                    {
                        return this.converter;
                    }

                    return null;
                });
                
            });
            

            _mapper = config.CreateMapper();
            
            converter = new WebinarTempConverter(_mapper);
        }

        private WebinarTemp ReturnTempWebinar()
        {
            return new WebinarTemp
            {
                Description = "Test desc",
                CategoryInt = 1,
                CreatedDate = DateTime.Now,
                WebinarId = 1,
                WebinarName = "Test",
                WebsiteLink = "www.test.com",
                WebsiteReplay = "www.replay.com",
                YoutubeReplay = "www.yt.com",
                YouTubeLink = "ty.com",

            };
        }
        [Fact]
        public void MapWebinarTestToWebinarAllPropertyOk()
        {
            var temp = ReturnTempWebinar();
            var entity = _mapper.Map<Webinar>(temp);
            
            entity.Id.Id.Should().Be(temp.WebinarId);
            entity.Category.Status.Should().Be((CatergoryStatus)temp.CategoryInt);
            entity.CreatedTime.CreatedDateTime.Should().Be(temp.CreatedDate);
            entity.Description.DescriptionText.Should().Be(temp.Description);
            entity.WebinarName.Name.Should().Be(temp.WebinarName);
            entity.Link.Youtube.Should().Be(temp.YouTubeLink);
            entity.Link.Website.Should().Be(temp.WebsiteLink);
            entity.Replay.Link.Website.Should().Be(temp.WebsiteReplay);
            entity.Replay.Link.Youtube.Should().Be(temp.YoutubeReplay);

        }
    }
}