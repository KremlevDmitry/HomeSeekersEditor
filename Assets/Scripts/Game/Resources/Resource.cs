public abstract class Resource
{
    public Resource(string name)
    {
        _name = name;
    }

    private string _name = default;
    public string Name => _name;
}

public abstract class Resource<T> : Resource
{
    protected Resource(string name) : base(name) { }


    protected T _value = default;

    public T Value
    {
        get
        {
            return _value;
        }
        protected set
        {
            _value = value;
        }
    }
    protected virtual T _defaultValue => default(T);
    protected abstract T _minValue { get; }


    public abstract void Add(T value);

    public abstract void Spend(T value);

    public abstract bool TrySpend(T value);
}