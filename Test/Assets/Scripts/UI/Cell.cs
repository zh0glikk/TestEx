using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell: MonoBehaviour
{
    public Color mOverColor;
    public Color defaultColor;

    public Color EmptyColor;
    public Color NoEmptyColor;


    private Image img;

    public bool isEmpty = true;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void OnMouseOver()
    {
        img.color = mOverColor;
    }

    public void OnMouseExit()
    {
        img.color = defaultColor;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != null)
        {
            if (isEmpty)
            {
                img.color = EmptyColor;
                
            }
            else if (!isEmpty)
                img.color = NoEmptyColor;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject != null)
        {
            img.color = defaultColor;
        }
        
    }
    
}
