public abstract class Entity
{
    public string Description { get; set; }

    public override string ToString() => Description;
}