﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Entities
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
        int CreatedById { get; set; }
        DateTime? UpdatedDate { get; set; }
        int? UpdatedById { get; set; }
        bool IsActive { get; set; }
    }
}
