using infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using service;


namespace api.Controllers;

[ApiController]
public class NewsController : ControllerBase
{
    private readonly Service _service;

    public NewsController(Service service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("/api/articles")]
    public Article CreateArticle([FromBody]Article article)
    {
        return _service.CreateArticle(article.Headline, article.Body, article.Author, article.ArticleImgUrl);
    }
    
    [HttpGet]
    [Route("/api/feed")]
    public IEnumerable<Article> GetAllArticles()
    {
        IEnumerable<Article> articles = _service.GetAllArticles();

        // ReSharper disable once InvalidXmlDocComment
        /**
         * out-commented while working on angular frontend
         * this makes 'GetArticleFeed' test fail
         *
        foreach (var article in articles)
        {
            article.Body = article.Body.Substring(0, Math.Min(50, article.Body.Length));
        }
        */
        
        return articles;
    }

    [HttpGet]
    [Route("/api/articles/{articleId}")]
    public Article GetArticle([FromRoute] int articleId)
    {
        return _service.GetArticle(articleId);
    }

    [HttpPut]
    [Route("/api/articles/{articleId}")]
    public Article UpdateArticle([FromBody] Article article, [FromRoute] int articleId)
    {
        return _service.UpdateArticle(articleId, article.Headline, article.Body, article.Author, article.ArticleImgUrl);
    }

    [HttpDelete]
    [Route("/api/articles/{articleId}")]
    public void DeleteArticle([FromRoute] int articleId)
    {
        _service.DeleteArticle(articleId);
    }

    [HttpGet]
    [Route("/api/articles/")]
    public IEnumerable<Article> SearchArticles([FromQuery] SearchCriteria searchCriteria)
    {
        return _service.SearchArticles(searchCriteria);
    }
}