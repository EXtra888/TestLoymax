namespace Loymax.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        //public string Login { get; set; }
        //public string Password { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
