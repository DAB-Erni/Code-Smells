using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        UserService userService = new UserService();

        var users = await userService.GetAllUsersAsync();
        try
        {
            // TO DO: Refactor this code block into separate methods for readability
            // - Move the user handling logic to a separate method
            // -- Handle the case if no users is found.
            // -- Process the users if they are not null.
            
            if (users == null)
            {
                Console.WriteLine("No users found.");
                return;
            }

            foreach (var user in users.RootElement.EnumerateArray())
            {
                int id = user.GetProperty("id").GetInt32();
                string name = user.GetProperty("name").GetString() ?? "Guest";
                string company = user.GetProperty("company").GetString() ?? "N/A";


                Console.WriteLine($"id: {id}, name: {name}, company: {company}");
            }
        }
        catch (Exception ex)
        {
            // TO DO: Try to consider handling different types of exceptions
            Console.WriteLine($"Request error: , {ex.Message}");
        }
        catch (HttpRequestException ex)
        {
            // Handle errors related to HTTP requests, such as network issues or invalid responses
            Console.WriteLine($"HTTP request error: {ex.Message}");
        }
        catch (JsonException ex)
        {
            // Handle errors related to JSON parsing, such as invalid JSON format
            Console.WriteLine($"JSON parsing error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Handle any other unexpected errors
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
