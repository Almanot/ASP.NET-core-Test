using System.Security.Cryptography;
using System.Text;
using Test_task_from_Siema__2_.Data.Interfaces;
using Test_task_from_Siema__2_.Data.Mocks;
using Test_task_from_Siema__2_.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Test_task_from_Siema__2_.Controllers
{
    public class LoginController : Controller
    {
        IUsers userDB = new MockUsers();
        public string Login(string username, string password)
        {
            // Check if input data isnt empty
            if (username != null && password != null)
            {
                // Try to get user from db
                User currentUser = userDB.GetUserByLogin(username);
                // if user exist, DB will return his data
                if (currentUser != null)
                {
                    return GenerateJWT(currentUser);
                }
            }

            return null;
        }

        string GenerateJWT(User userdata)
        {
            string secretKey = userdata.Password;
            string header = "{ \"alg\": \"HS256\", \"typ\": \"JWT\"}";
            string payload = $"{{ \"userLogin\": \"{userdata.Login}\"}}";
            string data = Convert.ToBase64String(Encoding.Default.GetBytes(header)) + '.' + Convert.ToBase64String(Encoding.Default.GetBytes(payload));
            
            HMACSHA256 hashObject = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
            byte[] signature = hashObject.ComputeHash(Encoding.UTF8.GetBytes(data));
            string encodedSignature = Convert.ToBase64String(signature);

            return data + '.' + encodedSignature;
        }

    }
}
