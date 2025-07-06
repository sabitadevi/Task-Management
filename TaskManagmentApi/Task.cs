namespace TaskManagmentApi
{
    public class Task
    {
        // This task id should be unique and auto generated
        public int TaskId { get; set; }

        public string Description { get; set; }

        public string CreatedBy { get; set; }
        public bool IsCompleted { get; set; }
    }
}