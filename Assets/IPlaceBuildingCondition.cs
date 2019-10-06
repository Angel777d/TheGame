using UnityEngine;

public interface IPlaceBuildingCondition
{
    bool IsAllowed();
    Vector3 GetTargetPosition();
    bool HasTarget();
}