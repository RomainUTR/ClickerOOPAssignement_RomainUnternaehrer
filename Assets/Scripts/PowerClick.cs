using UnityEngine;

public class PowerClick : MonoBehaviour
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
        Inventory.Power++;
    }
}
