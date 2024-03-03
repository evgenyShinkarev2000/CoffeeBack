namespace CoffeeBack.Data.Models
{
    public class Entity<T>: EntityBase
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Entity<T> otherEntity){
                return otherEntity.Id == Id;
            }

            return false;
        }

        public override int GetHashCode()
            => Id;
    }
}
