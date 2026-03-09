using RomainUTR.SLToolbox;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text RecapText, InformationsText;

    [SerializeField] private InputActionReference ClickInput, FactoryInput, PowerInput;
    [SerializeField] private ClickEventChannelSO ClickEventChannel;

    [SerializeField] private PurchasableUpgrade FactoryUpgrade, PowerUpgrade;

    private bool _canInteract = true;

    private void OnEnable()
    {
        ClickInput.action.performed += HandleClick;
        FactoryInput.action.performed += HandleFactory;
        PowerInput.action.performed += HandlePower;
    }

    private void OnDisable()
    {
        ClickInput.action.performed -= HandleClick;
        FactoryInput.action.performed -= HandleFactory;
        PowerInput.action.performed -= HandlePower;
    }

    private void Start()
    {
        StartCoroutine(UpdateUI());
    }

    public IEnumerator UpdateUI()
    {
        RecapText.text = string.Empty;
        InformationsText.text = string.Empty;

        Inventory.Clicks += Inventory.Factories * (1 + Inventory.Factories / 10);
        yield return new WaitForSeconds(0.25f);

        RecapText.text = $"CONSOLE > You currenty have {Inventory.Clicks} click(s). You currently have {Inventory.Factories} factory(ies) and {Inventory.Power} of click level.";

        yield return new WaitForSeconds(0.25f);

        int priceOfPower = PowerUpgrade.GetPrice();
        int priceOfFactory = FactoryUpgrade.GetPrice();

        InformationsText.text = $"CONSOLE > You can : press SPACE for click.\r\nPress B for buy a production unit for {priceOfFactory} if you have enough. If not, nothing happens\r\nPress U for improve you click power for {priceOfPower} if you have enough. If not, nothing happens";
        _canInteract = true;
    }

    private void HandleClick(InputAction.CallbackContext context)
    {
        if (!_canInteract) return;

        _canInteract = false;

        ClickEventChannel.RaiseEvent();
        StartCoroutine(UpdateUI());
    } 

    private void HandleFactory(InputAction.CallbackContext context)
    {
        if (!_canInteract) return;

        _canInteract = false;

        FactoryUpgrade.GetPrice();
        StartCoroutine(UpdateUI());
    }

    private void HandlePower(InputAction.CallbackContext context)
    {
        if (!_canInteract) return;

        _canInteract = false;

        PowerUpgrade.TryBuy();
        StartCoroutine(UpdateUI());
    }
}
