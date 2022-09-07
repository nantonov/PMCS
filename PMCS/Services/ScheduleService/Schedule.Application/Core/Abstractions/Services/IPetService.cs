using Schedule.Application.Core.Models.Pets.Meal;
using Schedule.Application.Core.Models.Pets.Owner;
using Schedule.Application.Core.Models.Pets.Vaccine;
using Schedule.Application.Core.Models.Pets.Walking;

namespace Schedule.Application.Core.Abstractions.Services
{
    public interface IPetService
    {
        Task<Owner> GetOwner(int userId);
        Task<Meal> AddMeal(PostMealRequest request);
        Task<Walking> AddWalking(PostWalkingRequest request);
        Task<Vaccine> AddVaccine(PostVaccineRequest request);
    }
}
