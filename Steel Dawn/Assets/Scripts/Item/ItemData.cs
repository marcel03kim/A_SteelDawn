using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ItemData
{
    public int Id { get; }
    public string Name { get; }
    public string Description { get; }
    public Sprite Icon { get; }

    public ItemData(int id, string name, string description, Sprite icon)
    {
        Id = id;
        Name = name;
        Description = description;
        Icon = icon;
    }
}
