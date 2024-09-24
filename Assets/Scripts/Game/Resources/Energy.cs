public class Energy : IntResource
{
    public Energy() : base("Energy") { }

    private int _maxValue => 10;

    public override void Add(int value)
    {
        if (Value + value > _maxValue)
        {
            value = _maxValue - Value;
        }
        base.Add(value);
    }
}
