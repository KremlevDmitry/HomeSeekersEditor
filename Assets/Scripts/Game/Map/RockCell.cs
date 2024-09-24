public class RockCell : Cell<RockCells, RockCellValue>
{
    private void Awake()
    {
        gameObject.AddComponent<RemovableMapObject>();
    }
}
