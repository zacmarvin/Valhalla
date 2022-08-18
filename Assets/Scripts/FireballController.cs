using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    [HideInInspector]
    public Vector3 targetPosition = Vector3.zero;

    [HideInInspector]
    public AIController target;

    [SerializeField]
    float fireballSpeed;

    [SerializeField]
    CircleCollider2D circleCollider2D;

    [SerializeField]
    float explodeTime;

    [SerializeField]
    float scaleUpSpeed;

    float timeLanded;

    // Update is called once per frame
    void Update()
    {
        // If reached target start countdown to self destruct and disable collider
        if (targetPosition == transform.position)
        {
            circleCollider2D.enabled = true;

            if (timeLanded == 0)
            {
                timeLanded = Time.time;
            }

            if (Time.time > timeLanded + explodeTime)
            {
                Destroy(gameObject);
            }
        // Else if not at target and not set to default position, move towards target position
        } else if (targetPosition != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, fireballSpeed * Time.deltaTime);
        }

        if (circleCollider2D.enabled)
        {
            transform.localScale += new Vector3(scaleUpSpeed * Time.deltaTime, scaleUpSpeed * Time.deltaTime, scaleUpSpeed * Time.deltaTime);
        }


    }
}
