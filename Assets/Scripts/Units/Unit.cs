using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private const string isWalkingAnimatorProperty = "IsWalking";

    [SerializeField] private Animator unitAnimator;

    private Vector3 targetPosition;
    private GridPosition gridPosition;

    private void Awake()
    {
        targetPosition = transform.position;
    }

    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);
    }

    private void Update()
    {
        float stoppingDistance = .1f;
        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = MoveUnitToTargetPosition();
            RotateUnitToFaceDirectionMoving(moveDirection);
            unitAnimator.SetBool(isWalkingAnimatorProperty, true);
        }
        else
        {
            unitAnimator.SetBool(isWalkingAnimatorProperty, false);
        }

        GridPosition newgridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if (newgridPosition != gridPosition)
        {
            LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newgridPosition);
            gridPosition = newgridPosition;
        }
    }

    private Vector3 MoveUnitToTargetPosition()
    {
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        float moveSpeed = 4f;
        transform.position += moveSpeed * Time.deltaTime * moveDirection;
        return moveDirection;
    }

    private void RotateUnitToFaceDirectionMoving(Vector3 moveDirection)
    {
        float rotateSpeed = 10f;
        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
