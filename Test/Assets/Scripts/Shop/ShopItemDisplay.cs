using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemDisplay : MonoBehaviour
{
    public ShopItem shopItem;
    public Camera camera;

    public Text itemName;
    public Text itemSize;
    public Image itemImage;

    public GameObject Setter;
    private Animator anim;

    void Start()
    {

        itemName.text = shopItem.ItemName;
        itemSize.text = "Size: " + shopItem.width + " * " + shopItem.width;
        itemImage.sprite = shopItem.ItemSprite;


        anim = Setter.GetComponent<Animator>();
    }

    public void BuyItem()
    {
        anim.Play("panelOpen");
        UIController.canShopBeOpened = false;

        if (!camera.GetComponent<UIController>().isGridVisiable)
        {
            camera.GetComponent<UIController>().GridVision();
        }

        SetterController.NewGameObject = Instantiate(shopItem.prefab_3d, new Vector3(0,0,0), Quaternion.identity);
        camera.transform.position = new Vector3(-10, 8, -10);
    }
}
