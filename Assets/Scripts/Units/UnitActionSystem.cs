using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; }

    public Unit SelectedUnit { get { return selectedUnit; } }

    public event EventHandler OnSelectedUnitChanged;

    [SerializeField] private Unit selectedUnit;
    [SerializeField] private LayerMask unitPlaneLayerMask;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError($"There is more than one UnitActionSystem! {transform} - {Instance}");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!TryHandleUnitSelection())
            {
                MoveSelectedUnit(MouseWorld.GetPosition());
            }
        }
    }

    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitPlaneLayerMask))
        {
            if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                SetSelectedUnit(unit);
                return true;
            }
        }

        return false;
    }

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;

        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }

    private void MoveSelectedUnit(Vector3 mousePosition)
    {
        if (selectedUnit == null)
        {
            return;
        }

        selectedUnit.Move(MouseWorld.GetPosition());
    }
}
