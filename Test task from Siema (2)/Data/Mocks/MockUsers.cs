using Test_task_from_Siema__2_.Data.Interfaces;
using Test_task_from_Siema__2_.Data.Models;

namespace Test_task_from_Siema__2_.Data.Mocks
{
    public class MockUsers : IUsers
    {
        public User GetUserByLogin(string login)
        {
            User user = null;
            if (login == "Super")
            {
                user = new User { Login = "Super", Password = "Hero" };
            }
            return user;
        }
    }
}
