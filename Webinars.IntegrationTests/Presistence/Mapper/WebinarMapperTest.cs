using System;
using AutoMapper;
using FluentAssertions;
using Webinars.CQRS.Mapper;
using Webinars.CQRS.Webinar.ViewModel;
using Webinars.Dapper.MySQL.Converter;
using Webinars.Dapper.MySQL.Mapper;
using Webinars.Dapper.MySQL.TempClass;
using Webinars.Domain.Entities;
using Webinars.Domain.ValueObjects;
using Webinars.Domain.ValueObjects.Common;
using Webinars.Domain.ValueObjects.Ids;
using Webinars.Domain.ValueObjects.Webinar;
using Xunit;

namespace Webinars.IntegrationTests.Presistence.Mapper;

public class WebinarMapperTest
{
    private readonly IMapper _mapper;
    private readonly WebinarTempConverter converter;

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
                if (x == typeof(WebinarTempConverter)) return converter;

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
            YouTubeLink = "ty.com"
        };
    }

    private Webinar ReturnWebinar()
    {
        return new Webinar(new WebinarId(1), new WebinarName("Name"), null, new Description("text"),
            new Link("yt.com", "www.com"),
            new Replay(new Link("rp.pl", "wbs.ry")), new CreatedTime(DateTime.Now), new Category(CatergoryStatus.NEW));
    }

    [Fact]
    public void MapWebinarTestToWebinar_AllPropertyOk_ShouldReturnOK()
    {
        var temp = ReturnTempWebinar();
        var entity = _mapper.Map<Webinar>(temp);

        entity.Id.Id.Should().Be(temp.WebinarId);
        entity.Category.Status.Should().Be((CatergoryStatus) temp.CategoryInt);
        entity.CreatedTime.CreatedDateTime.Should().Be(temp.CreatedDate);
        entity.Description.DescriptionText.Should().Be(temp.Description);
        entity.WebinarName.Name.Should().Be(temp.WebinarName);
        entity.Link.Youtube.Should().Be(temp.YouTubeLink);
        entity.Link.Website.Should().Be(temp.WebsiteLink);
        entity.Replay.Link.Website.Should().Be(temp.WebsiteReplay);
        entity.Replay.Link.Youtube.Should().Be(temp.YoutubeReplay);
    }

    [Fact]
    public void MapWebinarTestToWebinar_AllPropertyOkButReplayAreNull_ShouldReturnOK()
    {
        var temp = ReturnTempWebinar();
        temp.WebsiteReplay = string.Empty;
        temp.YoutubeReplay = string.Empty;

        var entity = _mapper.Map<Webinar>(temp);

        entity.Id.Id.Should().Be(temp.WebinarId);
        entity.Category.Status.Should().Be((CatergoryStatus) temp.CategoryInt);
        entity.CreatedTime.CreatedDateTime.Should().Be(temp.CreatedDate);
        entity.Description.DescriptionText.Should().Be(temp.Description);
        entity.WebinarName.Name.Should().Be(temp.WebinarName);
        entity.Link.Youtube.Should().Be(temp.YouTubeLink);
        entity.Link.Website.Should().Be(temp.WebsiteLink);
        entity.Replay.Link.Website.Should().Be(temp.WebsiteReplay);
        entity.Replay.Link.Youtube.Should().Be(temp.YoutubeReplay);
    }

    [Fact]
    public void MapWebinarTestToWebinar_AllPropertyOkButLinkAreNull_ShouldReturnOK()
    {
        var temp = ReturnTempWebinar();
        temp.WebsiteLink = string.Empty;
        temp.YouTubeLink = string.Empty;

        var entity = _mapper.Map<Webinar>(temp);

        entity.Id.Id.Should().Be(temp.WebinarId);
        entity.Category.Status.Should().Be((CatergoryStatus) temp.CategoryInt);
        entity.CreatedTime.CreatedDateTime.Should().Be(temp.CreatedDate);
        entity.Description.DescriptionText.Should().Be(temp.Description);
        entity.WebinarName.Name.Should().Be(temp.WebinarName);
        entity.Link.Youtube.Should().Be(temp.YouTubeLink);
        entity.Link.Website.Should().Be(temp.WebsiteLink);
        entity.Replay.Link.Website.Should().Be(temp.WebsiteReplay);
        entity.Replay.Link.Youtube.Should().Be(temp.YoutubeReplay);
    }

    [Fact]
    public void MapWebinarTestToWebinar_AllPropertyOkButLinkAllAreNull_ShouldReturnOK()
    {
        var temp = ReturnTempWebinar();
        temp.WebsiteLink = string.Empty;
        temp.YouTubeLink = string.Empty;

        temp.WebsiteReplay = string.Empty;
        temp.YoutubeReplay = string.Empty;

        var entity = _mapper.Map<Webinar>(temp);

        entity.Id.Id.Should().Be(temp.WebinarId);
        entity.Category.Status.Should().Be((CatergoryStatus) temp.CategoryInt);
        entity.CreatedTime.CreatedDateTime.Should().Be(temp.CreatedDate);
        entity.Description.DescriptionText.Should().Be(temp.Description);
        entity.WebinarName.Name.Should().Be(temp.WebinarName);
        entity.Link.Youtube.Should().Be(temp.YouTubeLink);
        entity.Link.Website.Should().Be(temp.WebsiteLink);
        entity.Replay.Link.Website.Should().Be(temp.WebsiteReplay);
        entity.Replay.Link.Youtube.Should().Be(temp.YoutubeReplay);
    }

    [Fact]
    public void MapWebinarToWebinarViewModel_AllPropertyOk_ShouldReturnOk()
    {
        var webinar = ReturnWebinar();
        var viewModel = _mapper.Map<WebinarViewModel>(webinar);

        viewModel.Id.Id.Should().Be(webinar.Id.Id);
        viewModel.Category.Status.Should().Be(webinar.Category.Status);
        viewModel.Description.DescriptionText.Should().Be(webinar.Description.DescriptionText);
        viewModel.Link.Website.Should().Be(webinar.Link.Website);
        viewModel.Link.Youtube.Should().Be(webinar.Link.Youtube);
        viewModel.Replay.Youtube.Should().Be(webinar.Replay.Link.Youtube);
        viewModel.Replay.Website.Should().Be(webinar.Replay.Link.Website);
    }

    [Fact]
    public void MapWebinarToWebinarViewModel_AllPropertyOkButLinkAreNull_ShouldReturnOk()
    {
        var webinar = ReturnWebinar();

        webinar.Link.Website = string.Empty;
        webinar.Link.Youtube = string.Empty;

        var viewModel = _mapper.Map<WebinarViewModel>(webinar);

        viewModel.Id.Id.Should().Be(webinar.Id.Id);
        viewModel.Category.Status.Should().Be(webinar.Category.Status);
        viewModel.Description.DescriptionText.Should().Be(webinar.Description.DescriptionText);
        viewModel.Link.Website.Should().Be(webinar.Link.Website);
        viewModel.Link.Youtube.Should().Be(webinar.Link.Youtube);
        viewModel.Replay.Youtube.Should().Be(webinar.Replay.Link.Youtube);
        viewModel.Replay.Website.Should().Be(webinar.Replay.Link.Website);
    }

    [Fact]
    public void MapWebinarToWebinarViewModel_AllPropertyOkButLinksAreNull_ShouldReturnOk()
    {
        var webinar = ReturnWebinar();
        webinar.Replay.Link.Website = string.Empty;
        webinar.Replay.Link.Youtube = string.Empty;
        var viewModel = _mapper.Map<WebinarViewModel>(webinar);

        viewModel.Id.Id.Should().Be(webinar.Id.Id);
        viewModel.Category.Status.Should().Be(webinar.Category.Status);
        viewModel.Description.DescriptionText.Should().Be(webinar.Description.DescriptionText);
        viewModel.Link.Website.Should().Be(webinar.Link.Website);
        viewModel.Link.Youtube.Should().Be(webinar.Link.Youtube);
        viewModel.Replay.Youtube.Should().Be(webinar.Replay.Link.Youtube);
        viewModel.Replay.Website.Should().Be(webinar.Replay.Link.Website);
    }

    [Fact]
    public void MapWebinarToWebinarViewModel_AllPropertyOkButAllLinkAreNull_ShouldReturnOk()
    {
        var webinar = ReturnWebinar();
        webinar.Link.Website = string.Empty;
        webinar.Link.Youtube = string.Empty;
        webinar.Replay.Link.Website = string.Empty;
        webinar.Replay.Link.Youtube = string.Empty;
        var viewModel = _mapper.Map<WebinarViewModel>(webinar);

        viewModel.Id.Id.Should().Be(webinar.Id.Id);
        viewModel.Category.Status.Should().Be(webinar.Category.Status);
        viewModel.Description.DescriptionText.Should().Be(webinar.Description.DescriptionText);
        viewModel.Link.Website.Should().Be(webinar.Link.Website);
        viewModel.Link.Youtube.Should().Be(webinar.Link.Youtube);
        viewModel.Replay.Youtube.Should().Be(webinar.Replay.Link.Youtube);
        viewModel.Replay.Website.Should().Be(webinar.Replay.Link.Website);
    }
    [Fact]
    //TODO: create test for map webinarcreate command to webinar view model
    public void CreateWebinarCommandToWebinarViewModel_AllPropertyOkButAllLinkAreNull_ShouldReturnOk()
    {
        var webinar = ReturnWebinar();
        webinar.Link.Website = string.Empty;
        webinar.Link.Youtube = string.Empty;
        webinar.Replay.Link.Website = string.Empty;
        webinar.Replay.Link.Youtube = string.Empty;
        var viewModel = _mapper.Map<WebinarViewModel>(webinar);

        viewModel.Id.Id.Should().Be(webinar.Id.Id);
        viewModel.Category.Status.Should().Be(webinar.Category.Status);
        viewModel.Description.DescriptionText.Should().Be(webinar.Description.DescriptionText);
        viewModel.Link.Website.Should().Be(webinar.Link.Website);
        viewModel.Link.Youtube.Should().Be(webinar.Link.Youtube);
        viewModel.Replay.Youtube.Should().Be(webinar.Replay.Link.Youtube);
        viewModel.Replay.Website.Should().Be(webinar.Replay.Link.Website);
    }
}