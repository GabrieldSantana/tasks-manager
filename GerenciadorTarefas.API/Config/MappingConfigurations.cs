using System.Reflection;
using Domain.Dtos;
using Domain.Models;
using Mapster;

namespace TasksManager.API.Config;

public static class MappingConfigurations
{
    public static void RegisterMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<TaskDTO, TaskModel>.NewConfig();

        TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
    }
}
