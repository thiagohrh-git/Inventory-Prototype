using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "ScriptableObjects/NewItemDatabase", order = 1)]
public class SOItemDatabase : ScriptableObject
{
    [SerializeField] private List<SOItem> _allItensList;
    public List<SOItem> AllItensList => _allItensList;
}
