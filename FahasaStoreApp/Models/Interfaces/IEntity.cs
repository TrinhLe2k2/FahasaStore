namespace FahasaStoreAPI.Models.Interfaces
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
        //DateTime? CreatedAt { get; set; }
    }
}
