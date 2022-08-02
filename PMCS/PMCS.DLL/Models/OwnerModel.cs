namespace PMCS.DLL.Models
{
    public class OwnerModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public IEnumerable<PetModel> Pets { get; set; } = new List<PetModel>();
    }
}
