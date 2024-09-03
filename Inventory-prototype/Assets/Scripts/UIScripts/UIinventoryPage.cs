using System.Collections.Generic;
using UnityEngine;

public class UIinventoryPage : MonoBehaviour
{
    [SerializeField] private UIInventoryItemIcon _itemIconPrefab; // The base of the item. Will only add those when needed on the page. Populate by getting the info from scriptable.
    [SerializeField] private RectTransform _myContentPanel; // Reference to the father of the displayed items.
    [SerializeField] private SOItemInventory _itemInventory; // Not sure I should keep this here...maybe use a remote event to fetch ONLY the list. Reference does not seem apropriate.
    [SerializeField] private SOItemDatabase _itemDatabase;
    
    List<UIInventoryItemIcon> _listOfUiItems = new List<UIInventoryItemIcon>(); // Main list used to control what items are on what slots. It all becomes a list management game after that.
    
    // No need to initialize the list again. Only populate it when needed.
    public void InitializeInventoryUI(int inventorySize)
    {
        // Adds all the currently held or saved items onto the UI and List.
    }

    public void UpdateDisplayedInventory() // There's already a list on the scriptable...display that one!...and in that case I need...the list...hmmm...
    {
        CreateNewItemDataList(_itemInventory.ItemSlotDataList);
    }

    private void CreateNewItemDataList(List<SOItemInventory.ItemSlotData> newItemSlotDataList)
    {
        // Should delete the old list eventually. But lets do a new one...
        if (_listOfUiItems.Count == 0) // Just add all the items here...
        {
            for (int i = 0; i < newItemSlotDataList.Count; i++)
            {
                Sprite newItemSprite = _itemDatabase.GetItemSpriteById(newItemSlotDataList[i].ItemId);
                
                // Ok! so ...instantiate it for now. Maybe use a pool later on.
                UIInventoryItemIcon newInventoryItemIcon = Instantiate(_itemIconPrefab, Vector3.zero, Quaternion.identity, _myContentPanel.transform);
                newInventoryItemIcon.InitializeUiInventoryItem(newItemSlotDataList[i].ItemAmount, newItemSprite);
                _listOfUiItems.Add(newInventoryItemIcon);
            }
        }
    }
}
