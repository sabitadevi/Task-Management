using Microsoft.AspNetCore.Mvc;

namespace TaskManagmentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        // This is an initial tasks list to show at least one Task time on load
        public static List<Task> TaskList = new List<Task> {
            new Task {
                    TaskId = 1,
                    IsCompleted = false,
                    CreatedBy = "Sabita",
                    Description = "Initial Task"
                    }
        };
        // This is invoked from route GET: tasks
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            return TaskList;
        }
        // This is invoked from route POST: tasks
        [HttpPost]
        public IActionResult AddTask(Task newTask)
        {
            try
            {
                // Incremental Task Id generated, below line finds the maximum id in the task list
                int maxId = TaskList.Max(t => t.TaskId);
                // This line increments the maximum by so that the Task id is never duplicated.
                newTask.TaskId = maxId + 1;
            }
            catch (Exception ex)
            {
                newTask.TaskId = 1;
            }
            
            TaskList.Add(newTask);
            return Ok(new { message = $"Task with ID {newTask.TaskId} created successfully." });
        }
        // This is invoked from route PUT: tasks/Any Task Id
        [HttpPut("{TaskId}")]
        public IActionResult UpdateTask(int taskId, [FromBody] Task updatedTask)
        {
            // This looks for first task in the task list, if task is not found then message communicated back
            var task = TaskList.FirstOrDefault(t => t.TaskId == taskId);
            if (task == null)
            {
                return NotFound(new { message = $"Task with Task Id {taskId} not found." });
            }

            task.Description = updatedTask.Description;
            task.IsCompleted = updatedTask.IsCompleted;

            return Ok(new { message = $"Task with ID {taskId} updated successfully." });
        }

        // This is invoked from route DELETE: tasks/Any Task Id
        [HttpDelete("{TaskId}")]
        public IActionResult DeleteTask(int taskId)
        {
            var task = TaskList.FirstOrDefault(t => t.TaskId == taskId);
            if (task == null)
            {
                return NotFound(new { message = $"Task with ID {taskId} not found." });
            }

            TaskList.Remove(task);
            return Ok(new { message = $"Task with ID {taskId} deleted successfully." });
        }
    }
}
