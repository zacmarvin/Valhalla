using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    //Zoom and drag cam controls
    Camera mainCam;
    public float dragSpeed;
    public float zoomMoveSpeed;
    private Vector3 lastDragPosition;

    bool foundPlayer = false;

    Transform playerTransform;

    Camera cam;

    [SerializeField]
    float finalZoomAmount;

    [SerializeField]
    float zoomInSpeed;

    [SerializeField]
    float lerpSpeed;

    public bool startGame = false;



    private void Awake()
    {
        cam = GetComponent<Camera>();
    }    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null)
        {


            if (Input.mouseScrollDelta.y != 0)
            {
                mainCam.orthographicSize -= Input.mouseScrollDelta.y;
                if (mainCam.orthographicSize <= 1)
                {
                    mainCam.orthographicSize = 1;
                }
                if (Input.mouseScrollDelta.y > 0)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z), zoomMoveSpeed * Time.deltaTime * mainCam.orthographicSize);
                }
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 dragDirection = lastDragPosition - Input.mousePosition;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + dragDirection.x, transform.position.y + dragDirection.y, transform.position.z), dragSpeed * Time.deltaTime * mainCam.orthographicSize);

            }


            lastDragPosition = Input.mousePosition;

        }

    }

    private void FixedUpdate()
    {
        if (foundPlayer && playerTransform != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z), lerpSpeed * Time.fixedDeltaTime);
        }

        StartCoroutine(ZoomInToPlayer());

    }

    public void StartFollowingPlayer(Transform player)
    {
        playerTransform = player;
        foundPlayer = true;
    }

    IEnumerator ZoomInToPlayer()
    {
        while(cam.orthographicSize > finalZoomAmount && playerTransform != null)
        {
            yield return new WaitForFixedUpdate();
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, finalZoomAmount, zoomInSpeed * Time.fixedDeltaTime);
            if(cam.orthographicSize - finalZoomAmount < 1)
            {
                startGame = true;
            }

            if (cam.orthographicSize - finalZoomAmount < 0.1f)
            {
                cam.orthographicSize = finalZoomAmount;
            }
        }

        startGame = true;
    }
}
