using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//직렬화, 안의 public 필드들을 밖으로 빼줌.
public class ItemProperty
{
    public string name;
    public Sprite sprite;
    public Item.ItemType itemType;
    public GameObject itemPrefab;
}
