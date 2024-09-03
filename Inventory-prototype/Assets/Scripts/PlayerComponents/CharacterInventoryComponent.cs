using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterInventoryComponent : MonoBehaviour
{
    [SerializeField] private SOItemInventory _itemInventory;
    public event Action<ItemIDs, int> OnItemRecieved; // pass an ID along, maybe with an ENUM value. Check a dictionary to get item info. Easier to save too.
    public event Action OnActivateInventoryMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OnActivateInventoryMenu?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            ItemIDs newlyCreatedItem = GetRandomItemId();
            OnItemRecieved?.Invoke(newlyCreatedItem, 1); // Second value always quantity.
            _itemInventory.AddItemToInventorySlot(newlyCreatedItem, 1);
        }
    }

    private ItemIDs GetRandomItemId()
    {
        int randomIndex = Random.Range(0, Enum.GetNames(typeof(ItemIDs)).Length);
        return (ItemIDs) randomIndex;
    }
}
