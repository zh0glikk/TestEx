using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject Shop;
    public GameObject Grid;

    public GameObject ShopButton;
    public GameObject GridButton;

    public bool isShopOpen = false;
    public static bool canShopBeOpened = true;
    public bool isGridVisiable = true;

    private void Update()
    {
        ShopButton.GetComponent<Button>().interactable = canShopBeOpened;
        GridButton.GetComponent<Button>().interactable = canShopBeOpened;
    }
    public void ShopOpen()
    {
            if (!isShopOpen)
            {
                Shop.SetActive(true);
            CameraController.canMove = false;
            isShopOpen = true;
                FindObjectOfType<AudioManager>().Play("btnClick");
            }
            else if (isShopOpen)
            {
                Shop.SetActive(false);
                StartCoroutine(Wait());
                isShopOpen = false;
                FindObjectOfType<AudioManager>().Play("btnClick");
            }
    }

    public void GridVision()
    {
        if (isGridVisiable)
        {
            Grid.SetActive(false);
            isGridVisiable = false;
            FindObjectOfType<AudioManager>().Play("btnClick");
        }
        else if (!isGridVisiable)
        {
            Grid.SetActive(true);
            isGridVisiable = true;
            FindObjectOfType<AudioManager>().Play("btnClick");
        }
    }



    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.08f);
        CameraController.canMove = true;
    }
}
