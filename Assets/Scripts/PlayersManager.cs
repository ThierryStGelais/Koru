using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayersManager : MonoBehaviour
{

    
    public List<Player> players = new List<Player>();
    public List<GameObject> spawnPoints = new List<GameObject>();
    [HideInInspector]
    

    public int playersCount = 0;
    public float playersMaxSoundRange = 10.0f;
    public float playersFireRate = 1.0f;
    public float playersAngleMax = 75;
    public float playersMaxRange = 14.0f;
    [HideInInspector]
    public bool gamePaused = false;
    public float respawnTimer = 2.0f;

    public void Awake2()
    {
        for (int i = 1; i < 3; i++)
        {
            players.Add(new Player(playersMaxSoundRange, playersFireRate, playersAngleMax, playersMaxRange));
        }
        for (int i = 0; i < 2; i++)
        {
            players[i].InstantiatePlayer();
        }
    }


    // Use this for initialization
    void OnLevelWasLoaded()
    {
        /*
        for (int i = 1 ; i < 5 ; i++)
        {
            players.Add(new Player(playersMaxSoundRange));
        }*/
        
        
    }

    public Vector4 getSpawnPoint(int id = 0)
    {
        Vector4 spawnInfo;
        if (id == 0)
        {
            spawnInfo = spawnPoints[(playersCount)].transform.position;
            playersCount++;
            spawnInfo.w = playersCount;
        }
        else
        {
            spawnInfo = spawnPoints[id-1].transform.position;
            spawnInfo.w = id;
        }
        return spawnInfo;
    }

	public void GamePause()
	{
		if (gamePaused == true) 
		{
            gamePaused = false;
            gameObject.GetComponent<GameManager>().HideMenu();
            Time.timeScale = 1.0f;
        }
		else
		{
			gamePaused = true;
            gameObject.GetComponent<GameManager>().ShowMenu();
            Time.timeScale = 0.0f;
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)
        {
            if (players[0].GetGameObject() == null && players[1].GetGameObject() == null)
            {
				if (!GameManager.Instance.GetComponent<AudioManager>().GetgameOverSoundPlay()) 
				{
					GameManager.Instance.GetComponent<AudioManager>().GameOverSound();
					StartCoroutine (StartPoint.getStartPoint ().GetComponent<StartPoint> ().RestartDelay ());
                    GameManager.Instance.GetComponent<AudioManager>().SetgameOverSoundPlay(true);
                    GameManager.Instance.gameOver = true;
                }
            }
            else {
                for (int i = 1; i < 3; i++)
                {
                    if (players[i - 1].GetGameObject() == null)
                    {
                        ResetHighlight(i);
                        SpawnPlayer(false, players[i - 1]);
                    }
                    else {
                        Vector3 move = new Vector3(0, 0, 0);
                        Vector3 lookAt = new Vector3(0, 0, 0);
                        float sneak = 0f;

                        move.x = -1 * Input.GetAxis("Horizontal" + i);
                        move.z = -1 * Input.GetAxis("Vertical" + i);

                        lookAt.x = -1 * Input.GetAxis("LookAtH" + i);
                        lookAt.z = Input.GetAxis("LookAtV" + i);

                        sneak = Mathf.Max(Input.GetAxis("SneakTriger" + i), Input.GetButton("Sneak" + i) ? 1 : 0);

                        // Debug.Log(move);
                        //Controle Clavier
                        if (i == 2)
                        {
                            if (Input.GetKey("r"))
                            {
                                sneak = 1;
                            }
                            if (Input.GetKey("w"))
                            {
                                move.z = -1;
                            }
                            if (Input.GetKey("s"))
                            {
                                move.z = move.z + (1);
                            }

                            if (Input.GetKey("a"))
                            {
                                move.x = 1;
                            }
                            if (Input.GetKey("d"))
                            {
                                move.x = move.x + (-1);
                            }

                            if (Input.GetKeyDown("space"))
                            {
                                players[i - 1].Jump(true);
                            }
                            if (Input.GetKeyUp("space"))
                            {
                                players[i - 1].Jump(false);
                            }
                            if (Input.GetKeyDown("e"))
                            {
                                players[i - 1].Fish();
                            }
                            if (Input.GetKeyDown("f"))
                            {
                                players[i - 1].Pickup();
                            }
                            if (Input.GetKeyDown("p"))
                            {
                                GamePause();
                            }
                        }
                        //Fin controle clavier
                        move = Quaternion.AngleAxis(-45, Vector3.up) * move;
                        players[i - 1].MovePlayer(move, sneak);
                        players[i - 1].PlayerLookAt(lookAt);
                        players[i - 1].UpdatePlayer();

                        if (Input.GetButtonDown("Jump" + i))
                        {
                            players[i - 1].Jump(true);
                        }
                        if (Input.GetButtonUp("Jump" + i))
                        {
                            players[i - 1].Jump(false);
                        }
                        players[i - 1].UpdateJump();

                        if (Input.GetButtonDown("Fish" + i) || Input.GetAxis("FishTriger" + i) >= 0.7f)
                        {
                            players[i - 1].Fish();
                        }
                        if (Input.GetButtonDown("Pickup" + i))
                        {
                            players[i - 1].Pickup();
                        }
                    }
                }
            }
        }
        if (Input.GetButtonDown("Cancel"))
        {
            GamePause();
        }
    }

    public void SpawnPlayer(bool force, Player player) {
        if (!GameManager.Instance.gameOver && GameManager.Instance.getLevelRunning())
        {
            if (force)
            {
                player.InstantiatePlayer();
            }
            else
            {
                StartCoroutine(RespawnTimer(player));
            }
        }
        else if(!GameManager.Instance.getLevelRunning())
        {
            if (force)
            {
                player.InstantiatePlayer();
            }
            else
            {
                StartCoroutine(RespawnTimer(player));
            }
        }
    }

    IEnumerator RespawnTimer (Player player)
    {
        if (!player.hasGhost)
        {
            InstantiateAFuckingGhost(player);
            player.hasGhost = true;
        }
        yield return new WaitForSeconds(respawnTimer);
        player.hasGhost = false;
        if (player.GetGameObject() == null)
        {
            player.Respawn();
            
        }
    }

    public void ResetHighlight(int i)
    {
        foreach (GameObject fish in GameObject.FindGameObjectsWithTag("Fish"))
        {

            fish.GetComponent<Fish>().MakeHighlight(i, false);

        }
    }

    public void InstantiateAFuckingGhost(Player crissQueJeVeutMonobehaviourDansLePlayer)
    {
        GameObject ghost = null;
        Vector4 spawninfo = crissQueJeVeutMonobehaviourDansLePlayer.getRespawnInfo();
        if (spawninfo.w == 1)
        {
            switch (crissQueJeVeutMonobehaviourDansLePlayer.GetNoPlayer())
            {
                case 1:
                    ghost = Instantiate(Resources.Load("Player1Ghost") as GameObject, crissQueJeVeutMonobehaviourDansLePlayer.lastDeathPos + new Vector3(0,2,0), Quaternion.identity) as GameObject;
                    break;
                case 2:
                    ghost = Instantiate(Resources.Load("Player2Ghost") as GameObject, crissQueJeVeutMonobehaviourDansLePlayer.lastDeathPos + new Vector3(0, 2, 0), Quaternion.identity) as GameObject;
                    break;
                default:
                    break;
            }
             ghost.GetComponent<GoTowardRespawn>().startMarker = crissQueJeVeutMonobehaviourDansLePlayer.lastDeathPos + new Vector3(0, 2, 0);
             ghost.GetComponent<GoTowardRespawn>().endMarker = spawninfo;
        }


    }
}
