using Application.Interfaces;
using Application.Interfaces.IMainService;
using Application.Services;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace GerenciadorTarefas.API.Config;

public static class DependencyInjection
{
    public static IServiceCollection DependencyInjections(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<ITaskService, TaskService>();

        services.AddScoped<INotifier, Notifier>();

        return services;
    }
}
