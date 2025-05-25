namespace Ultimate.WebApp.Helpers
{
    public class JwtTokenModel
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
