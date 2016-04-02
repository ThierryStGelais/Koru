using UnityEngine;
using System.Collections;


public class RespawnPoint : MonoBehaviour {

    private GameObject bowl;
    
    public Material activeP1, activeP2, activeBoth, inactive;
    public bool onP1, onP2;
	public bool Sound = false;
#if UNITY_EDITOR
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }
#endif

    // Use this for initialization
    void Start () {
        bowl = gameObject.transform.Find("FireBowl").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (onP1 && onP2) {
            activateBoth();
        } else if (onP1) {
            activateP1();
        } else if (onP2) {
            activateP2();
        } else {
            deactivate();
        }

        if (onP1 && GameObject.FindGameObjectWithTag("OceanRef").GetComponentInParent<Bassin>().getWaterLevelAtMyLocation(gameObject)>transform.position.y+ 0.1f )
        {
            onP1 = false;
            GameManager.Instance.getPlayersManager().players[0].respawnPoints.Pop();
            if (GameManager.Instance.getPlayersManager().players[0].respawnPoints.Count > 0)
            {
                GameManager.Instance.getPlayersManager().players[0].respawnPoints.Peek().onP1 = true;
            }
        }
        if (onP2 && GameObject.FindGameObjectWithTag("OceanRef").GetComponentInParent<Bassin>().getWaterLevelAtMyLocation(gameObject) > transform.position.y + 0.1f)
        {
            onP2 = false;
            GameManager.Instance.getPlayersManager().players[1].respawnPoints.Pop();
            if (GameManager.Instance.getPlayersManager().players[1].respawnPoints.Count > 0)
            {
                GameManager.Instance.getPlayersManager().players[1].respawnPoints.Peek().onP2 = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
			if (!Sound) 
			{
				if (Time.timeSinceLevelLoad > 2f) 
				{
					GameManager.Instance.GetComponent<AudioManager>().CheckPointSound();
					Sound = true;
				}
			}
            if (other.name.Contains("1"))
            {
                if (GameManager.Instance.getPlayersManager().players[0].respawnPoints.Count > 0) GameManager.Instance.getPlayersManager().players[0].respawnPoints.Peek().onP1 = false;
                GameManager.Instance.getPlayersManager().players[0].respawnPoints.Push(this);
                onP1 = true;
               
            }
            else if (other.name.Contains("2"))
            {
                if (GameManager.Instance.getPlayersManager().players[1].respawnPoints.Count >0) GameManager.Instance.getPlayersManager().players[1].respawnPoints.Peek().onP2 = false;
                GameManager.Instance.getPlayersManager().players[1].respawnPoints.Push(this);
                onP2 = true;
                
            }

        }

    }

    void activateP1 () {
        bowl.transform.Find("SM_Bowl").gameObject.GetComponent<MeshRenderer>().material = activeP1;
        bowl.transform.Find("FireP1").gameObject.SetActive(true);
    }

    void activateP2() {
        bowl.transform.Find("SM_Bowl").gameObject.GetComponent<MeshRenderer>().material = activeP2;
        bowl.transform.Find("FireP2").gameObject.SetActive(true);

    }

    void activateBoth() {
        bowl.transform.Find("SM_Bowl").gameObject.GetComponent<MeshRenderer>().material = activeBoth;
        bowl.transform.Find("FireP1").gameObject.SetActive(false);
        bowl.transform.Find("FireP2").gameObject.SetActive(false);
        bowl.transform.Find("FireBoth").gameObject.SetActive(true);

    }
    void deactivate() {
        bowl.transform.Find("SM_Bowl").gameObject.GetComponent<MeshRenderer>().material = inactive;
        bowl.transform.Find("FireP1").gameObject.SetActive(false);
        bowl.transform.Find("FireP2").gameObject.SetActive(false);
        bowl.transform.Find("FireBoth").gameObject.SetActive(false);
    }
}
