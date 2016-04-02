using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {


    private Player player1;
    private Player player2;
    private GameObject cameraObject;
    private Vector3 originalPos;
    private float zoomFactor;
    private Vector3 TargetPos;
    private float speed = 0.5f;

    public float maxZoom;
    public float minZoom;
    public float maxDistBetweenPlayer;


    void Awake()
    {

        
    }

    // Use this for initialization
    void Start()
    {
        originalPos = this.transform.position;
        cameraObject = transform.GetChild(0).gameObject;
        //player1 = FindObjectOfType<GameManager>().GetComponent<PlayersManager>().players[0]; doit trouver une facon d'attendre l'initialisation du game manager
        //player2 = FindObjectOfType<GameManager>().GetComponent<PlayersManager>().players[1];
        player1 = FindObjectOfType<GameManager>().GetComponent<PlayersManager>().players[0];
        player2 = FindObjectOfType<GameManager>().GetComponent<PlayersManager>().players[1];
        TargetPos = (player1.GetGameObject().transform.position * 2 + player2.GetGameObject().transform.position * 2 + (originalPos)) / 5;
        this.transform.position = TargetPos;
        cameraObject.transform.localPosition = new Vector3(0, 0, -maxZoom+((maxZoom-minZoom)* Vector3.Distance(player1.GetGameObject().transform.position, player2.GetGameObject().transform.position) / maxDistBetweenPlayer));
        //Debug.Log("test");
    }
	


	// Update is called once per frame
	void Update () 
    {

        if (player1.GetGameObject() == null && player2.GetGameObject() == null)
        {
            player1 = FindObjectOfType<GameManager>().GetComponent<PlayersManager>().players[0];
            player2 = FindObjectOfType<GameManager>().GetComponent<PlayersManager>().players[1];
        }
        if (player1.GetGameObject() != null && player2.GetGameObject() != null)
        {

            zoomFactor = Vector3.Distance(player1.GetGameObject().transform.position, player2.GetGameObject().transform.position) / maxDistBetweenPlayer;
            TargetPos = (player1.GetGameObject().transform.position * 2 + player2.GetGameObject().transform.position * 2 + (originalPos)) / 5;
            this.transform.position = Vector3.MoveTowards(this.transform.position, TargetPos, speed);
            cameraObject.transform.localPosition = Vector3.Lerp(new Vector3(0, 0, -minZoom), new Vector3(0, 0, -maxZoom), zoomFactor);

        }
        else if (player1.GetGameObject() != null && player2.GetGameObject() == null)
        {

            //zoomFactor = Vector3.Distance(player1.GetGameObject().transform.position, player2.GetGameObject().transform.position) / maxDistBetweenPlayer;
            TargetPos = (player1.GetGameObject().transform.position * 2  + (originalPos)) / 3;
            this.transform.position = Vector3.MoveTowards(this.transform.position, TargetPos, speed);
            cameraObject.transform.localPosition = Vector3.Lerp(new Vector3(0, 0, -minZoom), new Vector3(0, 0, -maxZoom), zoomFactor);

        }
        else if (player1.GetGameObject() == null && player2.GetGameObject() != null)
        {

            //zoomFactor = Vector3.Distance(player1.GetGameObject().transform.position, player2.GetGameObject().transform.position) / maxDistBetweenPlayer;
            TargetPos = (player2.GetGameObject().transform.position * 2 + (originalPos)) / 3;
            this.transform.position = Vector3.MoveTowards(this.transform.position, TargetPos, speed);
            cameraObject.transform.localPosition = Vector3.Lerp(new Vector3(0, 0, -minZoom), new Vector3(0, 0, -maxZoom), zoomFactor);

        }

    }

    public void SetLevelOrigin(Vector3 pos)
    {
        originalPos = pos;
    }
}
