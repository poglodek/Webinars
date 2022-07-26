using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Webinars.Common.Builders;
using Webinars.CQRS.Mapper.Dto;
using Webinars.CQRS.Mapper.Dto.Speaker;
using Webinars.CQRS.Webinar.Commands.CreateWebinar;
using Webinars.Domain.ValueObjects.Webinar;
using Xunit;

namespace Webinars.IntegrationTests.API.Webinar;

public class CreateWebinar : IClassFixture<WebinarFactory<Program>>
{
    private HttpClient _client;
    public CreateWebinar(WebinarFactory<Program> factory)
    {
        _client = factory.WithWebHostBuilder(builder =>
        {
            
        }).CreateClient();
    }
    
    private CreateWebinarCommand CreateWebinarCommand()
    {
        var body = new CreateWebinarCommandBuilder()
            .WithCategory(CatergoryStatus.NEW)
            .WithDescription("Test with 10 characters")
            .WithLink("yt.com/somecharshere", "https://www.youtube.com/watch?v=dQw4w9WgXcQ")
            .WithSpeakerId(1)
            .WithWebinarName("Fancy name")
            .WithReplay("https://www.youtube.com/watch?v=dQw4w9WgXcQ", "google.com")
            .Build();
        return body;
    }
    
    [Fact]
    public async Task CreateWebinar_WithBadDescription_ShouldReturn400()
    {
        var body = CreateWebinarCommand();
        body.Description = new DescriptionDto
        {
            DescriptionText = String.Empty
        };

        var response = await _client.PostAsync("/CreateWebinar", new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF32, "application/json"));

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    

    [Fact]
    public async Task CreateWebinar_WithBadSpeaker_ShouldReturn400()
    {
        var body = CreateWebinarCommand();
        body.SpeakerId = new SpeakerIdDto();

        var response = await _client.PostAsync("/CreateWebinar", new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF32, "application/json"));

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact]
    public async Task CreateWebinar_WithBadLinkYouTube_ShouldReturn400()
    {
        var body = CreateWebinarCommand();
        body.Link = new LinkDto
        {
            Website = "google.com",
            Youtube = ""
        };

        var response = await _client.PostAsync("/CreateWebinar", new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF32, "application/json"));

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact]
    public async Task CreateWebinar_WithBadLinkWebsite_ShouldReturn400()
    {
        var body = CreateWebinarCommand();
        body.Link = new LinkDto
        {
            Website = "",
            Youtube = "youtube.com/watch?v=dQw4w9WgXcQ"
        };

        var response = await _client.PostAsync("/CreateWebinar", new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF32, "application/json"));
        
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact]
    public async Task CreateWebinar_AllOkej_ShouldReturn201()
    {
        var body = CreateWebinarCommand();

        var response = await _client.PostAsync("/CreateWebinar", new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF32, "application/json"));
        
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
    
}