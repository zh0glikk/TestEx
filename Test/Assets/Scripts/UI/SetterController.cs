using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetterController : MonoBehaviour
{
    private Animator anim;

    private bool isVanished = false;

    [SerializeField]
    private Vector3 leftDir;
    [SerializeField]
    private Vector3 rightDir;
    [SerializeField]
    private Vector3 upDir;
    [SerializeField]
    private Vector3 downDir;

    public Camera camera;
    public Text PopUpText;

    public static GameObject NewGameObject;


    private void Start()
    {
        anim = GetComponent<Animator>();

       
      
    }

    public void ClosePanel()
    {
        UIController.canShopBeOpened = true;
        anim.Play("panelClose");
        Destroy(NewGameObject);
    }

    public void Vanish()
    {
        if (!isVanished)
        {
            anim.Play("panelVanish");
            isVanished = true;
        }
        else
        {
            anim.Play("panelAppear");
            isVanished = false;
        }
    }

    public void LeftBtn()
    {
        Vector3 move = NewGameObject.transform.position + leftDir;

        if (move.z <= (9 - (NewGameObject.GetComponent<LevelObject>().shopIt.width - 2)))
        {

            NewGameObject.transform.position = move;

            camera.transform.position = camera.transform.position + leftDir;
        }

        FindObjectOfType<AudioManager>().Play("arrowClick");
    }

    public void RightBtn()
    {
        Vector3 move = NewGameObject.transform.position + rightDir;

        if (move.z >= -9 )
        {
            NewGameObject.transform.position = move;

            camera.transform.position = camera.transform.position + rightDir;

        }
        FindObjectOfType<AudioManager>().Play("arrowClick");
    }

    public void UpBtn()
    {
        Vector3 move = NewGameObject.transform.position + upDir;

        if (move.x <= (9 - (NewGameObject.GetComponent<LevelObject>().shopIt.width - 2)))
        {
            NewGameObject.transform.position = move;

            camera.transform.position = camera.transform.position + upDir;

        }
        FindObjectOfType<AudioManager>().Play("arrowClick");
    }

    public void DownBtn()
    {
        Vector3 move = NewGameObject.transform.position + downDir;

        if (move.x >= -9)
        {

            NewGameObject.transform.position = move;

            camera.transform.position = camera.transform.position + downDir;

        }

        FindObjectOfType<AudioManager>().Play("arrowClick");
    }

    public void SetBtn()
    {
        if(NewGameObject.GetComponent<LevelObject>().Checher())
        {
            UIController.canShopBeOpened = true;
            GameController CG = GameController.instance;

            CG.OID.Add(NewGameObject.GetComponent<LevelObject>().GetIdOfThisObject());
            

            NewGameObject.GetComponent<LevelObject>().StateChanger();
            NewGameObject.GetComponent<Collider>().isTrigger = true; // set collider as trigger

            anim.Play("panelClose");

            PopUpText.text = "" + NewGameObject.GetComponent<LevelObject>().shopIt.ItemName + " was placed!";
            PopUpText.GetComponent<Animator>().Play("TextAnim");

            FindObjectOfType<AudioManager>().Play("accept");
        }
        else
        {
            PopUpText.text = "Can't be placed here";

            PopUpText.GetComponent<Animator>().Play("WrongTextAnim");
            FindObjectOfType<AudioManager>().Play("reject");
        }
    }
}
