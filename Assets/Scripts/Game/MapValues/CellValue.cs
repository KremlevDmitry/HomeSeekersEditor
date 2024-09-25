public class CellValue
{
    public CellValue(string id, string spriteName, float xPosition, float yPosition, float xScale, float yScale)
    {
        Id = id;
        SpriteName = spriteName;
        XPosition = xPosition;
        YPosition = yPosition;
        XScale = xScale;
        YScale = yScale;
    }

    public string Id;
    public string SpriteName;
    public float XPosition;
    public float YPosition;
    public float XScale;
    public float YScale;

    public override string ToString()
    {
        return $"{Id}\n{SpriteName}\n{XPosition}\n{YPosition}\n{XScale}\n{YScale}\n\n";
    }
}
