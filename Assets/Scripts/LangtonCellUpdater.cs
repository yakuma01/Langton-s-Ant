using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangtonCellUpdater : MonoBehaviour
{
    private bool isEmpty = true;
    [SerializeField] Material emptyMaterial;
    [SerializeField] Material colorMaterial;

    private void OnTriggerExit(Collider other)
    {
        //if (other.tag == "Ant" && isEmpty)
        //{
        //    isEmpty = false;
        //    this.GetComponentInChildren<Renderer>().material = colorMaterial;
        //    this.tag = "CellRight";
        //}
        //else if(other.tag == "Ant" && !isEmpty)
        //{
        //    isEmpty = true;
        //    this.GetComponentInChildren<Renderer>().material = emptyMaterial;
        //    this.tag = "CellLeft";
        //}

        if(other.tag == "Ant")
        {   
            Destroy(this.gameObject); 
        }
    }
}
