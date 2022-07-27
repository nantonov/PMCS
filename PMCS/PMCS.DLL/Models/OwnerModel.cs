namespace PMCS.DLL.Models
{
    public class OwnerModel
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string FullName { get; set; }
        public IEnumerable<PetModel> Pets { get; set; } = new List<PetModel>();
    }
}
