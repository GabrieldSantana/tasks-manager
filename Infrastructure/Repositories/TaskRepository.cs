using System.Data;
using Dapper;
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

    public async Task<bool> CreateTaskAsync(TaskModel task)
    {
        try
        {
            string sql = @"INSERT INTO TASK VALUES (@NAME, @DESCRIPTION, @PRIORITY, @LIMITDATE, @STATUS)";

            var sqlParams = new
            {
                NAME = task.Name,
                DESCRIPTION = task.Description,
                PRIORITY = task.Priority,
                LIMITDATE = task.LimitDate,
                STATUS = task.Status
            };

            int result = await _connection.ExecuteAsync(sql, sqlParams);

            return result > 0 ? true : false; 
        }
        catch (Exception)
        {
            throw new Exception("Could not create task.");
        }
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        try
        {
            string sql = $"DELETE TASK WHERE ID = {id}";

            var result = await _connection.ExecuteAsync(sql);

            return result > 0 ? true : false;
        }
        catch (Exception)
        {
            throw new Exception("Could not delete task.");
        }
    }

    public async Task<TaskModel> GetTaskByIdAsync(int id)
    {
        try
        {
            string sql = $"SELECT * FROM TASK WHERE ID = {id}";

            var task = await _connection.QueryFirstOrDefaultAsync<TaskModel>(sql);

            return task;
        }
        catch (Exception)
        {
            throw new Exception("Could not get task by id.");
        }
    }

    public async Task<List<TaskModel>> GetTasksAsync()
    {
        try
        {
            string sql = "SELECT * FROM TASK";

            var tasks = await _connection.QueryAsync<TaskModel>(sql);

            return tasks.ToList();
        }
        catch (Exception)
        {
            throw new Exception("Could not get list of tasks.");
        }
    }

    public async Task<bool> UpdateTaskAsync(TaskModel task)
    {
        try
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

            return result > 0 ? true : false;
        }
        catch (Exception)
        {
            throw new Exception("Could not update task.");
        }
    }
}
