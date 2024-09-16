namespace Library.Models
{
    public class BibliotekariDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string UserType { get; set; }
        public string JMBG { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public int BrojLogovanja { get; set; }
        public DateTime Last_Login_at { get; set; }

    }
}
