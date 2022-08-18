using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIController : MonoBehaviour
{

    // The current state
    [HideInInspector]
    public AIStateController currentState;
    // All possible states
    [HideInInspector]
    public AILightAttackState aiLightAttackState = new AILightAttackState();
    [HideInInspector]
    public AIHeavyAttackState aiHeavyAttackState = new AIHeavyAttackState();
    [HideInInspector]
    public AILightBlockState aiLightBlockState = new AILightBlockState();
    [HideInInspector]
    public AIHeavyBlockState aiHeavyBlockState = new AIHeavyBlockState();
    [HideInInspector]
    public AIRangedAttackState aiRangedAttackState = new AIRangedAttackState();
    [HideInInspector]
    public AIHorsebackAttackState aiHorsebackAttackState = new AIHorsebackAttackState();
    [HideInInspector]
    public AICatapultAttackState aiCatapultAttackState = new AICatapultAttackState();
    [HideInInspector]
    public AIPolearmAttackState aiPolearmAttackState = new AIPolearmAttackState();
    [HideInInspector]
    public AIBearAttackState aiBearAttackState = new AIBearAttackState();
    [HideInInspector]
    public AIChariotAttackState aIChariotAttackState = new AIChariotAttackState();
    [HideInInspector]
    public AIBerserkerAttackState aiBerserkerAttackState = new AIBerserkerAttackState();
    [HideInInspector]
    public AISpearAttackState aiSpearAttackState = new AISpearAttackState();
    [HideInInspector]
    public AIIdleState aiIdleState = new AIIdleState();
    [HideInInspector]
    public AIMoveState aiMoveState = new AIMoveState();
    [HideInInspector]
    public GameObject target;
    [HideInInspector]
    public Transform targetTransform;
    [HideInInspector]
    public AIController targetAIController;
    [HideInInspector]
    public float targetDistance;
    [HideInInspector]
    public bool canMoveUp;
    [HideInInspector]
    public bool canMoveDown;
    [HideInInspector]
    public bool canMoveLeft;
    [HideInInspector]
    public bool canMoveRight;
    [HideInInspector]
    public bool canMoveDiagonalUpRight;
    [HideInInspector]
    public bool canMoveDiagonalDownRight;
    [HideInInspector]
    public bool canMoveDiagonalUpLeft;
    [HideInInspector]
    public bool canMoveDiagonalDownLeft;
    [HideInInspector]
    public float timeSinceLastAttackAction = 0;
    [HideInInspector]
    public float currentHealth;
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public float lightAttackDamage = 2;
    [HideInInspector]
    public float heavyAttackDamage = 4;
    [HideInInspector]
    public float horseAttackDamage = 25;
    [HideInInspector]
    public float bearAttackDamage = 40;
    [HideInInspector]
    public float arrowAttackDamage = 2;
    [HideInInspector]
    public float spearAttackDamage = 25;
    [HideInInspector]
    public float fireballAttackDamage = 125;
    [HideInInspector]
    public float polearmAttackDamage = 4;
    [HideInInspector]
    public float chariotAttackDamage = 10;
    [HideInInspector]
    public float berserkerAttackDamage = 100;
    [HideInInspector]
    public float horsebackDistanceToFight = 9;
    [HideInInspector]
    public float horsebackdistanceToRunaway = 1000;
    [HideInInspector]
    public float chariotDistanceToRunaway = 3500;

    float distanceToFight = 3;
    float rangedDistanceToFight = 750;
    float spearDistanceToFight = 300;
    float catapultDistanceToFight = 1500;
    float polearmDistanceToFight = 9;

    [Range(0f, 25f)]
    public float moveSpeed;

    public float maxHealth = 100;

    public float minAttackWaitTime;

    public float maxAttackWaitTime;

    float evaluateEveryXSecondsMin = 0.05f;

    float evaluateEveryXSecondsMax = 0.25f;

    float evaluateEveryXSeconds;

    public Transform healthbarForeground;

    public GameObject arrowGameObject;

    public GameObject spearGameObject;

    public GameObject fireballGameObject;

    public bool isPlayer;
    enum AttackType { melee, ranged, horseback, shield, catapult, polearm, dualwield, dog, bear, chariot, berserker, spear};

    [SerializeField]
    AttackType thisAttackType;

    enum TypeOfAI { friendly, enemy };

    TypeOfAI thisAIType;

    float lastEvaluatedTime = 0;

    float randomWaitTime = 0;

    SceneManagerScript sceneManagerScript;

    GameObject cam;

    CamController camController;

    float timeSinceAcquiredTarget = 0;

    float reevaluateTargetEveryXSecondsMin = 3;

    float reevaluateTargetEveryXSecondsMax = 12;

    float reevaluateTargetEveryXSeconds;

    // Player specific variables


    float horizontalAxis;

    float verticalAxis;

    bool rolling = false;

    bool actionCooldown = false;

    bool heavyAttacking = false;

    bool lightAttacking = false;

    bool lightBlocking = false;

    bool heavyBlocking = false;

    [SerializeField]
    float rollSpeed;

    [SerializeField]
    float rollTime;

    Vector3 lookDirection;

    [SerializeField]
    PolygonCollider2D lightAttackCollider;

    [SerializeField]
    float lightAttackDuration;

    public float playerLightAttackDamage;

    [SerializeField]
    PolygonCollider2D heavyAttackCollider;

    [SerializeField]
    float heavyAttackDuration;

    public float playerHeavyAttackDamage;

    Vector3 direction;

    private void Awake()
    {
        reevaluateTargetEveryXSeconds = Random.Range(reevaluateTargetEveryXSecondsMin, reevaluateTargetEveryXSecondsMax);

        evaluateEveryXSeconds = Random.Range(evaluateEveryXSecondsMin, evaluateEveryXSecondsMax);

        if(gameObject.CompareTag("Enemy"))
        {
            thisAIType = TypeOfAI.enemy;
        } else if(gameObject.CompareTag("Friendly"))
        {
            thisAIType = TypeOfAI.friendly;
        }

        GameObject sceneManager = GameObject.FindGameObjectWithTag("SceneManager");
        sceneManagerScript = sceneManager.GetComponent<SceneManagerScript>();

        if (thisAIType == TypeOfAI.enemy)
        {
            sceneManagerScript.enemyGameObjects.Add(gameObject);

            sceneManagerScript.enemyTransforms.Add(transform);

            sceneManagerScript.enemyControllers.Add(this);
        }
        else if (thisAIType == TypeOfAI.friendly)
        {
            sceneManagerScript.friendlyGameObjects.Add(gameObject);

            sceneManagerScript.friendlyTransforms.Add(transform);

            sceneManagerScript.friendlyControllers.Add(this);

        }

        currentHealth = maxHealth;

        // Setting these hear because even though they are hidden in inspector they are still taking values that were set in isnpector before hidden
        lightAttackDamage = 2;
        
        heavyAttackDamage = 4;
        
        horseAttackDamage = 25;
        
        bearAttackDamage = 40;
        
        arrowAttackDamage = 2;
        
        spearAttackDamage = 9;
        
        fireballAttackDamage = 125;
        
        polearmAttackDamage = 4;
        
        chariotAttackDamage = 10;
        
        berserkerAttackDamage = 100;
        
        horsebackDistanceToFight = 9;
        
        horsebackdistanceToRunaway = 1000;
        
        chariotDistanceToRunaway = 3500;
    }

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        currentState = aiIdleState;
        currentState.EnterState(this);

        cam = GameObject.FindGameObjectWithTag("MainCamera");

        camController = cam.GetComponent<CamController>();

        if (isPlayer)
        {
            camController.StartFollowingPlayer(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (camController.startGame)
        {
            if (!isPlayer)
            {
                currentState.UpdateState(this);

                if (Time.time - lastEvaluatedTime > evaluateEveryXSeconds)
                {
                    EvaluateState();
                }
            }
            else
            {
                if (Input.GetAxis("Horizontal") > 0.001f || Input.GetAxis("Horizontal") < -0.001f)
                {

                    horizontalAxis = Input.GetAxis("Horizontal");
                }
                else
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
                if (Input.GetKeyDown(KeyCode.Space) && !actionCooldown && !heavyBlocking && !lightBlocking)
                {
                    StartCoroutine(RollSpeedUpdate());
                }

                if (Input.GetMouseButtonDown(0) && !actionCooldown && Input.GetKey(KeyCode.LeftShift) && !heavyBlocking && !lightBlocking)
                {
                    HeavyAttack();
                }
                else if (Input.GetMouseButtonDown(0) && !actionCooldown&& !heavyBlocking && !lightBlocking)
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
    }

    private void FixedUpdate()
    {
        if (camController.startGame)
        {
            if (!isPlayer)
            {

                if (target != null)
                {
                    targetDistance = (transform.position - target.transform.position).sqrMagnitude;
                }
                currentState.FixedUpdateState(this);
            } else
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
                }
                else if (heavyBlocking)
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
    }

    void EvaluateState()
    {
        lastEvaluatedTime = Time.time;

        if(Time.time > timeSinceAcquiredTarget + reevaluateTargetEveryXSeconds)
        {
            ReacquireTarget();
        }

        if(thisAttackType == AttackType.ranged)
        {
            if (target == null)
            {
                if (thisAIType == TypeOfAI.friendly && sceneManagerScript.enemyGameObjects.Count > 0 || thisAIType == TypeOfAI.enemy && sceneManagerScript.friendlyGameObjects.Count > 0)
                {
                    currentState = aiIdleState;
                    currentState.EnterState(this);
                }
            }
            else if (currentState != aiMoveState && targetDistance > rangedDistanceToFight)
            {
                currentState = aiMoveState;
                currentState.EnterState(this);
            }
            else if (targetDistance <= rangedDistanceToFight && randomWaitTime < Time.time)
            {
                FightAndWait();
            }
        } else if(thisAttackType == AttackType.melee || thisAttackType == AttackType.shield || thisAttackType == AttackType.dualwield || thisAttackType == AttackType.berserker)
        {
            if (target == null)
            {
                if (thisAIType == TypeOfAI.friendly && sceneManagerScript.enemyGameObjects.Count > 0 || thisAIType == TypeOfAI.enemy && sceneManagerScript.friendlyGameObjects.Count > 0)
                {
                    currentState = aiIdleState;
                    currentState.EnterState(this);
                }
            }
            else if (currentState != aiMoveState && targetDistance > distanceToFight)
            {
                currentState = aiMoveState;
                currentState.EnterState(this);
            }
            else if (targetDistance <= distanceToFight && randomWaitTime < Time.time)
            {
                FightAndWait();
            }
        } else if(thisAttackType == AttackType.horseback)
        {
            if (target == null)
            {
                if (thisAIType == TypeOfAI.friendly && sceneManagerScript.enemyGameObjects.Count > 0 || thisAIType == TypeOfAI.enemy && sceneManagerScript.friendlyGameObjects.Count > 0)
                {
                    currentState = aiIdleState;
                    currentState.EnterState(this);
                }
            } else if(currentState == aiIdleState && targetDistance > horsebackDistanceToFight)
            {
                currentState = aiMoveState;
                currentState.EnterState(this);
            } else if(targetDistance <= horsebackDistanceToFight && randomWaitTime < Time.time && currentState != aiHorsebackAttackState)
            {
                FightAndWait();
            }
        } else if (thisAttackType == AttackType.catapult)
        {
            if (target == null)
            {
                if (thisAIType == TypeOfAI.friendly && sceneManagerScript.enemyGameObjects.Count > 0 || thisAIType == TypeOfAI.enemy && sceneManagerScript.friendlyGameObjects.Count > 0)
                {
                    currentState = aiIdleState;
                    currentState.EnterState(this);
                }
            }
            else if (currentState != aiMoveState && targetDistance > catapultDistanceToFight)
            {
                currentState = aiMoveState;
                currentState.EnterState(this);
            }
            else if (targetDistance <= catapultDistanceToFight && randomWaitTime < Time.time)
            {
                FightAndWait();
            }
        }
        else if (thisAttackType == AttackType.polearm)
        {
            if (target == null)
            {
                if (thisAIType == TypeOfAI.friendly && sceneManagerScript.enemyGameObjects.Count > 0 || thisAIType == TypeOfAI.enemy && sceneManagerScript.friendlyGameObjects.Count > 0)
                {
                    currentState = aiIdleState;
                    currentState.EnterState(this);
                }
            }
            else if (currentState != aiMoveState && targetDistance > polearmDistanceToFight)
            {
                currentState = aiMoveState;
                currentState.EnterState(this);
            }
            else if (targetDistance <= polearmDistanceToFight && randomWaitTime < Time.time)
            {
                FightAndWait();
            }
        }
        else if (thisAttackType == AttackType.dog)
        {
            if (target == null)
            {
                if (thisAIType == TypeOfAI.friendly && sceneManagerScript.enemyGameObjects.Count > 0 || thisAIType == TypeOfAI.enemy && sceneManagerScript.friendlyGameObjects.Count > 0)
                {
                    currentState = aiIdleState;
                    currentState.EnterState(this);
                }
            }
            else if (currentState != aiMoveState && targetDistance > distanceToFight)
            {
                currentState = aiMoveState;
                currentState.EnterState(this);
            }
            else if (targetDistance <= distanceToFight && randomWaitTime < Time.time)
            {
                FightAndWait();
            }
        }
        else if (thisAttackType == AttackType.bear)
        {
            if (target == null)
            {
                if (thisAIType == TypeOfAI.friendly && sceneManagerScript.enemyGameObjects.Count > 0 || thisAIType == TypeOfAI.enemy && sceneManagerScript.friendlyGameObjects.Count > 0)
                {
                    currentState = aiIdleState;
                    currentState.EnterState(this);
                }
            }
            else if (currentState != aiMoveState && targetDistance > distanceToFight)
            {
                currentState = aiMoveState;
                currentState.EnterState(this);
            }
            else if (targetDistance <= distanceToFight && randomWaitTime < Time.time)
            {
                FightAndWait();
            }
        }
        else if (thisAttackType == AttackType.chariot)
        {
            if (target == null)
            {
                if (thisAIType == TypeOfAI.friendly && sceneManagerScript.enemyGameObjects.Count > 0 || thisAIType == TypeOfAI.enemy && sceneManagerScript.friendlyGameObjects.Count > 0)
                {
                    currentState = aiIdleState;
                    currentState.EnterState(this);
                }
            }
            else if (currentState == aiIdleState)
            {
                FightAndWait();
            }
        }
        else if (thisAttackType == AttackType.spear)
        {
            if (target == null)
            {
                if (thisAIType == TypeOfAI.friendly && sceneManagerScript.enemyGameObjects.Count > 0 || thisAIType == TypeOfAI.enemy && sceneManagerScript.friendlyGameObjects.Count > 0)
                {
                    currentState = aiIdleState;
                    currentState.EnterState(this);
                }
            }
            else if (currentState != aiMoveState && targetDistance > spearDistanceToFight)
            {
                currentState = aiMoveState;
                currentState.EnterState(this);
            }
            else if (targetDistance <= spearDistanceToFight && randomWaitTime < Time.time)
            {
                FightAndWait();
            }
        }
    }

    public GameObject AcquireTarget()
    {

        target = null;

        targetAIController = null;

        targetTransform = null;

        targetDistance = 0;

        if(thisAIType == TypeOfAI.friendly)
        {


            if (sceneManagerScript.enemyGameObjects != null)
            {

                for (int i = 0; i < sceneManagerScript.enemyGameObjects.Count; i++)
                {
                    // If have no target and not already being target by 3 others or this target is closer than current target and not already being target by 3 others or its last possible target
                    if (target == null || (transform.position - sceneManagerScript.enemyTransforms[i].position).sqrMagnitude < targetDistance)
                    {
                        target = sceneManagerScript.enemyGameObjects[i];
                        targetAIController = sceneManagerScript.enemyControllers[i];
                        targetTransform = sceneManagerScript.enemyTransforms[i];
                        targetDistance = (transform.position - sceneManagerScript.enemyTransforms[i].position).sqrMagnitude;
                    }

                    if(thisAttackType == AttackType.melee || thisAttackType == AttackType.bear || thisAttackType == AttackType.dog || thisAttackType == AttackType.berserker || thisAttackType == AttackType.dualwield || thisAttackType == AttackType.shield)
                    {
                        if(targetDistance < distanceToFight)
                        {
                            break;
                        }
                    } else if(thisAttackType == AttackType.spear)
                    {
                        if(targetDistance < spearDistanceToFight)
                        {
                            break;
                        }
                    }
                    else if (thisAttackType == AttackType.horseback)
                    {
                        if (targetDistance < horsebackDistanceToFight)
                        {
                            break;
                        }
                    }
                    else if (thisAttackType == AttackType.ranged)
                    {
                        if (targetDistance < rangedDistanceToFight)
                        {
                            break;
                        }
                    }
                    else if (thisAttackType == AttackType.catapult)
                    {
                        if (targetDistance < catapultDistanceToFight)
                        {
                            break;
                        }
                    }
                    else if (thisAttackType == AttackType.polearm)
                    {
                        if (targetDistance < polearmDistanceToFight)
                        {
                            break;
                        }
                    } else
                    {
                        break;
                    }
                }
            }

        }
        else if(thisAIType == TypeOfAI.enemy)
        {

            // TODO Add player game object transform and controllers to these arrays. Maybe just do i<.Count + 1 and then if i > .count check player

            if (sceneManagerScript.friendlyGameObjects != null && sceneManagerScript.friendlyGameObjects.Count > 0)
            {

                for (int i = 0; i < sceneManagerScript.friendlyGameObjects.Count; i++)
                {
                    // If have no target and not already being target by 3 others or this target is closer than current target and not already being target by 3 others or its last possible target
                    if (target == null || (transform.position - sceneManagerScript.friendlyTransforms[i].position).sqrMagnitude < targetDistance)
                    {
                        target = sceneManagerScript.friendlyGameObjects[i];
                        targetAIController = sceneManagerScript.friendlyControllers[i];
                        targetTransform = sceneManagerScript.friendlyTransforms[i];
                        targetDistance = (transform.position - sceneManagerScript.friendlyTransforms[i].position).sqrMagnitude;
                    }



                    if (thisAttackType == AttackType.melee || thisAttackType == AttackType.bear || thisAttackType == AttackType.dog || thisAttackType == AttackType.berserker || thisAttackType == AttackType.dualwield || thisAttackType == AttackType.shield)
                    {
                        if (targetDistance < distanceToFight)
                        {
                            break;
                        }
                    }
                    else if (thisAttackType == AttackType.spear)
                    {
                        if (targetDistance < spearDistanceToFight)
                        {
                            break;
                        }
                    }
                    else if (thisAttackType == AttackType.horseback)
                    {
                        if (targetDistance < horsebackDistanceToFight)
                        {
                            break;
                        }
                    }
                    else if (thisAttackType == AttackType.ranged)
                    {
                        if (targetDistance < rangedDistanceToFight)
                        {
                            break;
                        }
                    }
                    else if (thisAttackType == AttackType.catapult)
                    {
                        if (targetDistance < catapultDistanceToFight)
                        {
                            break;
                        }
                    }
                    else if (thisAttackType == AttackType.polearm)
                    {
                        if (targetDistance < polearmDistanceToFight)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }

        timeSinceAcquiredTarget = Time.time;

        return target;
    }


    public void ReacquireTarget()
    {
        if(target != null)
        {

            if (thisAIType == TypeOfAI.friendly)
            {


                if (sceneManagerScript.enemyGameObjects != null)
                {

                    for (int i = 0; i < sceneManagerScript.enemyGameObjects.Count; i++)
                    {
                        // If have no target and not already being target by 3 others or this target is closer than current target and not already being target by 3 others or its last possible target
                        if ((transform.position - sceneManagerScript.enemyTransforms[i].position).sqrMagnitude < targetDistance)
                        {
                            target = sceneManagerScript.enemyGameObjects[i];
                            targetAIController = sceneManagerScript.enemyControllers[i];
                            targetTransform = sceneManagerScript.enemyTransforms[i];
                            targetDistance = (transform.position - sceneManagerScript.enemyTransforms[i].position).sqrMagnitude;
                            break;
                        }
                    }
                }

            }
            else if (thisAIType == TypeOfAI.enemy)
            {

                // TODO Add player game object transform and controllers to these arrays. Maybe just do i<.Count + 1 and then if i > .count check player

                if (sceneManagerScript.friendlyGameObjects != null && sceneManagerScript.friendlyGameObjects.Count > 0)
                {

                    for (int i = 0; i < sceneManagerScript.friendlyGameObjects.Count; i++)
                    {
                        // If have no target and not already being target by 3 others or this target is closer than current target and not already being target by 3 others or its last possible target
                        if ((transform.position - sceneManagerScript.friendlyTransforms[i].position).sqrMagnitude < targetDistance)
                        {
                            target = sceneManagerScript.friendlyGameObjects[i];
                            targetAIController = sceneManagerScript.friendlyControllers[i];
                            targetTransform = sceneManagerScript.friendlyTransforms[i];
                            targetDistance = (transform.position - sceneManagerScript.friendlyTransforms[i].position).sqrMagnitude;
                            break;
                        }
                    }
                }

            }

            timeSinceAcquiredTarget = Time.time;

        } else
        {
            AcquireTarget();
        }
    }


    public void TakeHitFromFireball(float damage)
    {
        currentHealth -= damage;

        healthbarForeground.localScale = new Vector3(currentHealth / maxHealth, healthbarForeground.localScale.y, healthbarForeground.localScale.z);

        if (currentHealth <= 0)
        {
            if (thisAIType == TypeOfAI.friendly)
            {
                sceneManagerScript.friendlyGameObjects.Remove(gameObject);
                sceneManagerScript.friendlyTransforms.Remove(transform);
                sceneManagerScript.friendlyControllers.Remove(this);
            }
            else if (thisAIType == TypeOfAI.enemy)
            {
                sceneManagerScript.enemyGameObjects.Remove(gameObject);
                sceneManagerScript.enemyTransforms.Remove(transform);
                sceneManagerScript.enemyControllers.Remove(this);
            }

            Destroy(gameObject);
        }
    }
    
    public void TakeHit(float damage)
    {
        if (thisAttackType == AttackType.shield)
        {
            // Shield types block in between a light block and heavy block always
            currentHealth -= damage / 3;
        }
        else if (currentState == aiLightBlockState)
        {
            // Block half damage
            currentHealth -= damage / 2;
        }
        else if (currentState == aiHeavyBlockState)
        {
            // Block most damage
            currentHealth -= damage / 4;
        }
        else
        {
            currentHealth -= damage;
        }

        healthbarForeground.localScale = new Vector3(currentHealth / maxHealth, healthbarForeground.localScale.y, healthbarForeground.localScale.z);

        if(currentHealth <= 0)
        {
            if(thisAIType == TypeOfAI.friendly)
            {
                sceneManagerScript.friendlyGameObjects.Remove(gameObject);
                sceneManagerScript.friendlyTransforms.Remove(transform);
                sceneManagerScript.friendlyControllers.Remove(this);
            }
            else if(thisAIType == TypeOfAI.enemy)
            {
                sceneManagerScript.enemyGameObjects.Remove(gameObject);
                sceneManagerScript.enemyTransforms.Remove(transform);
                sceneManagerScript.enemyControllers.Remove(this);
            }


            Destroy(gameObject);
        }
    }

    void FightAndWait()
    {

        // Random wait until next action
        float randomWait = Random.Range(minAttackWaitTime, maxAttackWaitTime);

        randomWaitTime = Time.time + randomWait;

        if (thisAttackType == AttackType.melee)
        {

            int randomActionInt = Random.Range(1, 5);

            switch (randomActionInt)
            {
                case 1:
                    currentState = aiLightAttackState;
                    currentState.EnterState(this);
                    break;
                case 2:
                    currentState = aiLightBlockState;
                    currentState.EnterState(this);
                    break;
                case 3:
                    currentState = aiHeavyAttackState;
                    currentState.EnterState(this);
                    break;
                case 4:
                    currentState = aiHeavyBlockState;
                    currentState.EnterState(this);
                    break;
                default:
                    break;
            }
        }
        else if (thisAttackType == AttackType.ranged)
        {
            currentState = aiRangedAttackState;
            currentState.EnterState(this);
        }
        else if (thisAttackType == AttackType.horseback)
        {
            currentState = aiHorsebackAttackState;
            currentState.EnterState(this);
        }
        else if (thisAttackType == AttackType.shield)
        {
            currentState = aiLightAttackState;
            currentState.EnterState(this);
        }
        else if (thisAttackType == AttackType.catapult)
        {
            currentState = aiCatapultAttackState;
            currentState.EnterState(this);
        }
        else if (thisAttackType == AttackType.polearm)
        {
            int randomActionInt = Random.Range(1, 3);

            switch (randomActionInt)
            {
                case 1:
                    currentState = aiHeavyBlockState;
                    currentState.EnterState(this);
                    break;
                case 2:
                    currentState = aiPolearmAttackState;
                    currentState.EnterState(this);
                    break;
            }
        }
        else if (thisAttackType == AttackType.dualwield)
        {
            int randomActionInt = Random.Range(1, 3);

            switch (randomActionInt)
            {
                case 1:
                    currentState = aiLightAttackState;
                    currentState.EnterState(this);
                    break;
                case 2:
                    currentState = aiHeavyAttackState;
                    currentState.EnterState(this);
                    break;
            }
        }
        else if (thisAttackType == AttackType.dog)
        {
            currentState = aiLightAttackState;
            currentState.EnterState(this);
        }
        else if (thisAttackType == AttackType.bear)
        {
            currentState = aiBearAttackState;
            currentState.EnterState(this);
        }
        else if (thisAttackType == AttackType.chariot)
        {
            currentState = aIChariotAttackState;
            currentState.EnterState(this);
        }
        else if (thisAttackType == AttackType.berserker)
        {
            currentState = aiBerserkerAttackState;
            currentState.EnterState(this);
        }
        else if (thisAttackType == AttackType.spear)
        {
            currentState = aiSpearAttackState;
            currentState.EnterState(this);
        }

    }

    public void SpawnArrow()
    {
        GameObject arrow = Instantiate(arrowGameObject, transform.position, Quaternion.Euler(0, 0, (Mathf.Atan2(transform.position.y - targetTransform.position.y, transform.position.x - targetTransform.position.x) * Mathf.Rad2Deg) + 90));
        ArrowController arrowScript = arrow.GetComponent<ArrowController>();
        arrowScript.targetPosition = targetTransform.position;
        arrowScript.target = targetAIController;
    }
    public void SpawnSpear()
    {
        GameObject spear = Instantiate(spearGameObject, transform.position, Quaternion.Euler(0, 0, (Mathf.Atan2(transform.position.y - targetTransform.position.y, transform.position.x - targetTransform.position.x) * Mathf.Rad2Deg) + 90));
        SpearController spearScript = spear.GetComponent<SpearController>();
        spearScript.targetPosition = targetTransform.position;
        spearScript.target = targetAIController;
    }

    public void SpawnFireball()
    {
        GameObject fireball = Instantiate(fireballGameObject, transform.position, Quaternion.Euler(0, 0, (Mathf.Atan2(transform.position.y - targetTransform.position.y, transform.position.x - targetTransform.position.x) * Mathf.Rad2Deg) + 90));
        FireballController fireballScript = fireball.GetComponent<FireballController>();
        fireballScript.targetPosition = targetTransform.position;
        fireballScript.target = targetAIController;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy Arrow" && thisAIType == TypeOfAI.friendly)
        {
            TakeHit(arrowAttackDamage);
        } else if (collision.tag == "Friendly Arrow" && thisAIType == TypeOfAI.enemy)
        {
            TakeHit(arrowAttackDamage);
        } else if (collision.tag == "Enemy Fireball" && thisAIType == TypeOfAI.friendly)
        {
            TakeHitFromFireball(fireballAttackDamage);
        }
        else if (collision.tag == "Friendly Fireball" && thisAIType == TypeOfAI.enemy)
        {
            TakeHitFromFireball(fireballAttackDamage);
        }
        else if (collision.tag == "Enemy Spear" && thisAIType == TypeOfAI.friendly)
        {
            TakeHit(spearAttackDamage);
        }
        else if (collision.tag == "Friendly Spear" && thisAIType == TypeOfAI.enemy)
        {
            TakeHit(spearAttackDamage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // If this is a chariot
        if (thisAttackType == AttackType.chariot)
        {
            // If this is a friendly and collided with enemy
            if (collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Friendly"))
            {
                // Find enemy in list of enemies
                for (int i = 0; i < sceneManagerScript.enemyGameObjects.Count; i++)
                {
                    if (sceneManagerScript.enemyGameObjects[i] == collision.gameObject)
                    {
                        sceneManagerScript.enemyControllers[i].TakeHit(chariotAttackDamage);
                        break;
                    }
                }
            }
            // If this is a enemy and collided with friendly
            else if (collision.gameObject.CompareTag("Friendly") && gameObject.CompareTag("Enemy"))
            {
                // Find friendly in list of friendlys
                for (int i = 0; i < sceneManagerScript.friendlyGameObjects.Count; i++)
                {
                    if (sceneManagerScript.friendlyGameObjects[i] == collision.gameObject)
                    {
                        sceneManagerScript.friendlyControllers[i].TakeHit(chariotAttackDamage);
                        break;
                    }
                }
            }
        }
    }

    // Player specific functions

    void LightAttack()
    {
        RaycastHit2D[] circleCasts = Physics2D.CircleCastAll(transform.position, 0.4f, lookDirection, 1.5f);

        for (int i = 0; i < circleCasts.Length; i++)
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
}
