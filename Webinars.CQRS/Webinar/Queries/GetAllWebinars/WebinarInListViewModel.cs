﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webinars.CQRS.Mapper.Dto;

namespace Webinars.CQRS.Webinar.Queries.GetAllWebinars
{
    public class WebinarInListViewModel
    {
        public int Id { get; set; }
        public SpeakerDto Speaker { get; set; }
        public DescriptionDto Description { get; set; }
        public LinkDto Link { get; set; }
        public ReplayDto Replay { get; set; }
        public CategoryDto Category { get; set; }
    }
}