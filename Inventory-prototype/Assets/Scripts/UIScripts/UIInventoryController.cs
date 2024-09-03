using UnityEngine;

public class UIInventoryController : MonoBehaviour
{
    [SerializeField] private UIinventoryPage _inventoryPageUI;
    [SerializeField] private CharacterInventoryComponent _characterInventoryComponent;
    private readonly int _debuggingItemNumber = 10;
    private void Start()
    {
        AssignEventListeners();
        _inventoryPageUI.InitializeInventoryUI(_debuggingItemNumber);
    }

    private void OnDestroy()
    {
        UnassignEventListeners();
    }

    private void OnActivateInventoryMenu()
    {
        _inventoryPageUI.gameObject.SetActive(!_inventoryPageUI.isActiveAndEnabled);
    }

    private void OnItemListUpdated()
    {
        _inventoryPageUI.UpdateDisplayedInventory();
    }

    private void AssignEventListeners()
    {
        _characterInventoryComponent.OnActivateInventoryMenu += OnActivateInventoryMenu;
        _characterInventoryComponent.OnItemListUpdated += OnItemListUpdated;
    }

    private void UnassignEventListeners()
    {
        _characterInventoryComponent.OnActivateInventoryMenu -= OnActivateInventoryMenu;
        _characterInventoryComponent.OnItemListUpdated -= OnItemListUpdated;
    }
}
