using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(gridPosition.ToString());

        return sb.ToString();
    }
}
