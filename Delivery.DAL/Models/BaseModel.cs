namespace Delivery.DAL.Models
{
    /// <summary>
    /// Базовая модель для сущностей
    /// </summary>
    public class BaseModel
    {
        public Guid Id { get;set; } = new Guid();
    }
}
