using RomainUTR.SLToolbox;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text RecapText, InformationsText;

    [SerializeField] private InputActionReference ClickInput, FactoryInput, PowerInput;
    [SerializeField] private ClickEventChannelSO ClickEventChannel, FactoryClickEventChannel, PowerClickEventChannel;

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

        Inventory.Clicks += Inventory.Factories * (1 + Inventory.Power / 10);
        yield return new WaitForSeconds(0.5f);

        RecapText.text = $"CONSOLE > You currenty have {Inventory.Clicks} click(s). You currently have {Inventory.Factories} factory(ies) and {Inventory.Power} of click level.";

        yield return new WaitForSeconds(0.5f);

        int priceOfPower = (Inventory.Power * Inventory.Power) / 2;
        int priceOfFactory = (Inventory.Factories * Inventory.Factories) / 2;

        InformationsText.text = $"CONSOLE > You can : press SPACE for click.\r\nPress B for buy a production unit for {priceOfFactory} if you have enough. If not, nothing happens\r\nPress U for improve you click power for {priceOfPower} if you have enough. If not, nothing happens";
        _canInteract = true;
    }

    private void HandleClick(InputAction.CallbackContext context)
    {
        ClickEventChannel.RaiseEvent();
        StartCoroutine(UpdateUI());
    } 

    private void HandleFactory(InputAction.CallbackContext context)
    {
        int priceOfFactory = (Inventory.Factories * Inventory.Factories) / 2;

        if (_canInteract && Inventory.Clicks >= priceOfFactory)
        {
            FactoryClickEventChannel.RaiseEvent();
            Inventory.Clicks -= priceOfFactory;
            _canInteract = false;
        } 

        StartCoroutine(UpdateUI());
    }

    private void HandlePower(InputAction.CallbackContext context)
    {
        int priceOfPower = (Inventory.Power * Inventory.Power) / 2;

        if (_canInteract && Inventory.Clicks >= priceOfPower)
        {
            PowerClickEventChannel.RaiseEvent();
            Inventory.Clicks -= priceOfPower;
            _canInteract = false;
        }

        StartCoroutine(UpdateUI());
    }
}
