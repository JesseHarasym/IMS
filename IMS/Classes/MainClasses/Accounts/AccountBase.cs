namespace IMS.Classes.MainClasses.Accounts
{
    public class AccountBase
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int AccessLevel { get; set; }

        //this the basic base for all our users
        //made users and admins derive from this base class so that they can be used generically through inheritance
        //when passed to the database, also so that accounts can be extended into other different types depending on use case
        public AccountBase(string name, string username, string password, string email)
        {
            Name = name;
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
