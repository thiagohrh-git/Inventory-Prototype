using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "ScriptableObjects/NewItemDatabase", order = 1)]
public class SOItemDatabase : ScriptableObject
{
    [SerializeField] private List<SOItem> _allItensList = new List<SOItem>();
    public List<SOItem> AllItensList => _allItensList;
    public Sprite GetItemSpriteById(ItemIDs newItemId)
    {
        for (int i = 0; i < _allItensList.Count; i++)
        {
            if (_allItensList[i].ItemID == newItemId)
            {
                return _allItensList[i].ItemSprite;
            }
        }
        return null;
    }
}
