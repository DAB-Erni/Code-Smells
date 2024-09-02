using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

public class UserService
{
    // TO DO: Refactor to use dependency injection for better flexibility
    public readonly UserRepository _userRepository;

    public UserService()
    {
        _userRepository = new UserRepository();
    }

    public async Task<JsonDocument> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }
}
