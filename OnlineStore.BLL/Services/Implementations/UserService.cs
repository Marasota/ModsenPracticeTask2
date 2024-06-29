
namespace OnlineStore.BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserDto> _validator;

        public UserService(IUserRepository userRepository, IValidator<UserDto> validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(u => new UserDto
            {
                Id = u.UserId,
                UserName = u.UserName,
                Password = u.Password
            }).ToList();
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return new UserDto
            {
                Id = user.UserId,
                UserName = user.UserName,
                Password = user.Password
            };
        }

        public async Task AddUserAsync(UserDto userDto)
        {
            var validationResult = await _validator.ValidateAsync(userDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var user = new User
            {
                UserName = userDto.UserName,
                Password = userDto.Password 
            };

            await _userRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            var validationResult = await _validator.ValidateAsync(userDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var user = new User
            {
                UserId = userDto.Id,
                UserName = userDto.UserName,
                Password = userDto.Password
            };

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
    {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
