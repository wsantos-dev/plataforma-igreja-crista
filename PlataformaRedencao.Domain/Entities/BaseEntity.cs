namespace PlataformaRedencao.Domain.Entities
{
    /// <summary>
    /// Abstract base class for domain entities.
    /// Provides unique identity for the entity, distinguishing it from other instances of the same type.
    /// This class should be inherited only by entities that have their own identity and lifecycle in the domain.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Unique identifier of the entity. Defines the entity identity in the domain and is typically assigned by the persistence layer.
        /// </summary>
        public int Id { get; protected set; }

        public override bool Equals(object? obj)
        {
            if (obj is not BaseEntity other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (Id == 0 || other.Id == 0)
                return false;

            return Id == other.Id;
        }
        public override int GetHashCode()
            => Id.GetHashCode();
    }
}
