namespace CRMSYSTEMBACK.Models.Users
{
    using CRMSYSTEMBACK.Entities;
    
    public class AuthenticateResponse
    { 
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public Role Role { get; set; }
            public string Token { get; set; }

            public AuthenticateResponse(User user, string token)
            {
                Id = user.Id;
                Name = user.Name;
                Email = user.Email ;
                Role = user.Role;
                Token = token;
            }
        }
}
