using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateGrid : MonoBehaviour
{
    public GameObject gridCell;
    public GameObject ParentGameObjectForGridCell;

    void Start()
    {
        for(int x = 9; x >= -10; x --)
        {
            for(int y = 9; y >= -10; y --)
            {
                Vector3 spawnPosition = new Vector3(x, y, 0);

                GameObject newObject = Instantiate(gridCell,spawnPosition,Quaternion.identity,ParentGameObjectForGridCell.transform);
                //newObject.transform.parent = ParentGameObjectForGridCell.transform;
               
            }
        }

        ParentGameObjectForGridCell.transform.Rotate(90, 0, 0);
        ParentGameObjectForGridCell.transform.position = new Vector3(
            ParentGameObjectForGridCell.transform.position.x + 0.5f,
            ParentGameObjectForGridCell.transform.position.y,
            ParentGameObjectForGridCell.transform.position.z + 0.5f);
    }


}
