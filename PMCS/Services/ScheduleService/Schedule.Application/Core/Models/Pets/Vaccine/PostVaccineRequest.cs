﻿namespace Schedule.Application.Core.Models.Pets.Vaccine
{
    public class PostVaccineRequest
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateTime { get; set; }

        public int PetId { get; set; }
    }
}
