using UnityEngine;

public class PowerUpgrade : PurchasableUpgrade
{
    public override int GetPrice()
    {
        return (Inventory.Power * Inventory.Power) / 2;
    }

    protected override void ApplyUpgrade()
    {
        Inventory.Power++;
    }
}
