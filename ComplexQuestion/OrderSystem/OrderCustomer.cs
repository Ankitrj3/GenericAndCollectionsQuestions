namespace OrderSystem
{
    public class OrderCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public OrderCustomer(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
