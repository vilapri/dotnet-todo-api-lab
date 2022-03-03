using System.ComponentModel.DataAnnotations;
using DotnetTodoApiLab.Domain.Core.Entities;

namespace DotnetTodoApiLab.Domain.Entities
{
    public class Task : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
