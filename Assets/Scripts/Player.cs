using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player {

    private GameObject instance = null;
    private InventoryManager pickManager;
    private int noPlayer = 0;
    private float maxSoundRange;
    private float lerpFactor = 0.1f;
    private float nextFire;
    private float fireRate = 1.0f;
    private float angleMax = 90;
    private Animator animator;
    private float MaxRange;
    public Stack<RespawnPoint> respawnPoints = new Stack<RespawnPoint>();
    private Vector3 temporalMovement;
    private Vector3 temporalLookAt;
    private float previousY = 0;
    private bool hasJumped = false;
	private bool hasPlank = false;
    private bool hasDeaded = false;
    private Bassin ocean;
    private float timeSinceDeath = 0;
    private ParticleSystem[] spashlingParticule;
    private float baseEmissionRateMiddle;
    private float baseEmissionRateWave;
    public float dropRange = 3.5f;
    public bool hasGhost;
    public Vector3 lastDeathPos;

    public GameObject GetGameObject() { return instance; }

    public int GetNoPlayer() { return noPlayer; }

    public Player(float playersMaxSoundRange, float playersFireRate, float playersAngleMax,float playersMaxRange)
    {
        maxSoundRange = playersMaxSoundRange;
        fireRate = playersFireRate;
        angleMax = playersAngleMax;
        MaxRange = playersMaxRange;
        GameManager.Instance.GetComponent<AudioManager>().SetgameOverSoundPlay(false);
        GameManager.Instance.gameOver = false;
        ocean = GameObject.FindGameObjectWithTag("OceanRef").GetComponentInParent<Bassin>();
       
    }

    public void UpdatePlayer()
    {
        nextFire -= Time.deltaTime;
        if (nextFire <= fireRate- 0.1f)
        {
            animator.SetBool("IsFishing?", false);
        }
        if (hasDeaded)
            timeSinceDeath += Time.deltaTime;
        /*
        if (timeSinceDeath > GameManager.Instance.getPlayersManager().respawnTimer)
            GameManager.Instance.getPlayersManager().InstantiateAFuckingGhost(this);
        */

    }

    private Vector4 getRespawnInfoFromOtherPlayer(int i)
    {
        float waterLevel = GameObject.Find("Ocean").transform.GetChild(3).transform.position.y;
        bool spawnFound = false;
        Vector4 spawnCoord = new Vector4(0, 0, 0, 0);
        while (!spawnFound && GameManager.Instance.getPlayersManager().players[i].respawnPoints.Count != 0)
        {
            if (GameManager.Instance.getPlayersManager().players[i].respawnPoints.Peek().transform.position.y > waterLevel)
            {
                spawnFound = true;
                spawnCoord = GameManager.Instance.getPlayersManager().players[i].respawnPoints.Peek().transform.position;
                spawnCoord.w = 1;
            }
            else
                GameManager.Instance.getPlayersManager().players[i].respawnPoints.Pop();
        }
        return spawnCoord;
    }

    public Vector4 getRespawnInfo()
    {
        float waterLevel = GameObject.Find("Ocean").transform.GetChild(3).transform.position.y;
        bool spawnFound = false;
        Vector4 spawnCoord = new Vector4(0, 0, 0, 0); ;
        while (!spawnFound && respawnPoints.Count != 0)
        {
            if (respawnPoints.Peek().transform.position.y > waterLevel)
            {
                spawnFound = true;
                spawnCoord = respawnPoints.Peek().transform.position;
                spawnCoord.w = 1;
            }
            else
                respawnPoints.Pop();
        }  
        if (!spawnFound)
        {
            if (noPlayer == 1)
                spawnCoord = getRespawnInfoFromOtherPlayer(1);
            else
                spawnCoord = getRespawnInfoFromOtherPlayer(0);
        }

        return spawnCoord;
    }


    public void Respawn()
    {
        Vector4 spawnInfos = getRespawnInfo();

        
        if (spawnInfos.w == 1)
        {
            GameObject obj = Resources.Load("Player" + noPlayer) as GameObject;
            instance = (GameObject)Object.Instantiate(obj, new Vector3(spawnInfos.x+ (noPlayer == 1?1:-1), spawnInfos.y, spawnInfos.z), Quaternion.AngleAxis(-45, Vector3.up));
            pickManager = instance.gameObject.GetComponent<InventoryManager>();
            animator = instance.GetComponentInChildren<Animator>();
            hasPlank = false;
            pickManager.NoPlayer = noPlayer;
            pickManager.maxAngle = angleMax;
            pickManager.maxPickUpRange = MaxRange;
            animator.SetBool("IsDead?", false);
            hasDeaded = false;
            timeSinceDeath = 0;
            ResetParticule();
        }
    }


    public void InstantiatePlayer()
    {
        Vector4 spawnInfos = GameManager.Instance.getPlayersManager().getSpawnPoint(noPlayer);
        GameManager.Instance.GetComponent<AudioManager>().SetgameOverSoundPlay(false);
        GameManager.Instance.gameOver = false;
        noPlayer = (int)spawnInfos.w;
        hasPlank = false;
        GameObject obj = Resources.Load("Player" + noPlayer) as GameObject;

        if (!GameManager.Instance.getLevelRunning() && GameManager.Instance.currentLevel != 0)
        {
            Transform posSpawn = GameManager.Instance.levelref[GameManager.Instance.currentLevel - 1].transform.FindChild("ConnectStart").transform;
            if (noPlayer == 1)
                spawnInfos = new Vector4(posSpawn.position.x - 0.5f, posSpawn.position.y + 1, posSpawn.position.z, 0);
            else
                spawnInfos = new Vector4(posSpawn.position.x + 0.5f, posSpawn.position.y + 1, posSpawn.position.z, 0);

        }

        instance = (GameObject)Object.Instantiate(obj, new Vector3(spawnInfos.x, spawnInfos.y, spawnInfos.z), Quaternion.AngleAxis(-45, Vector3.up));
        pickManager = instance.gameObject.GetComponent<InventoryManager>();
        animator = instance.GetComponentInChildren<Animator>();
        pickManager.NoPlayer = noPlayer;
        pickManager.maxAngle = angleMax;
        pickManager.maxPickUpRange = MaxRange;
        animator.SetBool("IsDead?", false);
        hasDeaded = false;
        timeSinceDeath = 0;
        ResetParticule();

    }

    private void ResetParticule()
    {
        spashlingParticule = instance.transform.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem element in spashlingParticule)
        {
            if (element.name == "ParticuleMiddle")
                baseEmissionRateMiddle = element.emissionRate;
            else
                baseEmissionRateWave = element.emissionRate;
            element.emissionRate = 0.0f;      //fuck you unity je fais ske je veux
        }
    }

    public void MovePlayer(Vector3 move, float sneak=0)
    {
        if (instance != null && !hasDeaded )
        {
			instance.GetComponent<CharacterMotor> ().inputMoveDirection = (move * 5 *(1.6f-sneak));
			temporalMovement = (move * lerpFactor) + (temporalMovement * (1 - lerpFactor));
			
            //controler.SimpleMove(move * 5);
            int soundRange;
            if (sneak > 0.4f)
            {
                soundRange = 0;
                animator.SetBool("IsSneaking?", true);
            }
            else
            {
                soundRange = 1;
                animator.SetBool("IsSneaking?", false);
            }
            if (move.magnitude > 0.1f)
            {
                instance.transform.LookAt(instance.transform.position + temporalMovement);
            }
            if(move.magnitude < 0.6f)
            {
                soundRange = 0;
            }
            MakeNoise(1.0f, soundRange);


            animator.SetFloat ("Speed", move.magnitude * 5 * Time.deltaTime);
        }
        else
        {
            if (move.magnitude != 0)
            {
                //InstantiatePlayer();
            }
        }
    }

    public void PlayerLookAt (Vector3 direction)
    {
        temporalLookAt = (direction * (2 * lerpFactor)) + (temporalLookAt * (1 - (2 * lerpFactor)));
        if (instance != null && direction.magnitude > 0.5f)
        {
            instance.transform.LookAt(instance.transform.position + Quaternion.Euler(0,-45,0) * temporalLookAt.normalized);
        }
       
    }

    public void Jump(bool val)
    {
        if (instance != null && !hasDeaded)
        {
            if (val && instance.GetComponent<CharacterMotor>().grounded)
            {
                hasJumped = true;
                GameManager.Instance.GetComponent<AudioManager>().JumpSound();
                animator.SetBool("IsInAir?", true);
            }
            if (!val && instance.GetComponent<CharacterMotor>().grounded)
            {
                hasJumped = false;
                previousY = 0;
                animator.SetBool("IsInAir?", false);

            }

            instance.GetComponent<CharacterMotor>().inputJump = val;
        }
        else
        {
            //InstantiatePlayer();      
        }
    }

    public void UpdateJump()
    {
        if (instance != null)
        {
            if (!hasJumped && instance.GetComponent<CharacterMotor>().grounded)
            {
                animator.SetBool("IsInAir?", false);
            }

            if (hasJumped && instance.transform.position.y < previousY)
            {
                animator.SetBool("jumpApex", true);
                hasJumped = false;
                previousY = 0;
            }
            else
            {
                animator.SetBool("jumpApex", false);
            }
            previousY = instance.transform.position.y;
        }
    }

    public void Fish()
    {
		if (instance != null && hasPlank != true && !hasDeaded)
        {
            GameObject pickedUp = pickManager.Pickup("Fish");
            if (pickedUp != null && nextFire < 0)
            {
                nextFire = 0.5f;
                GameManager.Instance.GetComponent<AudioManager>().FishSound();
                animator.SetBool("IsFishing?", true);
                GameObject spear = Object.Instantiate(Resources.Load("Spear"), instance.transform.position + new Vector3(0,1,0), instance.transform.rotation) as GameObject;
                spear.SendMessage("SetTarget",pickedUp,SendMessageOptions.DontRequireReceiver);
                pickedUp.GetComponent<Fish>().isTargeted = true;
                GameManager.Instance.AddScore(noPlayer,1);             
                nextFire = fireRate;
            }
        }
    }

    public void Pickup()
    {
        if (instance != null && !hasDeaded)
        {
            GameObject pickedUp = pickManager.Pickup("Pickable");
            if (!hasPlank && pickedUp != null)
            {
                hasPlank = true;
                animator.SetBool("IsBlocking?", true);
                instance.transform.GetChild(0).gameObject.SetActive(true);
                pickedUp.gameObject.SetActive(false);
                pickedUp.transform.parent = instance.transform;
                instance.transform.GetChild(3).gameObject.SetActive(false);
            }
            else if (hasPlank)
            {
                RaycastHit isWall;
                Debug.Log(dropRange + instance.transform.GetChild(instance.transform.childCount - 1).GetComponent<BoxCollider>().size.x);
                //Debug.DrawRay(instance.transform.position + (2.0f * Vector3.up), instance.transform.forward, Color.blue, 5.0f);

                if (Physics.Raycast(instance.transform.position + Vector3.up, instance.transform.forward, out isWall, dropRange + instance.transform.GetChild(instance.transform.childCount - 1).GetComponent<BoxCollider>().size.x + 1.0f, 1 << 0))
                {
                    Debug.Log(isWall.transform.name);

                }
                else
                {
                    hasPlank = false;
                    animator.SetBool("IsBlocking?", false);
                    instance.transform.GetChild(0).gameObject.SetActive(false);
                    GameObject dropedPlank = instance.transform.GetChild(instance.transform.childCount - 1).gameObject;

                    dropedPlank.gameObject.SetActive(true);
                    /*dropedPlank.GetComponent<Rigidbody>().isKinematic = false;
                    dropedPlank.GetComponent<Rigidbody>().useGravity = true;*/
                    instance.transform.GetChild(3).gameObject.SetActive(true);
                    dropedPlank.transform.localPosition = new Vector3(0, -(instance.GetComponent<CharacterController>().height - dropedPlank.GetComponent<BoxCollider>().size.y / 1.5f), dropRange);
                    dropedPlank.GetComponent<FloatOnTouch>().setVelocity(0.1f);
                    RaycastHit hit;
                    Physics.Raycast(instance.transform.position + (2 * Vector3.up), dropedPlank.transform.position - (instance.transform.position + (2 * Vector3.up)), out hit, 10.0f);
                    if (hit.transform.tag == "Untagged")
                    {
                        //dropedPlank.transform.position = new Vector3 (hit.point, )
                        instance.transform.position += 1.5f * Vector3.up;
                    }
                    if (Physics.Raycast(dropedPlank.transform.position - Vector3.up, Vector3.up, out hit, Mathf.Infinity, 1 << 0))
                    {
                        if (hit.transform.CompareTag("Untagged"))
                        {
                            dropedPlank.transform.position = hit.point + (1.5f * Vector3.up);
                        }
                    }
                    dropedPlank.transform.parent = null;
                    dropedPlank.GetComponent<BoxCollider>().isTrigger = true;
                }



                //dropedPlank.transform.localRotation = hit.transform.rotation;
            }
        }
    }


    public void MakeNoise(float fleeingTime, float speed)
    {
        if (speed >= 1)
        {
            Vector3 pos = instance.transform.position;
            if (speed == 1.0f)
            {
                pos += instance.transform.forward.normalized * 5.0f;
            }
               
            Collider[] hitColliders = Physics.OverlapSphere(instance.transform.position,  maxSoundRange);
            int i = 0;
            while (i < hitColliders.Length)
            {
                if (hitColliders[i].tag == "Fish")
                {
                    //Debug.Log(hitColliders[i].name);
                    //hitColliders[i].SendMessage("HearSound", fleeingTime , SendMessageOptions.DontRequireReceiver);
                    if (hitColliders[i].GetComponent<StateMachine>() != null)
                        hitColliders[i].GetComponent<StateMachine>().HearSound(fleeingTime, instance.gameObject.transform.position);
                }
                i++;
            }
        }
    }

    public void Drown(float submersionLevelTolerence)
    {
        if (!hasDeaded)
        {
            instance.transform.GetChild(3).gameObject.SetActive(false);
            instance.transform.GetChild(4).gameObject.SetActive(false);
			GameManager.Instance.GetComponent<AudioManager>().DeathSound();

            this.instance.transform.position = new Vector3(this.instance.transform.position.x, ocean.getWaterLevelAtMyLocation(this.instance)- submersionLevelTolerence, this.instance.transform.position.z);
            timeSinceDeath = 0;
        }
        foreach (ParticleSystem element in spashlingParticule)
        {
            if (element.name == "ParticuleMiddle")
                element.emissionRate = baseEmissionRateMiddle;
            else
                element.emissionRate = baseEmissionRateWave;
        }
        instance.GetComponent<CharacterMotor>().enabled = false;
		animator.SetBool("IsDead?", true);
        GameObject.Destroy(instance, GameManager.Instance.getPlayersManager().respawnTimer);
        hasDeaded = true;
        lastDeathPos = instance.transform.position;
    }
}
