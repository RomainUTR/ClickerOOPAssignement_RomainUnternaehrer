using UnityEngine;

public class FactoryClick : MonoBehaviour
{
    [SerializeField] private ClickEventChannelSO ClickEventChannel;

    private void OnEnable()
    {
        ClickEventChannel.OnEventRaised += HandleClick;
    }

    private void OnDisable()
    {
        ClickEventChannel.OnEventRaised -= HandleClick;
    }

    public void HandleClick()
    {
        Inventory.Factories++;
    }
}
