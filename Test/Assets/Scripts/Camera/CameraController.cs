using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float UpBorder = 4f;
    public float DownBorder = -13.5f;

    public float cameraSpeed;
    public float zoomSpeed;

    private float groundWidth;
    private Vector2 startPos;
    private Vector2 currentPos;
    private Vector3 targetPosition;

    private Camera camera;

    private float zoom = 60;

    public static bool canMove = true;



    

    private void Start()
    {
        camera = GetComponent<Camera>();
        groundWidth = (UpBorder - DownBorder);
        targetPosition = transform.position;
    }

    private void Update()
    {
        //Scaling();
        UpdateInput();
    }

    void UpdateInput()
    {
        if (canMove)
        {
            if (Input.GetMouseButtonDown(0) && Input.touchCount != 2)
            {
                startPos = camera.ScreenToViewportPoint(Input.mousePosition);

            }

            else if (Input.GetMouseButtonUp(0) && Input.touchCount != 2)
            {
                currentPos = camera.ScreenToViewportPoint(Input.mousePosition);


                Vector2 direction = currentPos - startPos;


                //transition from one coordinate system to enother one
                float newXDirection = direction.x * Mathf.Cos(-0.785398f) - direction.y * Mathf.Sin(-0.785398f);
                float newYDirection = direction.x * Mathf.Sin(-0.785398f) + direction.y * Mathf.Cos(-0.785398f);


                targetPosition = new Vector3(
                    Mathf.Clamp(transform.position.x - newXDirection * groundWidth, DownBorder, UpBorder),
                    transform.position.y,
                    Mathf.Clamp(transform.position.z - newYDirection * groundWidth, DownBorder, UpBorder));

            }
            if (Input.touchCount == 2)
            {
                Touch firstTouch = Input.GetTouch(0);
                Touch secondTouch = Input.GetTouch(1);

                Vector2 firstTouchPrevPosition = firstTouch.position - firstTouch.deltaPosition;
                Vector2 secondTouchPrevPosition = secondTouch.position - secondTouch.deltaPosition;

                float prevMagnitude = (firstTouchPrevPosition - secondTouchPrevPosition).magnitude;
                float currentMagnitude = (firstTouch.position - secondTouch.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;
                Zoom(difference * 0.01f);
            }
            transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed);
            Zoom(Input.GetAxis("Mouse ScrollWheel"));
        }
    }


    void Zoom(float scalingFactor)
    {
        camera.fieldOfView = Mathf.Clamp(camera.fieldOfView - scalingFactor * zoomSpeed, 20, 60);
    }
}
