using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        UserService userService = new UserService();

        var users = await userService.GetAllUsersAsync();
        foreach (var user in users.RootElement.EnumerateArray())
        {
            int id = user.GetProperty("id").GetInt32();
            string name = user.GetProperty("name").GetString() ?? "Guest";
            string company = user.GetProperty("company").GetString() ?? "N/A";


            Console.WriteLine($"id: {id}, name: {name}, company: {company}");
        }
    }
}