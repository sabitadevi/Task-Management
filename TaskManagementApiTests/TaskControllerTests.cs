using Microsoft.AspNetCore.Mvc;
using TaskManagmentApi.Controllers;

namespace TaskManagementApiTests
{
    [TestClass]
    public class TaskControllerTests
    {
        [TestMethod]
        public void CreateTask_ReturnsCreatedResult_WithTask()
        {
            // Arrange
            var controller = new TasksController();
            // This is a explicit reference because a System Task class exists in .net framework
            var newTask = new TaskManagmentApi.Task
            {
                IsCompleted = false,
                CreatedBy = "Sabita",
                Description = "Task added from Unit Test"
            };

            // Act
            var result = controller.AddTask(newTask) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            // Assert task is added to the list with correct values
            var addedTask = TasksController.TaskList.Last();
            Assert.IsNotNull(addedTask);
            Assert.AreEqual(newTask.Description, addedTask.Description);
            Assert.IsFalse(addedTask.IsCompleted);
        }
    }
}