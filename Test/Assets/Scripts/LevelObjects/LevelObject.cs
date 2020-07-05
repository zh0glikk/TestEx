using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{
    private int _id;
    private int _width;
    private GameObject partSys;

    [SerializeField]
    private List<GameObject> place = new List<GameObject>();  // buffer to keep cells where object is


    public ShopItem shopIt;
    public GameObject Particles;

    private void Start()
    {
        _width = shopIt.width;

        _id = GetInstanceID();

        partSys = Instantiate(Particles,new Vector3(0,0,0), Quaternion.identity);
        partSys.transform.parent = transform;
    }

    private void Update()
    {
        CheckForWholeNumberPosition();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cell"))
        {
            place.Add(collision.gameObject);

        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cell"))
        {
            GameObject currentFreeCell = place.Find(item => item == collision.gameObject);
            place.Remove(currentFreeCell);
        }
    }

    public bool Checher()
    {
        foreach (GameObject go in place)
        {
            if (go.GetComponent<Cell>().isEmpty == true)
            {
                continue;
            }
            else
            {
                return false;
            }
        }
        return true;
    }


    public void StateChanger()
    {
        foreach (GameObject go in place)
        {
            go.GetComponent<Cell>().isEmpty = false;
        }
        Destroy(partSys);
    }

    private void CheckForWholeNumberPosition()
    {
        transform.position = new Vector3(
            Mathf.Round(transform.position.x),
            transform.position.y,
            Mathf.Round(transform.position.z)
            );
        
    }

    public int GetIdOfThisObject()
    {
        return _id;
    }
}
