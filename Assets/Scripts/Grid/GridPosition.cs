
/// <summary>
/// This is used with the custom grid system.
/// Using this instead of Vector2Int makes the code more readable
/// and reduces complexity with translating y with z with the Vector2Int struct.
/// </summary>
public struct GridPosition
{
    public int x;
    public int z;

    public GridPosition(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public override string ToString()
    {
        return $"x: {x}; z: {z}";
    }
}