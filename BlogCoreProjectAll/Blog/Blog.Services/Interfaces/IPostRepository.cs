using Blog.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Services.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        List<Post> GetLatest5Posts();
    }
}
