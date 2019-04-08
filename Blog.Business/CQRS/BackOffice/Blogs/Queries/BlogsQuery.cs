using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blog.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Business.CQRS.BackOffice.Blogs.Queries
{
    public class BlogsQuery : IRequest<string>
    {
        public int MyProperty { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }

    public class BlogsQueryHandler : IRequestHandler<BlogsQuery, string>
    {
        private readonly BlogDbContext blogDbContext;

        public BlogsQueryHandler(BlogDbContext _blogDbContext) {
            blogDbContext = _blogDbContext;
        }
        public async Task<string> Handle(BlogsQuery request, CancellationToken cancellationToken)
        {
            var model = await blogDbContext.Categories.ToListAsync();
            return model.FirstOrDefault().Name;
        }
    }


}
