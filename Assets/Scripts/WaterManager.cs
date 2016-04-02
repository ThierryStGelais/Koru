using UnityEngine;
using System.Collections;

public class WaterManager : MonoBehaviour {

    public float debit = 1000;
    public float density = 0.1f;
    public GameObject spawnPoint;
    public float spread=2;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
       /* timeCount += Time.deltaTime;
        if (timeCount >= density)
        {
            

            GameObject instance = (GameObject)Object.Instantiate(obj, spawnPoint.transform.position + new Vector3(Random.Range(-spread, spread), 0, 0), new Quaternion());
            float volume = timeCount * debit;


            instance.transform.GetChild(0).GetComponent<WaterAddToBassin>().volume = volume/3;
            instance.transform.GetChild(1).GetComponent<WaterAddToBassin>().volume = volume / 3;
            instance.transform.GetChild(2).GetComponent<WaterAddToBassin>().volume = volume / 3;

            float rayon =  Mathf.Pow((volume * 3)/(4 * Mathf.PI),(1/3.0f));
            // Debug.Log(volume +" / "+rayon);
            instance.transform.GetChild(0).transform.localScale = new Vector3(rayon, rayon, rayon)/3;
            instance.transform.GetChild(1).transform.localScale = new Vector3(rayon, rayon, rayon) / 3;
            instance.transform.GetChild(2).transform.localScale = new Vector3(rayon, rayon, rayon) / 3;

            timeCount = 0;
        }*/
    }
}
