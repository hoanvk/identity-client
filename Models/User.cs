using Microsoft.AspNetCore.Identity;

namespace RoleBaseDemo.Models;
public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string DateOfBirth { get; set; }
    public IEnumerable<User> GetUsers()
    {
        return new List<User>() {
            new User {
                Id = 101,
                UserName = "anet",
                Name = "Anet",
                Email = "anet@test.com",
                Password = "anet123",
                Role = "Admin",
                DateOfBirth = "01/01/2012"
            },
        new User {
                Id = 102,
                UserName = "hoanvk",
                Name = "Hoan",
                Email = "anet@test.com",
                Password = "hoan123",
                Role = "User",
                DateOfBirth = "01/01/2012"
            }
        };
    }
}