using System;
using System.Collections.Generic;

public class TaskItem
{
    public int TaskId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Priority { get; set; }
    public string? Status { get; set; }
    public DateTime DueDate { get; set; }
    public string? AssignedTo { get; set; }
}

public class Project
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public string ProjectManager { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}

public class TaskManager
{
    public static Dictionary<int, Project> projectDetails = new Dictionary<int, Project>();
    public static int counter = 1;
    public static int taskCounter = 101;

    public void CreateProject(string name, string manager, DateTime start, DateTime end)
    {
        Project project = new Project()
        {
            ProjectId = counter,
            ProjectName = name,
            ProjectManager = manager,
            StartDate = start,
            EndDate = end
        };

        projectDetails.Add(counter, project);
        counter++;
    }

    public void AddTask(int projectId, string title, string description, string priority, DateTime dueDate, string assignee)
    {
        if (!projectDetails.ContainsKey(projectId))
        {
            Console.WriteLine("Project is not available with this Project Id");
            return;
        }

        TaskItem taskItem = new TaskItem()
        {
            TaskId = taskCounter,
            Title = title,
            Description = description,
            Priority = priority,
            Status = "ToDo",
            DueDate = dueDate,
            AssignedTo = assignee
        };

        projectDetails[projectId].Tasks.Add(taskItem);
        taskCounter++;
    }

    public Dictionary<string, List<TaskItem>> GroupTasksByPriority()
    {
        Dictionary<string, List<TaskItem>> result = new Dictionary<string, List<TaskItem>>();

        foreach (var item in projectDetails.Values)
        {
            foreach (var task in item.Tasks)
            {
                if (!result.ContainsKey(task.Priority))
                {
                    result[task.Priority] = new List<TaskItem>();
                }
                result[task.Priority].Add(task);
            }
        }

        return result;
    }

    public List<TaskItem> GetOverdueTasks()
    {
        List<TaskItem> res = new List<TaskItem>();

        foreach (var item in projectDetails.Values)
        {
            foreach (var task in item.Tasks)
            {
                if (task.DueDate < DateTime.Now && task.Status != "Completed")
                {
                    res.Add(task);
                }
            }
        }

        return res;
    }

    public List<TaskItem> GetTasksByAssignee(string assigneeName)
    {
        List<TaskItem> res = new List<TaskItem>();

        foreach (var item in projectDetails.Values)
        {
            foreach (var task in item.Tasks)
            {
                if (task.AssignedTo == assigneeName)
                {
                    res.Add(task);
                }
            }
        }

        return res;
    }
}
public class Program
{
    public static void Main()
    {
        
    }
}