using UnityEngine;

public class Click : MonoBehaviour
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
        Inventory.Clicks += (Inventory.Power * Inventory.Power) / (1 + Inventory.Power / 2);
    }
}
