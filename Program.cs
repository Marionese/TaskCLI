
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Net.Http.Headers;


List<TaskItem> taskList = new List<TaskItem>();
if (File.Exists("tasks.json"))
{
    string json = File.ReadAllText("tasks.json");
    taskList = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
}
switch (args[0])
{
    case "add":
        AddTask();
        break;
    case "list":
        ListTasks();
        break;
    case "done":
        DoneTask();
        break;
    case "clear":
        ClearTasks();
        break;
    case "delete":
        DeleteTask();
        break;
    case "update":
        UpdateTask();
        break;
}
void AddTask()
{
    if (args.Length != 2) return;
    TaskItem task = new TaskItem { };
    taskList.Add(task);
    task.Id = taskList.Count;
    task.Text = args[1];
    WriteTasks();
}
void DeleteTask()
{
    if (args.Length != 2) return;

}
void UpdateTask()
{
    if (args.Length != 3) return;

}
void DoneTask()
{
    if (args.Length != 2) return;
    int Id = int.Parse(args[1]);
    var task = taskList.FirstOrDefault(t => t.Id == Id);
    if (task != null)
    {
        task.IsDone = true;
        WriteTasks();
        ListTasks();
    }
}
void WriteTasks()
{
    string json = JsonSerializer.Serialize(taskList);
    File.WriteAllText("tasks.json", json);
}

//Clears the taskList and deletes the tasks.json
void ClearTasks()
{
    taskList.Clear();
    File.Delete("tasks.json");
}


//Prints the List to The Console with ID IsDone Status and Text
void ListTasks()
{
    if (taskList.Count == 0)
    {
        Console.WriteLine("No tasks found.");
        return;
    }
    foreach (var task in taskList)
    {
        Console.WriteLine($"{task.Id}: {task.Text} [{(task.IsDone ? "Done" : "Todo")}]");
    }
}