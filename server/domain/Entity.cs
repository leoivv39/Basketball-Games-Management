namespace main.domain;

public abstract class Entity<TId> where TId : struct
{
    private TId? _id;
    
    protected Entity(TId? id)
    {
        Id = id;
    }

    protected Entity() { }

    public TId? Id
    {
        get => _id;
        set { _id = value; }
    }
}