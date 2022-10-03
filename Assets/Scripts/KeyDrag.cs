using UnityEngine;

[RequireComponent(typeof(Collider))]
public class KeyDrag : NPC
{
    private Camera mainCamera;
    private float CameraZDistance;
    public Transform target;
    private Vector3 originalPos;
    void Start()
    {
        originalPos = transform.position;
        mainCamera = Camera.main;
        CameraZDistance =
            mainCamera.WorldToScreenPoint(transform.position).z; //z axis of the game object for screen view
    }

    //private float counter = 0;

    void OnMouseDrag()
    {
        Vector3 ScreenPosition =
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance); //z axis added to screen point 
        Vector3 NewWorldPosition =
            mainCamera.ScreenToWorldPoint(ScreenPosition); //Screen point converted to world point

        transform.position = NewWorldPosition;
    }
    
    private void OnMouseUp()
    {
        if (Vector3.Distance(transform.position, target.position) < 2.5f)
        {
            transform.position = target.position;
        }
        else
        {
            transform.position = originalPos;
        }
    }

}