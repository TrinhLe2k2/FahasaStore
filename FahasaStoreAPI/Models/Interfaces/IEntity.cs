﻿namespace FahasaStore.Models.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime? CreatedAt { get; set; }
    }
}
