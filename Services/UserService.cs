namespace CRMSYSTEMBACK.Services
{

    using Microsoft.Extensions.Options;
    using CRMSYSTEMBACK.Auth;
    using CRMSYSTEMBACK.Entities;
    using CRMSYSTEMBACK.Helpers;
    using CRMSYSTEMBACK.Models.Users;

    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        IEnumerable<Project> GetbyUser();
    }

    public class UserService : IUserService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;

        public UserService(
            DataContext context,
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }


        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);

            // validate
            if (user == null || model.Password != user.PasswordHash)
                throw new AppException("Email or password is incorrect");

            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken);
        }
       
   
        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }
       public IEnumerable<Project> GetbyUser()
        {
            return _context.Project;
        }


        public User GetById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
   

        
       
    }
}
