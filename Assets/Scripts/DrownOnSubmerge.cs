using UnityEngine;
using System.Collections;

public class DrownOnSubmerge : MonoBehaviour {

    private Bassin ocean;
    public float submersionLevelTolerence = 0.5f;
	// Use this for initialization
	void Start () {
        ocean = GameObject.FindGameObjectWithTag("OceanRef").GetComponentInParent<Bassin>();
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
            Destroy(gameObject);
    }*/
    void FixedUpdate()
    {
        if (ocean.getWaterLevelAtMyLocation(gameObject)>transform.position.y+ submersionLevelTolerence)
        {
            if (this.gameObject.tag == "Player" && this.gameObject.transform.childCount == 6)
            {
                GameObject pickedUpReference = this.gameObject.transform.GetChild(this.gameObject.transform.childCount - 1).gameObject;
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                pickedUpReference.gameObject.SetActive(true);
                pickedUpReference.transform.parent = null;
                pickedUpReference.transform.position = new Vector3(pickedUpReference.transform.position.x, this.transform.position.y, pickedUpReference.transform.position.z);

            }
            if (GameManager.Instance.getPlayersManager().players[0].GetGameObject() == this.gameObject)
                GameManager.Instance.getPlayersManager().players[0].Drown(submersionLevelTolerence);
            else if (GameManager.Instance.getPlayersManager().players[1].GetGameObject() == this.gameObject)
                GameManager.Instance.getPlayersManager().players[1].Drown(submersionLevelTolerence);
        }
    }

}
