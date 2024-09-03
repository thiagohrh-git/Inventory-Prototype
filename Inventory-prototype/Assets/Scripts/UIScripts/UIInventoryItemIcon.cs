using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItemIcon : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _itemAmountTextComponent;

    [SerializeField]
    private Image _itemImageComponent;

    public void InitializeUiInventoryItem(int itemAmount, Sprite newImageSprite)
    {
        _itemAmountTextComponent.text = itemAmount.ToString();
        _itemImageComponent.sprite = newImageSprite;
    }
}
