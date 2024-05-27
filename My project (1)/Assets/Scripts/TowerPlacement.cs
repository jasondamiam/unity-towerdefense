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
    public LayerMask placementCheck;
    private bool isPlacing = false;
    private float towerHeight;

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
                    placementPosition.y += towerHeight / 2;  // Adjust the position based on the tower height
                    currentTower.transform.position = placementPosition;

                    if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                    {
                        PlaceTower();
                    }
                }
            }

            // Check for cancel key press (e.g., Escape key)
            if (Input.GetKeyDown(KeyCode.Escape))
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