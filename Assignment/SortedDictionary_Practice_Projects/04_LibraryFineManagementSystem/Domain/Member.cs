namespace Domain
{
    public class Member
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Fine { get; set; }

        public Member(){}
        public Member(string id, string name, int fine)
        {
            Id = id;
            Name = name;
            Fine = fine;
        }
    }
}
