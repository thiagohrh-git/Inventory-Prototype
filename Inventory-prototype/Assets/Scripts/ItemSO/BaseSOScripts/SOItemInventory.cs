using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemInventory", menuName = "ScriptableObjects/NewItemInventory", order = 1)]
public class SOItemInventory : ScriptableObject
{
    [SerializeField]
    private List<ItemSlotData> _itemSlotDataList = new List<ItemSlotData>();
    public List<ItemSlotData> ItemSlotDataList => _itemSlotDataList; // For simple info fetching.
    [Serializable]
    public class ItemSlotData
    {
        public ItemIDs ItemId;
        public int ItemAmount;
    }

    public void AddItemToInventorySlot(ItemIDs newItemId, int newItemAmount)
    {
        if (newItemAmount <= 0 || newItemId == ItemIDs.DEFAULT)
            return;
        int itemIndex;
        
        if (IsItemAlreadyOnInventory(newItemId, out itemIndex))
        {
            _itemSlotDataList[itemIndex].ItemAmount += newItemAmount;
            return;
        }
        
        ItemSlotData newItemSlot = new ItemSlotData();
        newItemSlot.ItemId = newItemId;
        newItemSlot.ItemAmount = newItemAmount;
        
        _itemSlotDataList.Add(newItemSlot);
    }

    private bool IsItemAlreadyOnInventory(ItemIDs newItemId, out int itemPlacementIndex)
    {
        itemPlacementIndex = 0;
        for (int i = 0; i < _itemSlotDataList.Count; i++)
        {
            if (_itemSlotDataList[i].ItemId == newItemId)
            {
                itemPlacementIndex = i;
                return true;
            }
        }

        return false;
    }

    public void RemoveItemFromInventorySlot(ItemIDs newItemId, int newItemAmount) // If I use an item...
    {
        
    }

    public void UpdateItemList(List<ItemSlotData> updatedItemSlotDataList) // If I change the order of the items on the list...
    {
        
    }
}