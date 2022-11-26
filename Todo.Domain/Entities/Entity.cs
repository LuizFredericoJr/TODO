namespace Todo.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public bool Equals( Entity? other )
        {
            if (other is null) return false;

            return Id == other.Id;
        }
    }

}
