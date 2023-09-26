using infrastructure;
using infrastructure.Models;

namespace service;

public class Service
{
    private readonly Repository _repository;

    public Service(Repository repository)
    {
        _repository = repository;
    }

    public Article CreateArticle(string headline, string body, string author, string articleImgUrl)
    {
        return _repository.CreateArticle(headline, body, author, articleImgUrl);
    }
    
    public IEnumerable<Article> GetAllArticles()
    {
        return _repository.GetAllArticles();
    }

    public Article GetArticle(int articleId)
    {
        return _repository.GetArticle(articleId);
    }

    public Article UpdateArticle(int articleId, string headline, string body, string author, string articleImgUrl)
    {
        return _repository.UpdateArticle(articleId, headline, body, author, articleImgUrl);
    }

    public void DeleteArticle(int articleId)
    {
        _repository.DeleteArticle(articleId);
    }

    public IEnumerable<Article> SearchArticles(SearchCriteria searchCriteria)
    {
        return _repository.SearchArticles(searchCriteria);
    }
}