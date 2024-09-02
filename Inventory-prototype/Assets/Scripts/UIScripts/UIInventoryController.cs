using UnityEngine;

public class UIInventoryController : MonoBehaviour
{
    [SerializeField] private UIinventoryPage _inventoryPageUI;
    private readonly int _debuggingItemNumber = 10;
    private void Start()
    {
        _inventoryPageUI.InitializeInventoryUI(_debuggingItemNumber);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _inventoryPageUI.gameObject.SetActive(!_inventoryPageUI.isActiveAndEnabled);
        }
    }
}
