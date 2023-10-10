namespace TaskSystem.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public List<TaskModel>? TasksList {get; set;}
        
    }
}
