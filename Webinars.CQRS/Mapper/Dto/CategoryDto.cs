using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webinars.Domain.ValueObjects.Webinar;

namespace Webinars.CQRS.Mapper.Dto
{
    public class CategoryDto
    {
        public CatergoryStatus Status { get; set; }

    }
}
