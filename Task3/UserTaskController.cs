using System;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            try
            {
                string message = GetMessageForModel(userId, description);
                model.AddAttribute("action_result", message);
                return false;
            }
            catch (NullReferenceException)
            {
                return true;
            }
        }

        private string GetMessageForModel(int userId, string description)
        {
            var task = new UserTask(description);
            int result = _taskService.AddTaskForUser(userId, task);
            switch (result)
            {
                case -1:
                    return "Invalid userId";
                case -2:
                    return "User not found";
                case -3:
                    return "The task already exists";
                default:
                   throw new NullReferenceException();
            }
        }
    }
}