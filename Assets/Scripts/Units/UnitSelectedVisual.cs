using System;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] private Unit unit;

    private MeshRenderer meshRenderer;

    /// <summary>
    /// Use this for intialization for members restricted to this object.
    /// This ensures that fields, properties, etc. are initialized before 
    /// other objects attempt to reference/access them in the Start method.
    /// Awake is called before Start in Unity.
    /// </summary>
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    /// <summary>
    /// Use this for initialization for external events, references, etc.
    /// Start is called after Awake so external objects should have their
    /// no-dependecy members initialized.
    /// </summary>
    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
        UpdateVisual();
    }

    private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (UnitActionSystem.Instance.SelectedUnit == unit)
        {
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }
}
