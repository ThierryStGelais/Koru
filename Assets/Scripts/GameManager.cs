using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayersManager))]

public class GameManager : MonoBehaviour {

    private static GameManager instance = null;
    private PlayersManager playerManager;
    private CameraManager camref;
    private ObjectSpawner[] objectSpawners;
    private bool levelRunning;
    [HideInInspector]
    public bool gameOver;
    //[HideInInspector]
    public int totalScore;
    public List<int> playersScore;
	public GameObject goalref;
    public List<GameObject> levelref;
    public bool singlePlayerMode;
    public int currentLevel;
    public float risingSpeed;
    public float MinWater;
    private Vector3 targetPos;
    private Bassin ocean;
    public int excessFish = 0;
    public float sinkValue = 50;

    public float getSink() { return sinkValue; }

    public PlayersManager getPlayersManager() { return playerManager; }
    public bool getLevelRunning() { return levelRunning; }

    

    public static GameManager Instance
    {
        get 
        {
            return instance;
        }
    }

    private void OnLevelWasLoaded()
    {
        totalScore = 0;
        for (int i=0;i<playersScore.Count;i++)
        {
            playersScore[i] = 0;
        }

        


    }

    private void Awake ()
    {
  
       
       for (int i = 0; i < 2; i++) //Initialise la liste de score
       {
           playersScore.Add(0);
       }
       
        instance = this;
        playerManager = this.gameObject.GetComponent<PlayersManager>();
        getPlayersManager().Awake2();
        //DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization    
    void Start()
    {
        int i = 0;
        foreach (GameObject element in levelref)
        {
            element.GetComponentInChildren<Goal>().SetlevelId(i);
            element.GetComponentInChildren<Goal>().SetSinglePlayer(singlePlayerMode);
            element.GetComponentInChildren<StartPoint>().SetlevelId(i);
            element.GetComponentInChildren<Faucet>().onOff = false;
            i++;

        }
        for (int forint = 1; forint < levelref.Count; forint++)
        {
            levelref[forint].SetActive(false);
            levelref[forint].transform.position -= new Vector3(0, sinkValue, 0);
        }
        goalref = levelref[0].transform.FindChild("Goal").gameObject;
        targetPos = levelref[currentLevel].transform.position;
        camref = FindObjectOfType<CameraManager>();
        ocean = GameObject.FindGameObjectWithTag("OceanRef").GetComponentInParent<Bassin>();
        objectSpawners = levelref[currentLevel].GetComponentsInChildren<ObjectSpawner>();
        foreach (ObjectSpawner element in objectSpawners)
        {
            element.transform.position += new Vector3(0, sinkValue, 0);
            RaycastHit hit;
            Physics.Raycast(element.gameObject.transform.position, Vector3.down, out hit, Mathf.Infinity, 1 << 0);
            //Debug.Log(hit.transform.tag);
            element.transform.position = new Vector3(element.transform.position.x, hit.transform.position.y + 1, element.transform.position.z);
            element.Spawn();
        }


    }

    void Update()
    {

        if (currentLevel <= levelref.Count - 1)
        {
            float step = risingSpeed * Time.deltaTime;
            levelref[currentLevel].transform.position = Vector3.MoveTowards(levelref[currentLevel].transform.position, targetPos, step);
        }
        if(levelref[currentLevel].transform.FindChild("Goal").position.y  < GameObject.FindGameObjectWithTag("OceanRef").GetComponentInParent<Bassin>().getWaterLevelAtMyLocation(levelref[currentLevel].transform.FindChild("Goal").gameObject) && levelRunning)
        {
            if (!GameManager.Instance.GetComponent<AudioManager>().GetgameOverSoundPlay())
            {
                GameManager.Instance.GetComponent<AudioManager>().GameOverSound();
                StartCoroutine(StartPoint.getStartPoint().GetComponent<StartPoint>().RestartDelay());
                GameManager.Instance.GetComponent<AudioManager>().SetgameOverSoundPlay(true);
                gameOver = true;
            }
        }
        if (currentLevel == 0)
        {
            if (playersScore[0] + playersScore[1] == 2)
            {
                levelref[currentLevel].GetComponentInChildren<Faucet>().debit = 10;
            }
        }


    }
    /// <summary>
    /// Ajoute le score au score total et au score personnel
    /// </summary>
    /// <param name="playerId">Conrespond au noPlayer de PLayer.cs</param>
    /// <param name="score">Le score a ajouter</param>
    public void AddScore(int playerId, int score)
    {

        totalScore++;
        playersScore[playerId-1]++;
        goalref.GetComponent<Goal>().AddScore(1);

    }

    public void NextLevel()
    {



        levelref[currentLevel].GetComponentInChildren<Faucet>().onOff = false;
        /* WaterBehaviour[] waterObj = GameObject.FindObjectsOfType<WaterBehaviour>();
          for (int i = 0; i < waterObj.Length; i++)
         {
             GameObject.Destroy(waterObj[i].gameObject);
         }*/
        currentLevel++;
        if (currentLevel <= levelref.Count - 1)
        {
            levelref[currentLevel].SetActive(true);
            excessFish += (totalScore - goalref.GetComponent<Goal>().requiredFish) / 4;
            goalref = levelref[currentLevel].transform.FindChild("Goal").gameObject;
            goalref.GetComponent<Goal>().requiredFish += excessFish;
            goalref.GetComponent<Goal>().SetrealFishRequired(goalref.GetComponent<Goal>().requiredFish - totalScore);
            levelref[currentLevel].transform.position = new Vector3(levelref[currentLevel].transform.position.x, levelref[currentLevel - 1].transform.FindChild("Goal").position.y - sinkValue, levelref[currentLevel].transform.position.z);
            RaiseLevel();
            float distanceBetweenLevel = levelref[currentLevel - 1].transform.FindChild("ConnectStart").position.y - levelref[currentLevel].transform.FindChild("ConnectEnd").position.y;
            camref.SetLevelOrigin(levelref[currentLevel].transform.position + new Vector3(0, distanceBetweenLevel, 0));
            levelRunning = false;
            if (currentLevel >= 2)
                levelref[currentLevel - 2].SetActive(false);
            StartCoroutine("AdjustWaterLevel");
            StartCoroutine("SpawnShit");
        }
        else
            StartCoroutine(WaitAndShowCredit());

        if (currentLevel >= 9)
            StartCoroutine(WaitAndShowCredit());
        // TODO SceneManager.LoadScene("Next scene");
    
    }




    public void RaiseLevel()
    {
        targetPos = new Vector3(levelref[currentLevel].transform.position.x,
            levelref[currentLevel-1].transform.FindChild("ConnectStart").position.y + (levelref[currentLevel].transform.position.y - levelref[currentLevel].transform.FindChild("ConnectEnd").position.y )  , 
            levelref[currentLevel].transform.position.z);
    }

    public void ShowMenu()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        EventSystem es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        es.SetSelectedGameObject(null);
        es.SetSelectedGameObject(es.firstSelectedGameObject);
    }

    public void HideMenu()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void StartLevel(int levelId)
    {
        if (levelId == currentLevel && !levelRunning)
        {

            levelref[currentLevel].GetComponentInChildren<Faucet>().onOff = true;
            GameObject.Find("Ocean").GetComponent<Bassin>().updateNewLevelBassins();
        
           /*
            objectSpawners = levelref[currentLevel].GetComponentsInChildren<ObjectSpawner>();
            foreach (ObjectSpawner element in objectSpawners)
            {
                element.transform.position += new Vector3(0, sinkValue, 0);
                RaycastHit hit;
                Physics.Raycast(element.gameObject.transform.position, Vector3.down, out hit , Mathf.Infinity, 1 <<0);
                Debug.Log(hit.transform.tag);
                element.transform.position = new Vector3(element.transform.position.x, hit.transform.position.y + 1, element.transform.position.z);
                element.Spawn();
            }*/
            Bassin[] bassins = levelref[currentLevel].GetComponentsInChildren<Bassin>();
            foreach (Bassin element in bassins)
            {
                element.isLocked = false;
            }
            Oscilate[] oscilators = levelref[currentLevel].GetComponentsInChildren<Oscilate>();
            foreach (Oscilate element in oscilators)
            {
                element.SetPos();
            }

            levelRunning = true;

        }
    }

    IEnumerator AdjustWaterLevel()
    {
        while (ocean.getWaterLevelAtMyLocation(levelref[currentLevel - 1].transform.FindChild("Goal").gameObject) < levelref[currentLevel - 1].transform.FindChild("Goal").position.y-MinWater)
        {
            yield return StartCoroutine("WaitAndRaise");
            GameObject.Find("Ocean").GetComponent<Bassin>().SaveCurentWaterLevel();
        }


    }

    IEnumerator WaitAndRaise()
    {
        yield return new WaitForSeconds(0.01f);
        ocean.RaiseLevel(5);
    }

    IEnumerator SpawnShit()
    {
        Instance.GetComponent<AudioManager>().LevelLiftSound();
        while (levelref[currentLevel].transform.position.y < targetPos.y)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Instance.GetComponent<AudioManager>().LevelStopSound();
        objectSpawners = levelref[currentLevel].GetComponentsInChildren<ObjectSpawner>();
        foreach (ObjectSpawner element in objectSpawners)
        {
            element.transform.position += new Vector3(0, sinkValue, 0);
            RaycastHit hit;
            Physics.Raycast(element.gameObject.transform.position, Vector3.down, out hit, Mathf.Infinity, 1 << 0);
            //Debug.Log(hit.transform.tag);
            element.transform.position = new Vector3(element.transform.position.x, hit.transform.position.y + 1, element.transform.position.z);
            element.Spawn();
        }
    }

    IEnumerator WaitAndShowCredit()
    {
        yield return new WaitForSeconds(30.0f);
        SceneManager.LoadScene("Credits");
    }
    }




