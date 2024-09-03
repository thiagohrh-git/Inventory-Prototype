using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiItemDescriptionPanel : MonoBehaviour
{
    [SerializeField] private Image _myIconImage;
    [SerializeField] private TMP_Text _myTitleTextbox;
    [SerializeField] private TMP_Text _myItemDescriptionBox;

    public void DisplayItem(Sprite newImageSprite, string newItemName, string newItemDescription)
    {
        _myIconImage.sprite = newImageSprite;
        _myTitleTextbox.text = newItemName;
        _myItemDescriptionBox.text = newItemDescription;
    }

    public void DisplayNone()
    {
        _myIconImage.sprite = null;
        _myTitleTextbox.text = "";
        _myItemDescriptionBox.text = "";
    }
}
