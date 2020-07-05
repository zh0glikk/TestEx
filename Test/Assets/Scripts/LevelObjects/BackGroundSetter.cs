using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSetter : MonoBehaviour
{
    [SerializeField]
    private GameObject[] decor;
    [SerializeField]
    private int decorAmount;
    [SerializeField]
    private GameObject ParentGameObjectForDecor;


    private void Awake()
    {
        SetDecor(new Vector3(15, 0, 15), new Vector3(12, 0, -12));
        SetDecor(new Vector3(15, 0, -15), new Vector3(-12, 0, -12));
        SetDecor(new Vector3(-15, 0, -15), new Vector3(-12, 0, 12));
        SetDecor(new Vector3(-15, 0, 15), new Vector3(12, 0, 12));
    }


    void SetDecor(Vector3 spawnPositionLeft, Vector3 spawnPositionRight)
    {
        int sideDecorAmount = decorAmount / 4;


        while (sideDecorAmount > 0)
        {
        GameObject newObject =   Instantiate(
                decor[Random.Range(0, decor.Length)],
                new Vector3(Random.Range(spawnPositionLeft.x, spawnPositionRight.x),
                    0,
                    Random.Range(spawnPositionLeft.z, spawnPositionRight.z)),
                Quaternion.identity);

            newObject.transform.parent = ParentGameObjectForDecor.transform;
            sideDecorAmount--;
        }
    }

}
