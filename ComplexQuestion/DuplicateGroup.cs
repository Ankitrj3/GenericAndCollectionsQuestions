public class DuplicateGroup
{
    public List<Customer> Customers { get; set; }
    public string Reason { get; set; }

    public DuplicateGroup()
    {
        Customers = new List<Customer>();
        Reason = "";
    }
}
