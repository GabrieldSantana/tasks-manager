using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.Interfaces;
public interface ITaskRepository
{
    Task<List<TaskModel>> GetTasksAsync();
    Task<TaskModel> GetTaskByIdAsync(int id);
    Task<bool> CreateTaskAsync(TaskModel task);
    Task<bool> UpdateTaskAsync(TaskModel task);
    Task<bool> DeleteTaskAsync(int id);
}
