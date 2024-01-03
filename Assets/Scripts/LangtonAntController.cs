using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LangtonAntController : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] [Range(0.025f, 1)] float timeStep = 0.025f;
    
    public int _steps = 0;
    
    [SerializeField] LayerMask cellLayer;
    [SerializeField] GameObject cellPrefab;

    GameObject cellManager;

    // Start is called before the first frame update
    void Start()
    {
        cellManager = GameObject.FindGameObjectWithTag("Manager");
        StartCoroutine(UpdateAnt());
    }

    // Update is called once per frame
    IEnumerator UpdateAnt()
    {
        //If the ant doesn't hit anything, we turn left and add a fill cell
        if(Physics.CheckSphere(this.transform.position, 0.2f, cellLayer) == false)
        {
            _rotation.y -= 90;       
            Instantiate(cellPrefab, this.transform.position, Quaternion.identity, cellManager.transform);
        }
        transform.eulerAngles = _rotation; 
        transform.position += transform.forward;

        _steps += 1;

        yield return new WaitForSeconds(timeStep);
        StartCoroutine(UpdateAnt());
    }

    private void OnTriggerEnter(Collider other)
    {
        _rotation = transform.eulerAngles;
        if(other.tag == "CellLeft")
        {
            _rotation.y -= 90;
        }
        if (other.tag == "CellRight")
        {
            _rotation.y += 90;
        }
    }
}
