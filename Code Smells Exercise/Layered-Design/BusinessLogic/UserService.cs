using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

public class UserService
{
    public readonly UserRepository _userRepository;

    public UserService()
    {
        _userRepository = new UserRepository();
    }

    public async Task<JsonDocument> GetAllUsersAsync()
    {
        return await _userRepository.GetAllUsersAsync();
    }

    // public async Task AddUserAsync(dynamic user)
    // {
    //     await _userRepository.AddUserAsync(user);
    // }
}