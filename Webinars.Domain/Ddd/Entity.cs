﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webinars.Domain.Ddd
{
    public class Entity<T>
    {
        public T Id { get; set; }
    }
}
