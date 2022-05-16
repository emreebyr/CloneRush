using System.Collections;
using System.IO;
using UnityEngine;

public class DrawManager : MonoBehaviour {

    public bool drawing = false;

    public GameObject drawPrefab;
    GameObject theTrail;
    Plane planeObj;
    Vector3 startPos;


    void Start() 
    {
         planeObj = new Plane(Camera.main.transform.forward * -1,this.transform.position);
         transform.position = new Vector3(0f, 1.98f, 18.35422f);

    }
    
	void Update () 
    {   

        if(drawing)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            theTrail = (GameObject)Instantiate(drawPrefab,this.transform.position,Quaternion.identity);

            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float _dis;

            if (planeObj.Raycast(mouseRay, out _dis))
            {
                startPos = mouseRay.GetPoint(_dis);
            }
        }
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
        {
              Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float _dis;
            
            if (planeObj.Raycast(mouseRay, out _dis))
            {
                theTrail.transform.position = mouseRay.GetPoint(_dis);
            }
        }
        }
	}

    public void Paint()
        {   
            
            Invoke("StartPainting",1.6f);

        }
    public void StartPainting()

         {
                drawing = true;
                
         }    
}