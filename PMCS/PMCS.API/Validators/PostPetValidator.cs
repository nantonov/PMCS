using FluentValidation;
using PMCS.API.ViewModels.Pet;
using static PMCS.API.Constants.PetValidationParameters;

namespace PMCS.API.Validators
{
    public class PostPetValidator : AbstractValidator<PostPetViewModel>
    {
        public PostPetValidator()
        {
            RuleFor(x => x.OwnerId).
                Cascade(CascadeMode.Stop).
                NotEmpty().
                GreaterThan(0).
                WithMessage("Invalid owner's id."); ;
            RuleFor(x => x.Name).
                Cascade(CascadeMode.Stop).
                NotEmpty().
                Length(MinNameLength, MaxNameLength).
                Matches(NameRegularExpression).
                WithMessage("Invalid pet's name.");
            RuleFor(x => x.Info).
                Cascade(CascadeMode.Stop).
                Length(MinInfoLength, MaxInfoLength).
                WithMessage("Info has invalid length.");
            RuleFor(x => x.BirthDate)
                .Cascade(CascadeMode.Stop)
                .Must(beAValidDate)
                .WithMessage("Invalid birth date");
        }

        private bool beAValidDate(DateTime? date)
        {
            return !date.Equals(default(DateTime)) && date < DateTime.Now && GetAge(date,DateTime.Now) <= MaxDurationOfLife;
        }

        private int? GetAge(DateTime? birthDate, DateTime now)
        {
            bool birthdayCelebratedThisYear = (now.DayOfYear - birthDate?.DayOfYear) >= 0;
            var age = now.Year - birthDate?.Year;

            if (!birthdayCelebratedThisYear) --age;

            return age;
        }
    }
}
