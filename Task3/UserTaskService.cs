using System;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public int AddTaskForUser(int userId, UserTask task)
        {
            try
            {
                if (userId < 0)
                    return -1;

                var user = _userDao.GetUser(userId);                    

                var tasks = user.Tasks;
                foreach (var t in tasks)
                {
                    if (string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase))
                        return -3;
                }

                tasks.Add(task);

                return 0;
            }
            catch (NullReferenceException)
            {
                return -2;
            }
           
        }
    }
}