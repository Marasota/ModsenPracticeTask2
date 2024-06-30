using AutoMapper;
using FluentValidation;
using OnlineStore.BLL.DTOs.Register;
using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Repositories.Interfaces;

namespace OnlineStore.BLL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IValidator<UserRegisterDto> _registerValidator;
        private readonly IValidator<UserLoginDto> _loginValidator;

        public AuthService(
            IUserRepository userRepository,
            ITokenService tokenService,
            IMapper mapper,
            IValidator<UserRegisterDto> registerValidator,
            IValidator<UserLoginDto> loginValidator)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
            _registerValidator = registerValidator;
            _loginValidator = loginValidator;
        }

        public async Task<AuthResponseDto> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            var validationResult = await _registerValidator.ValidateAsync(userRegisterDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var existingUser = await _userRepository.GetByUserNameAsync(userRegisterDto.UserName);
            if (existingUser != null)
            {
                throw new Exception("Username already exists.");
            }

            var user = _mapper.Map<User>(userRegisterDto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password);

            await _userRepository.AddAsync(user);

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();


            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<AuthResponseDto> LoginAsync(UserLoginDto userLoginDto)
        {
            var validationResult = await _loginValidator.ValidateAsync(userLoginDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var user = await _userRepository.GetByUserNameAsync(userLoginDto.UserName);
            if (user == null || !BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password))
            {
                throw new Exception("Invalid username or password.");
            }

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();


            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
