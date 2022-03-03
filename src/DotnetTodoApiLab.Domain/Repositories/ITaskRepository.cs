using DotnetTodoApiLab.Domain.Core.Interfaces;

namespace DotnetTodoApiLab.Domain.Repositories
{
    public interface ITaskRepository : IRepository<Domain.Entities.Task>
    {
    }
}
