namespace Ultimate.WebApp.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string userName { get; set; }
        public string ConfirmPassword { get; set; }
        public List<ClientModel> Clients { get; set; }

    }
}
