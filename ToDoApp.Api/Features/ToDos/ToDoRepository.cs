using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using ToDoApp.Api.Features.Users;

namespace ToDoApp.Api.Features.ToDos;


public class ToDoRepository
{
    private readonly IDbConnection _dbConnection;

    public ToDoRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<List<ToDo>> GetAllAsync()
    {
        var sql = "SELECT Id, Content, UserId FROM ToDos";
        
        return (await _dbConnection.QueryAsync<ToDo>(sql)).ToList();
    }

    public async Task CreateAsync(string content, int userId)
    {
        // Only for Development purposes. This is very bad code for the production environment.
        int id = await _dbConnection.ExecuteScalarAsync<int>("SELECT COALESCE(MAX(Id), 0) + 1 FROM ToDos");

        var sql = "INSERT INTO ToDos (Id, Content, UserId) VALUES (@Id, @Content, @UserId)";
        try
        {
            await _dbConnection.ExecuteAsync(sql, new { Id = id, Content = content, UserId = userId });
        }
        catch (SqlException ex) when (ex.Number == 547) // Foreign key violation
        {
            throw new InvalidOperationException("The specified user does not exist.", ex);
        }
    }

    public async Task<ToDoDetailModel?> GetWithAuthorAsync(int id)
    {
        var sql = "SELECT t.Id, t.Content, u.Id as Id, u.Username, U.Email " +
                    "FROM ToDos t " +
                    "JOIN Users u ON t.UserId = u.Id " +
                    "WHERE t.Id = @Id";

        var result = await _dbConnection.QueryAsync<ToDoDetailModel, AuthorModel, ToDoDetailModel>(
            sql,
            (todo, author) =>
            {
                todo.Author = author;
                return todo;
            },
            new { Id = id },
            splitOn: "Id");

        return result.FirstOrDefault();
    }

    public async Task DeleteAsync(int id)
    {
        var sql = "DELETE FROM ToDos WHERE Id = @Id";
        await _dbConnection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task UpdateAsync(int id, string content, int userId)
    {
        var sql = "UPDATE ToDos SET Content = @Content, UserId = @UserId WHERE Id = @Id";

        try
        {
            await _dbConnection.ExecuteAsync(sql, new { Id = id, Content = content, UserId = userId });
        }
        catch (SqlException ex) when (ex.Number == 547) // Foreign key violation
        {
            throw new InvalidOperationException("The specified user does not exist.", ex);
        }
    }
}
