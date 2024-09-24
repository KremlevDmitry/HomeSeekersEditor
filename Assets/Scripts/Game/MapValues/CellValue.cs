public class CellValue
{
    public CellValue(string id, string spriteName, float xPosition, float yPosition)
    {
        Id = id;
        SpriteName = spriteName;
        XPosition = xPosition;
        YPosition = yPosition;
    }

    public string Id;
    public string SpriteName;
    public float XPosition;
    public float YPosition;

    public override string ToString()
    {
        return $"{Id}\n{SpriteName}\n{XPosition}\n{YPosition}\n\n";
    }
}
