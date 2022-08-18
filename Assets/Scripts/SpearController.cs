using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : MonoBehaviour
{
    [HideInInspector]
    public Vector3 targetPosition = Vector3.zero;

    [HideInInspector]
    public AIController target;

    [SerializeField]
    float arrowSpeed;

    [SerializeField]
    float selfDestructTime;

    [SerializeField]
    int penetrationDepth;

    int timesPenetrated;

    float timeLanded = 0;



    [SerializeField]
    CapsuleCollider2D capCollider;

    // Update is called once per frame
    void Update()
    {
        // If reached target start countdown to self destruct and disable collider
        if (targetPosition == transform.position)
        {
            capCollider.enabled = false;

            if (timeLanded == 0)
            {
                timeLanded = Time.time;
            }

            if (Time.time > timeLanded + selfDestructTime)
            {
                Destroy(gameObject);
            }
        // Else if not at target and not set to default position, move towards target position
        } else if (targetPosition != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, arrowSpeed * Time.deltaTime);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Friendly Spear") && collision.gameObject.CompareTag("Enemy") || gameObject.CompareTag("Enemy Spear") && collision.gameObject.CompareTag("Friendly"))
        {
            timesPenetrated += 1;

            if(timesPenetrated >= penetrationDepth)
            {

                targetPosition = transform.position;
            }
        }
    }
}
