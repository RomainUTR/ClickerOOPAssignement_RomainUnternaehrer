using UnityEngine;
using System;

public abstract class PurchasableUpgrade : MonoBehaviour
{
    [SerializeField] protected ClickEventChannelSO ClickEventChannelSO;

    public abstract int GetPrice();

    protected abstract void ApplyUpgrade();

    public virtual void TryBuy()
    {
        int currentPrice = GetPrice();

        if (Inventory.Clicks >= currentPrice)
        {
            Inventory.Clicks -= currentPrice;

            ApplyUpgrade();

            if (ClickEventChannelSO != null)
            {
                ClickEventChannelSO.RaiseEvent();
            }
        }
    }
}
