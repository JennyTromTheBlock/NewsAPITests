using Dapper;
using infrastructure.Models;
using Npgsql;

namespace infrastructure;

public class Repository
{
    private readonly NpgsqlDataSource _dataSource;

    public Repository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public Article CreateArticle(string headline, string body, string author, string articleImgUrl)
    {
        var sql =
            $@"insert into news.articles (headline, body, author, articleimgurl) 
            values (@headline, @body, @author, @articleImgUrl) 
            returning *;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Article>(sql, new { headline, body, author, articleImgUrl });
        }
    }
    
    public IEnumerable<Article> GetAllArticles()
    {
        var sql = $@"select * from news.articles;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<Article>(sql);
        }
    }

    public Article GetArticle(int articleId)
    {
        var sql = 
            $@"select * from news.articles 
            where articleid = @articleId;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Article>(sql, new { articleId});
        }
    }

    public Article UpdateArticle(int articleId, string headline, string body, string author, string articleImgUrl)
    {
        var sql = 
            $@"update news.articles 
            set headline = @headline, body = @body, author = @author, articleImgUrl = @articleImgUrl
            where articleid = @articleId 
            returning *;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Article>(sql, new { articleId, headline, body, author, articleImgUrl });
        }
    }

    public void DeleteArticle(int articleId)
    {
        var sql = 
            $@"delete from news.articles 
            where articleId = @articleId;";
        using (var conn = _dataSource.OpenConnection())
        {
            conn.Execute(sql, new {articleId});
        }
    }


    public IEnumerable<Article> SearchArticles(SearchCriteria searchCriteria)
    {
        var sql =
            $@"select * from news.articles 
            where lower(body) like '%' || lower(@searchterm) || '%' 
            limit @PageSize;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<Article>(sql, searchCriteria);
        }
    }
}