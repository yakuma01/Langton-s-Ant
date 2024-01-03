using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LangtonManager : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab, antPrefab;
    [SerializeField] int size = 100;

    Camera cam;

    [SerializeField] LangtonAntController ant;

    [SerializeField] Text _stepText;

    // Start is called before the first frame update
    void Start()
    {
        //for(int x = 0; x < size; x++)
        //{
        //    for(int y = 0; y < size; y++)
        //    {
        //        GameObject go = Instantiate(cellPrefab, new Vector3(x, 0, y), Quaternion.identity);
        //        go.transform.SetParent(this.transform);
        //    }
        //}
        InitializeCamera();
    }

    void InitializeCamera()
    {
        //Set camera to orthographic, position in the middle of the grid, and set scale based on grid size
        cam = Camera.main;
        cam.transform.position = new Vector3(size / 2 - 0.5f, 10, size / 2 - 0.5f);
        cam.orthographic = true;
        //Set the camera to size half the resolution
        cam.orthographicSize = size / 2;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) SpawnAntAtMouse();

        //string myString = "Steps: " + ant._steps;
        //_stepText.text = myString;
    }

    void SpawnAntAtMouse()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            int xPos = Mathf.RoundToInt(hit.point.x);
            int zPos = Mathf.RoundToInt(hit.point.z);

            Instantiate(antPrefab, new Vector3(xPos, 0, zPos), Quaternion.identity);
        }
    }
}
