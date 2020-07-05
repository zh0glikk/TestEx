using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Asset/Item")]

public class ShopItem : ScriptableObject
{
    public string ItemName;
    public Sprite ItemSprite;
    public GameObject prefab_3d;
    public int width;
}
