using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerOld : MonoBehaviour
{


    public float maxHealth;

    public Transform healthbarForeground;

    [HideInInspector]
    public float currentHealth;
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float rollSpeed;

    [SerializeField]
    float rollTime;

    float horizontalAxis;

    float verticalAxis;

    Rigidbody2D rb;

    GameObject cam;

    CamController camController;

    Vector3 direction;

    bool rolling = false;

    bool actionCooldown = false;

    [SerializeField]
    PolygonCollider2D lightAttackCollider;

    [SerializeField]
    float lightAttackDuration;

    bool lightAttacking = false;

    public float playerLightAttackDamage;

    [SerializeField]
    PolygonCollider2D heavyAttackCollider;

    [SerializeField]
    float heavyAttackDuration;

    public float playerHeavyAttackDamage;

    bool heavyAttacking = false;

    bool lightBlocking = false;

    bool heavyBlocking = false;

    Vector3 lookDirection;

    float lightAttackDamage = 2;

    float heavyAttackDamage = 4;

    float horseAttackDamage = 25;

    float bearAttackDamage = 40;

    float arrowAttackDamage = 2;

    float spearAttackDamage = 9;

    float fireballAttackDamage = 125;

    float polearmAttackDamage = 4;

    float chariotAttackDamage = 10;

    float berserkerAttackDamage = 100;

    float horsebackDistanceToFight = 9;

    float horsebackdistanceToRunaway = 1000;

    float chariotDistanceToRunaway = 3500;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        cam = GameObject.FindGameObjectWithTag("MainCamera");

        camController = cam.GetComponent<CamController>();

        camController.StartFollowingPlayer(transform);

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

            if (camController.startGame)
            {
                if (Input.GetAxis("Horizontal") > 0.001f || Input.GetAxis("Horizontal") < -0.001f)
                {

                    horizontalAxis = Input.GetAxis("Horizontal");
                } else
                {
                    horizontalAxis = 0;
                }

                if (Input.GetAxis("Vertical") > 0.001f || Input.GetAxis("Vertical") < -0.001f)
                {
                    verticalAxis = Input.GetAxis("Vertical");
                }
                else
                {
                    verticalAxis = 0;
                }
                if (Input.GetKeyDown(KeyCode.Space) && !actionCooldown)
                {
                    StartCoroutine(RollSpeedUpdate());
                }

                if (Input.GetMouseButtonDown(0) && !actionCooldown && Input.GetKey(KeyCode.LeftShift))
                {
                    HeavyAttack();
                }
                else if (Input.GetMouseButtonDown(0) && !actionCooldown)
                {
                    LightAttack();
                }

                if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.LeftShift))
                {
                    HeavyBlock();
                }
                else if (Input.GetMouseButton(1))
                {

                    LightBlock();
                }

                if (Input.GetMouseButtonUp(1))
                {

                    lightBlocking = false;
                    heavyBlocking = false;
                }

                lookDirection = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, 0);
                lookDirection.Normalize();
        }


    }

    private void FixedUpdate()
    {
        if (camController.startGame)
        {
            direction = new Vector3(horizontalAxis, verticalAxis, 0);
            direction.Normalize();

            float actionReduction = 1;

            if (lightAttacking)
            {
                actionReduction = 0.8f;
            }
            else if (heavyAttacking)
            {
                actionReduction = 0.6f;
            }

            if (lightBlocking)
            {
                actionReduction = 0.4f;
            } else if (heavyBlocking)
            {
                actionReduction = 0.2f;
            }

            if (rolling)
            {
                rb.MovePosition(transform.position + direction * Time.fixedDeltaTime * rollSpeed * actionReduction);
            }
            else
            {
                rb.MovePosition(transform.position + direction * Time.fixedDeltaTime * moveSpeed * actionReduction);
            }
        }
    }

    void LightAttack()
    {
        RaycastHit2D[] circleCasts = Physics2D.CircleCastAll(transform.position, 0.4f, lookDirection, 1.5f);

        for(int i = 0; i < circleCasts.Length; i++)
        {
            if (circleCasts[i].collider != null && circleCasts[i].collider.CompareTag("Enemy"))
            {
                GameObject enemyHit = circleCasts[i].collider.gameObject;
                AIController enemyHitController = enemyHit.GetComponent<AIController>();
                enemyHitController.TakeHit(playerLightAttackDamage);
            }
        }

        StartCoroutine(LightAttackCooldown());
    }

    void HeavyAttack()
    {
        RaycastHit2D[] circleCasts = Physics2D.CircleCastAll(transform.position, 0.4f, lookDirection, 1.5f);

        for (int i = 0; i < circleCasts.Length; i++)
        {
            if (circleCasts[i].collider != null && circleCasts[i].collider.CompareTag("Enemy"))
            {
                GameObject enemyHit = circleCasts[i].collider.gameObject;
                AIController enemyHitController = enemyHit.GetComponent<AIController>();
                enemyHitController.TakeHit(playerHeavyAttackDamage);
            }
        }


        float rightX = (lookDirection.x * (Mathf.Cos(Mathf.Deg2Rad * 45)) - (lookDirection.y * Mathf.Sin(Mathf.Deg2Rad * 45)));
        float rightY = (lookDirection.x * (Mathf.Sin(Mathf.Deg2Rad * 45)) + (lookDirection.y * Mathf.Cos(Mathf.Deg2Rad * 45)));
        RaycastHit2D[] circleCastsRight = Physics2D.CircleCastAll(transform.position, 0.4f, new Vector3(rightX, rightY, 0), 2);

        for (int i = 0; i < circleCastsRight.Length; i++)
        {
            if (circleCastsRight[i].collider != null && circleCastsRight[i].collider.CompareTag("Enemy"))
            {
                GameObject enemyHit = circleCastsRight[i].collider.gameObject;
                AIController enemyHitController = enemyHit.GetComponent<AIController>();
                enemyHitController.TakeHit(playerHeavyAttackDamage);
            }
        }


        float leftX = (lookDirection.x * (Mathf.Cos(Mathf.Deg2Rad * -45)) - (lookDirection.y * Mathf.Sin(Mathf.Deg2Rad * -45)));
        float leftY = (lookDirection.x * (Mathf.Sin(Mathf.Deg2Rad * -45)) + (lookDirection.y * Mathf.Cos(Mathf.Deg2Rad * -45)));
        RaycastHit2D[] circleCastsLeft = Physics2D.CircleCastAll(transform.position, 0.4f, new Vector3(leftX, leftY, 0), 2);

        for (int i = 0; i < circleCastsLeft.Length; i++)
        {
            if (circleCastsLeft[i].collider != null && circleCastsLeft[i].collider.CompareTag("Enemy"))
            {
                GameObject enemyHit = circleCastsLeft[i].collider.gameObject;
                AIController enemyHitController = enemyHit.GetComponent<AIController>();
                enemyHitController.TakeHit(playerHeavyAttackDamage);
            }
        }
        StartCoroutine(HeavyAttackCooldown());
    }

    void LightBlock()
    {
        lightBlocking = true;
        heavyBlocking = false;
    }

    void HeavyBlock()
    {
        heavyBlocking = true;
        lightBlocking = false;
    }

    public void TakeHit(float damage)
    {
        if (lightBlocking)
        {
            // Block half damage
            currentHealth -= damage / 2;
        }
        else if (heavyBlocking)
        {
            // Block most damage
            currentHealth -= damage / 4;
        }
        else
        {
            currentHealth -= damage;
        }

        currentHealth -= damage;
        healthbarForeground.localScale = new Vector3(currentHealth / maxHealth, healthbarForeground.localScale.y, healthbarForeground.localScale.z);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeHitFromFireball(float damage)
    {
        currentHealth -= damage;
        healthbarForeground.localScale = new Vector3(currentHealth / maxHealth, healthbarForeground.localScale.y, healthbarForeground.localScale.z);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator RollSpeedUpdate()
    {
        rolling = true;
        actionCooldown = true;
        yield return new WaitForSeconds(rollTime);
        rolling = false;
        yield return new WaitForSeconds(rollTime * 2.5f);
        actionCooldown = false;
    }

    IEnumerator LightAttackCooldown()
    {
        lightAttacking = true;
        actionCooldown = true;
        yield return new WaitForSeconds(lightAttackDuration);
        lightAttacking = false;
        yield return new WaitForSeconds(lightAttackDuration * 2.5f);
        actionCooldown = false;
    }

    IEnumerator HeavyAttackCooldown()
    {
        heavyAttacking = true;
        actionCooldown = true;
        yield return new WaitForSeconds(heavyAttackDuration);
        heavyAttacking = false;
        yield return new WaitForSeconds(heavyAttackDuration * 2.5f);
        actionCooldown = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy Arrow")
        {
            TakeHit(arrowAttackDamage);
        }
        else if (collision.tag == "Enemy Fireball")
        {
            TakeHitFromFireball(fireballAttackDamage);
        }
        else if (collision.tag == "Enemy Spear")
        {
            TakeHit(spearAttackDamage);
        }
    }
}
