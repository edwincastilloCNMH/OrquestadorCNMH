namespace WebAPI.Application.DTO
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string DocNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool State { get; set; }
    }
}
