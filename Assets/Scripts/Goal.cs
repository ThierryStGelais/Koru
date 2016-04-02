using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    [Tooltip("Nombre de poissons requis pour terminer le niveau")]public int requiredFish;

    private int playersInGoal = 0;
    private int levelId;
    public int realFishRequired;
    public int currentLevelScore = 0;
    public float fishPercent = 0;
    private Material matRef;
    private bool playOnce = false;
    private bool singlePlayerMode = false;
    private Animator animator;


    public void SetSinglePlayer(bool boule)
    {
        singlePlayerMode = boule;
    }



    public void SetlevelId(int value)
    {
        levelId = value;

    }

    public void SetrealFishRequired(int value)
    {
        this.realFishRequired = value;
    }

    public void AddScore(int value)
    {
        currentLevelScore += value;
    }

    public void ResetScore()
    {
        currentLevelScore = 0;
        playOnce = false;
    }
    
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.Equals("Player"))
        {
            if (singlePlayerMode)
            {
                playersInGoal += 2;
            }
            else
                playersInGoal += 1;
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        if (playersInGoal == GameManager.Instance.getPlayersManager().playersCount
                    && GameManager.Instance.totalScore >= requiredFish
                    && GameManager.Instance.currentLevel == levelId)
        {
            //Debug.Log("Niveau Terminé");
            foreach(Transform child in transform.parent.transform) {
               if (child.gameObject.CompareTag("Interest")) {
                    Destroy(child.gameObject);
               }
            }
           /* foreach (Bassin child in GameObject.Find("Ocean").GetComponent<Bassin>().childs)
            {
                child.Edge = 1000.0f;
            }  */
            GameObject.Find("Ocean").GetComponent<Bassin>().SaveCurentWaterLevel();
            GameManager.Instance.NextLevel();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (singlePlayerMode)
            {
                playersInGoal -= 2;
            }
            else
                playersInGoal -= 1;
                
        }
        
    }

    // Use this for initialization
    void Awake ()
    {
        realFishRequired = requiredFish;
        matRef = GetComponentInChildren<Renderer>().material;
        matRef.EnableKeyword("_AmmountFish");
        animator = this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.currentLevel == levelId)
        {
            fishPercent = (float)currentLevelScore / this.realFishRequired * 100.0f;
            if (fishPercent >= 100 && playOnce == false)
            {
                GameManager.Instance.GetComponent<AudioManager>().GoalSound();
                playOnce = true;
                animator.SetBool("HaveEnoughFish?", true);
            }
            else if (fishPercent < 100)
            {
                animator.SetBool("HaveEnoughFish?", false);
            }
            matRef.SetFloat("_AmmountFish", fishPercent);
        }

    }
}
