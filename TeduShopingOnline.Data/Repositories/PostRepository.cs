using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            //var id = 1;
            //var query = database.Posts    // your starting point - table in the "from" statement
            //   .Join(database.Post_Metas, // the source table of the inner join
            //      post => post.ID,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
            //      meta => meta.Post_ID,   // Select the foreign key (the second part of the "on" clause)
            //      (post, meta) => new { Post = post, Meta = meta }) // selection
            //   .Where(postAndMeta => postAndMeta.Post.ID == id);    // where statement

            var queryLinqSyntax = from post in DbContext.Posts
                                  join postTag in DbContext.PostTags
                                  on post.Id equals postTag.PostID
                                  where postTag.TagID == tag && post.Status
                                  orderby post.CreatedBy descending
                                  select post;
            totalRow = queryLinqSyntax.Count();

            //var queryLamdaSyntax = DbContext.Posts
            //    .Join(DbContext.PostTags,
            //    post => post.Id,
            //    postTag => postTag.PostID,
            //    (post, postTag) => new { Post = post })
            //    .Where(postAndTag=>postAndTag.Post.Id);

            return queryLinqSyntax = queryLinqSyntax.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
