using System.Data;
using Dapper;
using Domain.Common;
using Domain.Models;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;
public class TaskRepository : ITaskRepository
{
    private readonly IDbConnection _connection;

    public TaskRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task CreateTaskAsync(TaskModel task)
    {
        string sql = @"INSERT INTO TASK (ID, NAME, DESCRIPTION, PRIORITY, LIMITDATE, STATUS) 
                                 VALUES (@ID, @NAME, @DESCRIPTION, @PRIORITY, @LIMITDATE, @STATUS)";

        var sqlParams = new
        {
            ID = task.Id,
            NAME = task.Name,
            DESCRIPTION = task.Description,
            PRIORITY = task.Priority,
            LIMITDATE = task.LimitDate,
            STATUS = task.Status
        };

        int result = await _connection.ExecuteAsync(sql, sqlParams);
    }

    public async Task DeleteTaskAsync(Guid id)
    {
        string sql = $"DELETE FROM TASK WHERE ID = @ID";

        var result = await _connection.ExecuteAsync(sql, new { ID = id });
    }

    public async Task<TaskModel?> GetTaskByIdAsync(Guid id)
    {
        string sql = @"SELECT ID, NAME, DESCRIPTION, PRIORITY, LIMITDATE, STATUS 
                        FROM TASK WHERE ID = @ID";

        var task = await _connection.QueryFirstOrDefaultAsync<TaskModel>(sql, new { ID = id });

        return task;

    }

    public async Task<PaginatedResult<TaskModel>> GetTasksAsync(TaskFilterModel filter)
    {
        string sql = @"SELECT ID, NAME, DESCRIPTION, PRIORITY, LIMITDATE, STATUS 
                        FROM TASK
                       ORDER BY NAME
                       OFFSET @OFFSET ROWS
                       FETCH NEXT @PAGESIZE ROWS ONLY";
          
        var sqlParams = new
        {
            OFFSET = (filter.PageNumber - 1) * filter.PageSize,
            PAGESIZE = filter.PageSize
        };

        var tasks = await _connection.QueryAsync<TaskModel>(sql, sqlParams);

        var totalTasks = await _connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM TASK");

        return new PaginatedResult<TaskModel>
        {
            Items = tasks.ToList(),
            TotalItems = totalTasks,
            PageNumber = filter.PageNumber,
            PageSize = filter.PageSize,
            TotalPages = (int)Math.Ceiling((double)totalTasks / filter.PageSize)
        };
    }

    public async Task UpdateTaskAsync(TaskModel task)
    {
        string sql = @"UPDATE TASK SET 
                            NAME = @NAME,
                            DESCRIPTION = @DESCRIPTION,
                            PRIORITY = @PRIORITY,
                            LIMITDATE = @LIMITDATE,
                            STATUS = @STATUS
                            WHERE ID = @ID";

        var sqlParams = new
        {
            NAME = task.Name,
            DESCRIPTION = task.Description,
            PRIORITY = task.Priority,
            LIMITDATE = task.LimitDate,
            STATUS = task.Status,
            ID = task.Id
        };

        var result = await _connection.ExecuteAsync(sql, sqlParams);

    }
}
