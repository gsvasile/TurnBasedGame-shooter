
using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;
    private float cellSize;
    private GridObject[,] gridObjects;

    /// <summary>
    /// Constructor to setup a 2d grid system with width (x), height (z), and 
    /// each grid cell size to create a custom grid system.
    /// </summary>
    public GridSystem(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridObjects = new GridObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                var gridPosition = new GridPosition(x, z);
                gridObjects[x, z] = new GridObject(this, gridPosition);
            }
        }
    }

    /// <summary>
    /// Gets the world position from the width and height.
    /// Assumes from a grid position.
    /// </summary>
    /// <param name="gridPosition">The grid position indicating how 'wide' and 'high' it is.</param>
    /// <returns>The corresponding <see cref="Vector3"/> that pertains to the world position.</returns>
    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }

    /// <summary>
    /// Gets the grid position from a world position.
    /// </summary>
    /// <param name="worldPosition">The world position to translate into a grid position.</param>
    /// <returns>The corresponding <see cref="GridPosition"/> from the given world position.</returns>
    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(Mathf.RoundToInt(worldPosition.x / cellSize),
                                Mathf.RoundToInt(worldPosition.z / cellSize));
    }

    public void CreateDebugObjects(Transform debugPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                var gridPosition = new GridPosition(x, z);

                Transform debugTransform = GameObject.Instantiate(debugPrefab, GetWorldPosition(gridPosition), Quaternion.identity);
                var gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                gridDebugObject.SetGridObject(GetGridObject(gridPosition));
            }
        }
    }

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjects[gridPosition.x, gridPosition.z];
    }
}
