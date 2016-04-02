using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UI : MonoBehaviour {

    private Text scoreBox;
	public Text goalBox;
    public Text player1Box;
    public Text player2Box;

    void Awake()
    {
        
    }

    void Update()
    {
		goalBox.text =( Mathf.Max(0, GameManager.Instance.goalref.GetComponent<Goal>().realFishRequired - Mathf.Max((GameManager.Instance.goalref.GetComponent<Goal>().requiredFish-GameManager.Instance.totalScore),0))).ToString()+"/"+ Mathf.Max(0, GameManager.Instance.goalref.GetComponent<Goal>().realFishRequired);
        player1Box.text = GameManager.Instance.playersScore[0].ToString();
        player2Box.text = GameManager.Instance.playersScore[1].ToString();
    }
	
}
