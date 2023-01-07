using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    public GameObject ST1Tower;
    private GameObject dummyPlacement;
    public Camera cam;
    public LayerMask mask;
    public bool isBuilding;
   private GameObject hoverTile;
    public Vector2 GetMousePosition(){
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }
    public void  GetHoverTile(){
        Vector2 mousePositon = GetMousePosition();

        RaycastHit2D hit = Physics2D.Raycast(mousePositon, new Vector2(0,0),0.1f, mask, -100, 100);
        if (hit.collider != null) {
            if (MapGen.mapTiles.Contains(hit.collider.gameObject))
        {
              
            if (!MapGen.pathTiles.Contains(hit.collider.gameObject))
            {
                hoverTile = hit.collider.gameObject;
              }
           }
        }
    }
    public void StartBuilding(){
        isBuilding = true;
        dummyPlacement = Instantiate(ST1Tower);
        if (dummyPlacement.GetComponent<Tower>() != null){
            Destroy(dummyPlacement.GetComponent<Tower>());
        }
         if (dummyPlacement.GetComponent<BarrelRotation>() != null){
            Destroy(dummyPlacement.GetComponent<BarrelRotation>());
        }
       
    }
    public void EndBuilding(){
        isBuilding = false;
    }
    public void Start() {
        StartBuilding();
    }
    public void Update(){
        if(isBuilding == true){
            if(dummyPlacement == true){
                GetHoverTile();
                Debug.Log(dummyPlacement.transform.position);
                Debug.Log(hoverTile.transform.position);
                //dummyPlacement.transform.position = hoverTile.transform.position;
            }
        }

    }
}
