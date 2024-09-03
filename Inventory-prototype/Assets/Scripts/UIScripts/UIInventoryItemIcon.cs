using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInventoryItemIcon : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    private TMP_Text _itemAmountTextComponent;

    [SerializeField]
    private Image _itemImageComponent;

    [SerializeField] private ItemIDs _itemId;

    [SerializeField] private Button _myButtonComponent;

    public event Action<ItemIDs> OnItemHover;

    private void Start()
    {
        AssignEventsListeners();
    }

    private void OnDestroy()
    {
        RemoveEventsListeners();
    }

    private void OnButtonClicked()
    {
        Debug.Log("<color=green> ButtonClicked!!!! </color>");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnItemHover?.Invoke(_itemId);
        Debug.Log("<color=cyan> Pointer entered!!! </color>");
    }

    public void InitializeUiInventoryItem(int itemAmount, Sprite newImageSprite, ItemIDs newItemId)
    {
        _itemAmountTextComponent.text = itemAmount.ToString();
        _itemImageComponent.sprite = newImageSprite;
        _itemId = newItemId;
    }

    private void AssignEventsListeners()
    {
        _myButtonComponent.onClick.AddListener(OnButtonClicked);
    }

    private void RemoveEventsListeners()
    {
        _myButtonComponent.onClick.RemoveListener(OnButtonClicked);
    }
}
