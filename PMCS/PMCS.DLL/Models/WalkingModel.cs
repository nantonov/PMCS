﻿namespace PMCS.DLL.Models
{
    public class WalkingModel
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Stared { get; set; }
        public DateTime Finished { get; set; }

        public int PetId { get; init; }
        public PetModel Pet { get; init; }
    }
}
