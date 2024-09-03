using System.Collections.Generic;
using UnityEngine;

public class UIinventoryPage : MonoBehaviour
{
    [SerializeField] private UIInventoryItem _itemPrefab; // The base of the item. Will only add those when needed on the page. Populate by getting the info from scriptable.
    [SerializeField] private RectTransform _myContentPanel; // Reference to the father of the displayed items.
    
    List<UIInventoryItem> _listOfUiItems = new List<UIInventoryItem>(); // Main list used to control what items are on what slots. It all becomes a list management game after that.
    
    // No need to initialize the list again. Only populate it when needed.
    public void InitializeInventoryUI(int inventorySize)
    {
        // Adds all the currently held or saved items onto the UI and List.
    }
}
