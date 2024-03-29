﻿using Webinars.CQRS.Mapper.Dto;

namespace Webinars.CQRS.Webinar.ViewModel
{
    public class WebinarViewModel
    {
        public WebinarIdDto Id { get; set; }
        public DescriptionDto Description { get; set; }
        public LinkDto Link { get; set; }
        public ReplayDto Replay { get; set; }
        public CategoryDto Category { get; set; }
    }
}