using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField] private SelectionScript selection;
    [SerializeField] private UITargetScript target;
    [SerializeField] private UIGeneralScript general;

    private void Start()
    {
        general.gameObject.SetActive(true);
        target.gameObject.SetActive(false);

        selection.EvSelected.AddListener(UpdateTarget);
        UpdateTarget();
    }

    private void OnDestroy()
    {
        selection.EvSelected.RemoveListener(UpdateTarget);
    }

    private void UpdateTarget()
    {
        OnTargetChanged(selection.CurrentTarget);
    }

    private void OnTargetChanged(GameObject target)
    {
        var isTarget = target;
        var isGeneral = !isTarget;

        general.gameObject.SetActive(isGeneral);
        this.target.gameObject.SetActive(isTarget);

        this.target.UpdateBuilding(target);
    }
}