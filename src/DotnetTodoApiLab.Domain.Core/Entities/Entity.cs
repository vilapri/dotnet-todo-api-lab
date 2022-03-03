using System;
using System.ComponentModel.DataAnnotations;

namespace DotnetTodoApiLab.Domain.Core.Entities
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
