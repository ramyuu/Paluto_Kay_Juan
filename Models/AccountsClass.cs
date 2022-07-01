namespace Paluto_Kay_Juan.Models
{
    public class AccountsClass
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AccountsClass()
        {
            Username = "Blank";
            Password = "Blank";
        }

        public AccountsClass(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
