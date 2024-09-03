using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/NewItem", order = 1)]
public class SOItem : ScriptableObject
{
    [SerializeField] private ItemIDs _itemId;
    [SerializeField] private string _itemDescription;
    [SerializeField] private Sprite _itemSprite;

    public ItemIDs ItemID => _itemId;
    public string ItemDescription => _itemDescription;
    public Sprite ItemSprite => _itemSprite;
}
