using System;
using UnityEngine;

public class CharacterInventoryController : MonoBehaviour
{
    public event Action<ItemIDs> OnItemRecieved; // pass an ID along, maybe with an ENUM value. Check a dictionary to get item info. Easier to save too.

    
}
