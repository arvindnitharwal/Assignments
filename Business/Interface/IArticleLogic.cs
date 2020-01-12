using System.Collections.Generic;
using Assignments.Entity;
namespace Assignments.Business
{
    public interface IArticleLogic
    {
        ArticleResponse GetViewCount(ViewCountRequest request);
        ArticleResponse GetTopArticle(TopArticleRequest request);
    }
}