namespace Library.Models
{
    public class User
    {
        public int Id { get; set; }

        public long User_type_id { get; set; }

        public long User_gender_id { get; set; }

        public int JMBG { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Photo { get; set; }

        public bool Email_verified { get; set; }

        public string Remember_token { get; set; }

        public DateTime Last_login_at { get; set; }

        public int Login_count { get; set; }

        public DateTime Created_at { get; set; }

        public DateTime Updated_at { get; set; }

        public bool Active { get; set; }
    }
}
