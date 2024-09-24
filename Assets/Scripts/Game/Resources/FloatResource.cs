public class FloatResource : Resource<float>
{
    public FloatResource(string name) : base(name) { }
    protected override float _defaultValue => 0f;
    protected override float _minValue => 0f;


    public override void Add(float value)
    {
        if (value < 0)
        {
            throw new System.Exception();
        }
        Value += value;
    }

    public override void Spend(float value)
    {
        if ((value < _minValue) || (Value - value < _minValue))
        {
            throw new System.Exception();
        }
        Value -= value;
    }

    public override bool TrySpend(float value)
    {
        if ((value < _minValue) || (Value - value < _minValue))
        {
            return false;
        }
        Value -= value;
        return true;
    }
}
