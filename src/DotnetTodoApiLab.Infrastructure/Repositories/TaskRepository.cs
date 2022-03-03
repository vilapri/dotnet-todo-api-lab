using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotnetTodoApiLab.Domain.Repositories;
using DotnetTodoApiLab.Infrastructure.Context;

namespace DotnetTodoApiLab.Infrastructure.Repositories
{
    public class TaskRepository : Repository<Domain.Entities.Task>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}