using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]//이제 asset창에서 우클릭하면 create에서 c#스크립트 위에 newItem이라는 항목이 생김.
public class Item : ScriptableObject//데이터를 저장하는데 사용할 수 있는 데이터 컨테이너 에셋. 이것은 게임 오브젝트에 붙일 필요가 없음. Monobehavior로 상속받은 것들은 반드시 게임 오브젝트에 붙여줘야 효력이 있음.
{
    public enum ItemType
    {
        Equipment,
        Book,
        Paper,
        five,
        ten,
        thirty,
        fifty,
        Lever,
        ETC,

    }

    public string itemName;//아이템의 이름
    public ItemType itemType;//아이템의 유형
    public Sprite itemImage;//아이템의 이미지. 이미지는 캔버스에서만 띄울 수 있는데 sprite는 캔버스 필요 없이 world 내 어디에서든 띄울 수 있음.
    public GameObject itemPrefab;//아이템의 프리팸(실체)

    public string weaponType;//무기 유형.(우리 게임에서는 무기 없지만 일단 코드 작성해둠.)

    // hy : 상점에서 인벤토리로 옮길 때, ItemProperty -> Item으로 만들기 위한 생성자
    public Item(string name, Sprite sprite, ItemType itemType, GameObject itemPrefab) {
        this.itemName = name;
        this.itemImage = sprite;
        this.itemType = itemType;
        this.itemPrefab = itemPrefab;
    }
}
