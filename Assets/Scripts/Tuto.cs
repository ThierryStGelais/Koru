using UnityEngine;
using System.Collections;

public class Tuto : MonoBehaviour {


#if UNITY_EDITOR
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawCube(transform.Find("ShowHelp").position, new Vector3(1, 1, 1));
    }
#endif



    SpriteRenderer image;
    Transform showHelp;
    Player p1, p2;
    [SerializeField]
    private float alpha = 1;
    public float distance = 5.0f, factor = 0.0025f;

    // Use this for initialization
    void Start() {
        showHelp = transform.Find("ShowHelp");
        image = gameObject.GetComponent<SpriteRenderer>();
        p1 = GameManager.Instance.getPlayersManager().players[0];
        p2 = GameManager.Instance.getPlayersManager().players[1];

    }

    // Update is called once per frame
    void Update()
    {
        if (p1 != null)
        {
            p1 = GameManager.Instance.getPlayersManager().players[0];
        }
        float distP1 = 999;
        if (p1.GetGameObject() != null)
        {
            distP1 = Vector3.Distance(showHelp.position, p1.GetGameObject().transform.position);
        }
        if (p2 != null)
        {
            p2 = GameManager.Instance.getPlayersManager().players[1];
        }
        float distP2 = 999;
        if (p2.GetGameObject() != null)
        {
            distP2 = Vector3.Distance(showHelp.position, p2.GetGameObject().transform.position);
        }

        distance = Mathf.Min(distP1, distP2);
        alpha = 1.0f + ((-1) * Mathf.Pow((distance * factor), 2));
        image.color = new Color(1, 1, 1, alpha);
        gameObject.transform.LookAt(Camera.main.transform.position);
        
    }
}
