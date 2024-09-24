public static class DistanceConverter
{
    public static float ToGame(float distance)
    {
        return distance / 103;
    }

    public static float ToDatabase(float distance)
    {
        return distance * 103;
    }
}
