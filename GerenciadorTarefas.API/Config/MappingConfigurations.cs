using System.Reflection;
using Domain.Dtos;
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

        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    }
}
