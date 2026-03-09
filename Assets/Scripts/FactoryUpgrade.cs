using UnityEngine;

public class FactoryUpgrade : PurchasableUpgrade
{
    public override int GetPrice()
    {
        return (Inventory.Factories * Inventory.Factories) / 2;
    }

    protected override void ApplyUpgrade()
    {
        Inventory.Factories++;
    }
}
