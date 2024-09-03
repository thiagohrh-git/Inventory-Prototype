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

    private void OnItemRecieved(ItemIDs newItemId, int itemQuantity)
    {
        Debug.Log($"<color=cyan> New item received! {newItemId} </color>");
    }

    private void AssignEventListeners()
    {
        _characterInventoryComponent.OnActivateInventoryMenu += OnActivateInventoryMenu;
        _characterInventoryComponent.OnItemRecieved += OnItemRecieved;
    }

    private void UnassignEventListeners()
    {
        _characterInventoryComponent.OnActivateInventoryMenu -= OnActivateInventoryMenu;
        _characterInventoryComponent.OnItemRecieved -= OnItemRecieved;
    }
}
