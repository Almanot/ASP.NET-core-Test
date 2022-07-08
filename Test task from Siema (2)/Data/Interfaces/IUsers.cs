using Test_task_from_Siema__2_.Data.Models;

namespace Test_task_from_Siema__2_.Data.Interfaces
{
    public interface IUsers
    {
        User GetUserByLogin(string login);

    }
}
