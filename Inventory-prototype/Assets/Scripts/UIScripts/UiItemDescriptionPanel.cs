using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiItemDescriptionPanel : MonoBehaviour
{
    [SerializeField] private Image _myIconImage;
    [SerializeField] private TMP_Text _myTitleTextbox;
    [SerializeField] private TMP_Text _myItemDescriptionBox;
    [SerializeField] private Sprite _defaultSpriteTexture;

    private ItemIDs _lastDisplayedId;

    public void DisplayItem(Sprite newImageSprite, string newItemName, string newItemDescription, ItemIDs itemIDs)
    {
        _myIconImage.sprite = newImageSprite;
        _myTitleTextbox.text = newItemName;
        _myItemDescriptionBox.text = newItemDescription;
        _lastDisplayedId = itemIDs;
    }

    public void DisplayNone() // When will I call this....hmmm....
    {
        _myIconImage.sprite = _defaultSpriteTexture; // Cant be null....hmmm.......
        _myTitleTextbox.text = "";
        _myItemDescriptionBox.text = "";
    }

    public ItemIDs GetLastDisplayedItem()
    {
        return _lastDisplayedId;
    }
}
