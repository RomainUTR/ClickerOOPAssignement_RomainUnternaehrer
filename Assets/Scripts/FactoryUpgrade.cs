using UnityEngine;

public class FactoryUpgrade : PurchasableUpgrade
{
    public override int GetPrice()
    {
        int basePrice = (Inventory.Factories * Inventory.Factories) / 2;

        if (Inventory.IsDiscountActive)
        {
            return basePrice / 2;
        } else
        {
            return basePrice;
        }
    }

    protected override void ApplyUpgrade()
    {
        Inventory.Factories++;
    }
}
