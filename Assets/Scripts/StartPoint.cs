using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartPoint : MonoBehaviour
{

    private int levelId;

    private GameObject spawnP1, spawnP2;
    static int fishiesP1, fishiesP2;
    public static GameObject instance = null;
    private static PlayersManager playerMan;
    public float flameTolerance;
    private int savedScore = 0;

    public static GameObject getStartPoint() { return instance; }


    public void SetlevelId(int value)
    {
        levelId = value;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (instance != gameObject)
            {
                instance = gameObject;
                GameManager.Instance.StartLevel(levelId);
                gameObject.transform.Find("Torch").transform.Find("FireParticule").gameObject.SetActive(true);

                savedScore = GameManager.Instance.totalScore;

                fishiesP1 = GameManager.Instance.playersScore[0];
                fishiesP2 = GameManager.Instance.playersScore[1];
                //GameObject.Find("Ocean").GetComponent<Bassin>().SaveCurentWaterLevel();
                GameManager.Instance.getPlayersManager().spawnPoints[0] = spawnP1;
                GameManager.Instance.getPlayersManager().spawnPoints[1] = spawnP2;
                if (GameManager.Instance.getPlayersManager().players[0].respawnPoints.Count > 0)
                {
                    GameManager.Instance.getPlayersManager().players[0].respawnPoints.Peek().onP1 = false;
                    GameManager.Instance.getPlayersManager().players[0].respawnPoints.Clear();
                }
                if (GameManager.Instance.getPlayersManager().players[1].respawnPoints.Count > 0)
                {
                    GameManager.Instance.getPlayersManager().players[1].respawnPoints.Peek().onP2 = false;
                    GameManager.Instance.getPlayersManager().players[1].respawnPoints.Clear();
                }


            }
        }

    }


    // Use this for initialization
    void OnEnable()
    {

        spawnP1 = gameObject.transform.FindChild("SpawnP1").gameObject;
        spawnP2 = gameObject.transform.FindChild("SpawnP2").gameObject;
        if (playerMan == null) playerMan = GameManager.Instance.getPlayersManager();

    }


    void Update() {
        if (GameObject.Find("Ocean").transform.Find("Water").transform.position.y >= gameObject.transform.position.y + flameTolerance) {
            if(gameObject.transform.Find("Torch").transform.Find("FireParticle")!= null)
                gameObject.transform.Find("Torch").transform.Find("FireParticle").gameObject.SetActive(false);
        }

    }


    public void ResetLevel() {
        if (GameManager.Instance.getLevelRunning())
        {
            GameManager.Instance.GetComponent<AudioManager>().SetgameOverSoundPlay(false);
            GameManager.Instance.gameOver = false;
            GameManager.Instance.playersScore[0] = fishiesP1;
            GameManager.Instance.playersScore[1] = fishiesP2;
            GameManager.Instance.totalScore = savedScore;
            //GameManager.Instance.excessFish = 0;
            GameManager.Instance.goalref.GetComponent<Goal>().ResetScore();
            foreach (GameObject fish in GameObject.FindGameObjectsWithTag("Fish"))
            {
                Destroy(fish);
            }
            foreach (GameObject planche in GameObject.FindGameObjectsWithTag("Pickable"))
            {
                Destroy(planche);
            }
            foreach (Transform child in transform.parent.transform)
            {
                if (child.gameObject.CompareTag("ObjectSpawn"))
                {
                    child.gameObject.GetComponent<ObjectSpawner>().Spawn(); 
                }
            }
            foreach (GameObject respawn in GameObject.FindGameObjectsWithTag("Respawn")) {
                respawn.transform.Find("FireBowl/FireP1").gameObject.SetActive(false);
                respawn.transform.Find("FireBowl/FireP2").gameObject.SetActive(false);
                respawn.transform.Find("FireBowl/FireBoth").gameObject.SetActive(false);
                respawn.transform.Find("FireBowl/SM_Bowl").GetComponent<MeshRenderer>().material = respawn.GetComponent<RespawnPoint>().inactive;

            }
            if (GameManager.Instance.getPlayersManager().players[0].respawnPoints.Count > 0)
            {
                GameManager.Instance.getPlayersManager().players[0].respawnPoints.Peek().onP1 = false;
                GameManager.Instance.getPlayersManager().players[0].respawnPoints.Clear();
            }
            if (GameManager.Instance.getPlayersManager().players[1].respawnPoints.Count > 0)
            {
                GameManager.Instance.getPlayersManager().players[1].respawnPoints.Peek().onP2 = false;
                GameManager.Instance.getPlayersManager().players[1].respawnPoints.Clear();
            }
            GameManager.Instance.getPlayersManager().players[0].respawnPoints.Push(gameObject.transform.Find("RespawnPoint").gameObject.GetComponent<RespawnPoint>());
            GameManager.Instance.getPlayersManager().players[1].respawnPoints.Push(gameObject.transform.Find("RespawnPoint").gameObject.GetComponent<RespawnPoint>());

        }

        GameObject.Find("Ocean").GetComponent<Bassin>().ResetToSavedWaterLevel();
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            //Destroy(player.transform.FindChild("BlobShadowProjector").gameObject);
            // Destroy(player.transform.FindChild("Shadow").gameObject);
            Destroy(player);
        }
        for (int i = 0; i < playerMan.players.Count; i++)
            playerMan.SpawnPlayer(true, playerMan.players[i]);

    }

    public IEnumerator RestartDelay() {
        yield return new WaitForSeconds(2.5f);
		ResetLevel ();
    }
}
