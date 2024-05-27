using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlacement : MonoBehaviour
{
    public GameObject towerPrefab;
    private GameObject currentTower;
    public LayerMask groundLayer;
    private bool isPlacing = false;
    public float towerHeight;

    void Update()
    {
        if (isPlacing)
        {
            if (currentTower != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
                {
                    Vector3 placementPosition = hit.point;
                    placementPosition.y += towerHeight / 2;
                    currentTower.transform.position = placementPosition;

                    if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                    {
                        PlaceTower();
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Z)) 
            {
                CancelPlacement();
            }
        }
    }

    public void StartPlacingTower()
    {
        if (towerPrefab != null)
        {
            isPlacing = true;
            currentTower = Instantiate(towerPrefab);
            towerHeight = currentTower.GetComponent<Renderer>().bounds.size.y;
        }
    }

    private void PlaceTower()
    {
        if (currentTower != null)
        {
            // You can add any additional logic here, like checking for valid placement, etc.
            currentTower = null;
            isPlacing = false;
        }
    }

    private void CancelPlacement()
    {
        if (currentTower != null)
        {
            Destroy(currentTower);
            currentTower = null;
        }
        isPlacing = false;
    }
}
