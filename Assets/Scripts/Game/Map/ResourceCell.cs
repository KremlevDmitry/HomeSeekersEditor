public class ResourceCell : Cell<ResourceCells, ResourceCellValue>
{
    private void Awake()
    {
        gameObject.AddComponent<RemovableMapObject>();
    }
}
