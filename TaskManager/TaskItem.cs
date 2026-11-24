
namespace TaskManager
{
	public class TaskItem
	{
		// Properties
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsCompleted { get; set; }

		// Constructor
		public TaskItem(int id, string name)
		{
			Id = id;
			Name = name;
			IsCompleted = false;
		}
		public void MarkCompleted()
		{
			IsCompleted = true;
		}
	}
}
