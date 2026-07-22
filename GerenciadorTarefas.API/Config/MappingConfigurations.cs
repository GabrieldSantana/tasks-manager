using System.Reflection;
using Application.Dtos.Requests;
using Application.Dtos.Responses;
using Domain.Common;
using Domain.Models;
using Mapster;

namespace TasksManager.API.Config;

public static class MappingConfigurations
{
    public static void RegisterMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<CreateTaskRequest, TaskModel>.NewConfig();
        TypeAdapterConfig<UpdateTaskRequest, TaskModel>.NewConfig();
        TypeAdapterConfig<TaskModel, TaskResponse>.NewConfig();
        TypeAdapterConfig<PaginatedResult<TaskModel>, PaginatedResponse<TaskModel>>.NewConfig();

        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    }
}
