using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterInventoryComponent : MonoBehaviour
{
    [SerializeField] private SOItemInventory _itemInventory;
    public event Action OnItemListUpdated; // pass an ID along, maybe with an ENUM value. Check a dictionary to get item info. Easier to save too.
    public event Action OnActivateInventoryMenu;

    private void Start()
    {
        AssignEventListeners();
    }

    private void OnDestroy()
    {
        UnassignEventListeners();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OnActivateInventoryMenu?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            ItemIDs newlyCreatedItem = GetRandomItemId();
            _itemInventory.AddItemToInventorySlot(newlyCreatedItem, 1);
            OnItemListUpdated?.Invoke();
        }
    }

    private ItemIDs GetRandomItemId()
    {
        int randomIndex = Random.Range(1, Enum.GetNames(typeof(ItemIDs)).Length);
        return (ItemIDs) randomIndex;
    }

    private void OnItemUsed(ItemIDs usedItemId)
    {
       _itemInventory.UseItemFromInventory(usedItemId);
       OnItemListUpdated?.Invoke();
    }

    private void AssignEventListeners()
    {
        GameEvents.PlayerEvents.OnItemUsed += OnItemUsed;
    }

    private void UnassignEventListeners()
    {
        GameEvents.PlayerEvents.OnItemUsed -= OnItemUsed;
    }
}
