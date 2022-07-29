﻿using PMCS.DAL.Interfaces.Entities;

namespace PMCS.DAL.Entities
{
    public class WalkingEntity : IHasIdEntity
    {
        public Guid Id { get; init; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Stared { get; set; }
        public DateTime Finished { get; set; }

        public Guid PetId { get; init; }
        public PetEntity Pet { get; init; }
    }
}
