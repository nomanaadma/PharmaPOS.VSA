namespace PharmaPOS.Domain.Common;

public abstract class Entity : IEquatable<Entity>
{
	public int Id { get; init; }
    
	public override bool Equals(object? obj) => Equals(obj as Entity);
	public bool Equals(Entity? other) => other is not null && Id == other.Id && Id != 0 && other.Id != 0;
	public override int GetHashCode() => Id.GetHashCode();
	public static bool operator ==(Entity? left, Entity? right) => Equals(left, right);
	public static bool operator !=(Entity? left, Entity? right) => !Equals(left, right);
}