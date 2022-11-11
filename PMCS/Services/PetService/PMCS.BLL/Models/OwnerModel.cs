using PMCS.BLL.Interfaces.Models;

namespace PMCS.BLL.Models
{
    public class OwnerModel : IHasIdModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string FullName { get; set; }

        public IEnumerable<PetModel> Pets { get; set; } = new List<PetModel>();
    }
}
