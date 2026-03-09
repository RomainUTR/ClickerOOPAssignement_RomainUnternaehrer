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
        int baseProduction = (Inventory.Power * Inventory.Power) / (1 + Inventory.Power / 2);

        if (Inventory.IsFrenzyActive)
        {
            Inventory.Clicks += baseProduction * 2;
        }
        else
        {
            Inventory.Clicks += baseProduction;
        }
    }
}
