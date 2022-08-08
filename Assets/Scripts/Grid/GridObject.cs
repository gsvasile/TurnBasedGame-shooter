using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private List<Unit> unitList;

    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Unit>();
    }

    public void AddUnit(Unit unit)
    {
        unitList.Add(unit);
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    public void RemoveUnit(Unit unit)
    {
        unitList.Remove(unit);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(gridPosition.ToString());
        foreach (Unit unit in unitList)
        {
            sb.AppendLine(unit.ToString());
        }

        return sb.ToString();
    }
}
