public class IntResource : Resource<int>
{
    public IntResource(string name) : base(name) { }
    protected override int _defaultValue => 0;
    protected override int _minValue => 0;


    public override void Add(int value)
    {
        if (value < 0)
        {
            throw new System.Exception();
        }
        Value += value;
    }

    public override void Spend(int value)
    {
        if ((value < 0) || (Value - value < _minValue))
        {
            throw new System.Exception();
        }
        Value -= value;
    }

    public override bool TrySpend(int value)
    {
        if ((value < 0) || (Value - value < _minValue))
        {
            return false;
        }
        Value -= value;
        return true;
    }
}
