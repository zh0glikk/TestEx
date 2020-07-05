using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public List<int> OID; // list of objects id on the map

    void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "GameObject")
                {

                    OutPutObjectInfo(hit.collider.gameObject);
                }
            }

        }

    }


    void OutPutObjectInfo(GameObject go)
    {
        Debug.Log("Name: " + go.GetComponent<LevelObject>().shopIt.ItemName + ", " +
                    "Width: " + go.GetComponent<LevelObject>().shopIt.width + ", " +
                    "Id: " + go.GetComponent<LevelObject>().GetIdOfThisObject());
    }
}
