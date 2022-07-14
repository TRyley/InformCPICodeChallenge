namespace InformCPI.Server.Models
{
    public class Contact
    {
        public Contact() {}
        public Contact(int id): this()
        {
            Id = id;
        }

        public Contact(int id, string name, string address, string email, string phoneNum) : this(id)
        {
            Name = name;
            Address = address;
            Email = email;
            PhoneNum = phoneNum;
        }   

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
    }
}
