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
    public LayerMask placementLayer;
    private bool isPlacing = false;
    private Vector3 towerSize;
    private string temporaryLayerName = "IgnorePlacement";

    void Start()
    {
        // Ensure the temporary layer exists
        if (LayerMask.NameToLayer(temporaryLayerName) == -1)
        {
            Debug.LogError("Layer 'IgnorePlacement' does not exist. Please create it in the Inspector.");
        }
    }

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
                    placementPosition.y += towerSize.y / 2;  // Adjust the position based on the tower height
                    currentTower.transform.position = placementPosition;

                    // Check for collisions with other objects and objects with the "CantPlace" tag
                    if (!IsColliding(placementPosition) && !IsCollidingWithTag(placementPosition, "CantPlace"))
                    {
                        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
                        {
                            PlaceTower();
                        }
                    }
                }
            }

            // Check for cancel key press (e.g., Escape key)
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
            currentTower.layer = LayerMask.NameToLayer(temporaryLayerName); // Set to temporary layer
            towerSize = currentTower.GetComponent<Renderer>().bounds.size;
        }
    }

    private void PlaceTower()
    {
        if (currentTower != null)
        {
            // Assign the "CantPlace" tag and set to the placement layer
            currentTower.tag = "CantPlace";
            currentTower.layer = LayerMask.NameToLayer("PlacedObjects");
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

    private bool IsColliding(Vector3 position)
    {
        // Use Physics.OverlapBox to check if the placement area is colliding with any other colliders
        Vector3 halfExtents = towerSize / 2;
        Collider[] colliders = Physics.OverlapBox(position, halfExtents, Quaternion.identity, placementLayer);

        // Return true if there are any colliders intersecting, false otherwise
        return colliders.Length > 0;
    }

    private bool IsCollidingWithTag(Vector3 position, string tag)
    {
        Vector3 halfExtents = towerSize / 2;
        Collider[] colliders = Physics.OverlapBox(position, halfExtents, Quaternion.identity, placementLayer);

        // Check if any of the colliders have the specified tag
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(tag))
            {
                return true;
            }
        }

        return false;
    }
}