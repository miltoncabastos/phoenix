namespace Pheonix.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public bool Actived { get; set; }        

        public void Disable()
        {
            Actived = false;
        }

        public void Activate()
        {
            Actived = true;
        }       
    }
}
