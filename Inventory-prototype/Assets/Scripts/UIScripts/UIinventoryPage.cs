using System.Collections.Generic;
using UnityEngine;

public class UIinventoryPage : MonoBehaviour
{
    [SerializeField] private UIInventoryItemIcon _itemIconPrefab; // Prefab of Icon buttons.
    [SerializeField] private RectTransform _myContentPanel; // Reference to the father of the displayed items.
    [SerializeField] private UiItemDescriptionPanel _itemDescriptionPanel;
    
    [Header("Inventory Scriptable Objects")]
    [SerializeField] private SOItemInventory _itemInventory; // Not sure I should keep this here...maybe use a remote event to fetch ONLY the list. Reference does not seem apropriate.
    [SerializeField] private SOItemDatabase _itemDatabase;
    
    List<UIInventoryItemIcon> _listOfUiItems = new List<UIInventoryItemIcon>(); // Main list used to control what items are on what slots. It all becomes a list management game after that.
    
    // No need to initialize the list again. Only populate it when needed.
    public void InitializeInventoryUI(int inventorySize)
    {
        // Adds all the currently held or saved items onto the UI and List.
    }

    public void UpdateDisplayedInventory()
    {
        if (_itemInventory.ItemSlotDataList.Count > _listOfUiItems.Count) // need to add more entries.
        {
            AddMoreUIListEntries(_itemInventory.ItemSlotDataList.Count - _listOfUiItems.Count);
        }
        else if (_itemInventory.ItemSlotDataList.Count < _listOfUiItems.Count) // Need less entries
        {
            TrimUiListEntries(_listOfUiItems.Count - _itemInventory.ItemSlotDataList.Count);
        }

        UpdateUiEntryValues();
    }

    private void UpdateUiEntryValues()
    {
        for (int i = 0; i < _listOfUiItems.Count; i++)
        {
            Sprite newItemSprite = _itemDatabase.GetItemSpriteById(_itemInventory.ItemSlotDataList[i].ItemId);
            _listOfUiItems[i].InitializeUiInventoryItem(_itemInventory.ItemSlotDataList[i].ItemAmount, newItemSprite, _itemInventory.ItemSlotDataList[i].ItemId);
        }
    }

    private void AddMoreUIListEntries(int targetAmount)
    {
        for (int i = 0; i < targetAmount; i++)
        {
            UIInventoryItemIcon newInventoryItemIcon = Instantiate(_itemIconPrefab, Vector3.zero, Quaternion.identity, _myContentPanel.transform);
            AssignIconHoverEvent(newInventoryItemIcon);
            _listOfUiItems.Add(newInventoryItemIcon);
        }
    }

    private void TrimUiListEntries(int targetAmount)
    {
        List<GameObject> _destroyCandidates = new List<GameObject>();
        int trimmingLimit = _listOfUiItems.Count - targetAmount;
        for (int i = _listOfUiItems.Count; i > trimmingLimit; i--)
        {
            UnassignIconHoverEvent(_listOfUiItems[i - 1]);
            _destroyCandidates.Add(_listOfUiItems[i - 1].gameObject);
            _listOfUiItems.RemoveAt(i - 1);
        }
        for (int i = 0; i < _destroyCandidates.Count; i++)
        {
            Destroy(_destroyCandidates[i]);
        }
    }

    private void AssignIconHoverEvent(UIInventoryItemIcon inventoryItemIcon)
    {
        inventoryItemIcon.OnItemHover += OnUiItemHovered;
        inventoryItemIcon.OnItemHoverExit += OnUiItemHoverEnd;
    }

    private void UnassignIconHoverEvent(UIInventoryItemIcon inventoryItemIcon)
    {
        inventoryItemIcon.OnItemHover -= OnUiItemHovered;
        inventoryItemIcon.OnItemHoverExit -= OnUiItemHoverEnd;
    }

    private void OnUiItemHovered(ItemIDs hoveredItemId) // What if....I stop hovering then I check what is the currently displayed ID...if it matches...then go back to zero.
    {
        Sprite newItemSprite = _itemDatabase.GetItemSpriteById(hoveredItemId);
        string itemName = hoveredItemId.ToString(); // Work this out so the underlines get replaced by spaces and you're golden.
        string itemDescription = _itemDatabase.GetItemDescriptionById(hoveredItemId);
        _itemDescriptionPanel.DisplayItem(newItemSprite, itemName, itemDescription, hoveredItemId);
    }

    private void OnUiItemHoverEnd(ItemIDs hoveredItemId)
    {
        if (hoveredItemId == _itemDescriptionPanel.GetLastDisplayedItem())
        {
            _itemDescriptionPanel.DisplayNone();
        }
    }
}
