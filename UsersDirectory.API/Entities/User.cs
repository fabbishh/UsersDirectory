namespace UsersDirectory.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string AdLogin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
