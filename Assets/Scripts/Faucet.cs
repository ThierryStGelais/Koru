using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Faucet : MonoBehaviour {


    [SerializeField]
    [Tooltip("Nombre de particules par secondes")]
    public float debit = 100.0f;
    [SerializeField]
    [Range(1.0f, 32.0f)]
    int sourceQuality = 1;

    [SerializeField]
    [Range(1.0f, 16.0f)]
    int overflowQuality = 1;

    [SerializeField]
    [Range(1, 8)]
    int chainQuantity = 1;

    [SerializeField]
    [Range(1, 16)]
    int chainLenght = 1;

    [SerializeField]
    [Range(1, 8)]
    int chainOffset = 1;


    static int _sourceQuality = 1;
    static int _overflowQuality = 1;
    public static int _chainQuantity = 1;
    public static int _chainLenght = 1;
    public static int _chainOffset = 1;


    GameObject water;
    static List<GameObject> waterPool;
    static int cpt;
    public int maxWater;
    public bool onOff = true;


    float timeLeft = 0.0f;
	// Use this for initialization
	void Start () {

        water = (GameObject)Resources.Load("Water");
        _overflowQuality = overflowQuality;
        _sourceQuality = sourceQuality;

        if (waterPool == null)
        {
            waterPool = new List<GameObject>();
            cpt = 0;
            for (int i = 0; i < maxWater; i++)
            {
                waterPool.Add((GameObject)Instantiate(water, new Vector3(-100 - (waterPool.Count / 100), 100 + (waterPool.Count % 100), -100), Quaternion.identity));
            }
            cpt = maxWater;
            Application.runInBackground = true;
        }    

    }

    void OnValidate()
    {
        _overflowQuality = overflowQuality;
        _sourceQuality = sourceQuality;
        _chainQuantity = chainQuantity;
        _chainLenght = chainLenght;
        _chainOffset = chainOffset;
    }

    // Update is called once per frame
    void Update () {
        if (onOff)
        {
            timeLeft += Time.deltaTime;
            if (timeLeft >= (1 / debit))
            {
                spawnWater(this.gameObject.transform.position, debit * timeLeft);
                timeLeft = 0;
            }
        }
	}


  

    public static void spawnWater (Vector3 _position, float volume, bool isOverflow = false)
    {
        float quality= _overflowQuality;
        if (!isOverflow)
        {
            quality = _sourceQuality;
        }
        Bassin ocean = GameObject.FindGameObjectWithTag("OceanRef").GetComponentInParent<Bassin>();
        volume /= quality;
        for (int i = 0; i < quality; i++)
        {
            if (waterPool.Count == 0)
            {
                GameObject water = (GameObject)Resources.Load("Water");
                waterPool.Add((GameObject)Instantiate(water, new Vector3(-100 - (waterPool.Count / 100), 100 + (waterPool.Count % 100), -100), Quaternion.identity));

            }
            GameObject waterObject = waterPool[0];
            waterPool.Remove(waterObject);

            waterObject.transform.position = _position+ i*new Vector3(0.02f,0,0.02f);
            
            if (ocean.getWaterLevelAtMyLocation(waterObject) > waterObject.transform.position.y)
            {
                waterObject.transform.position += new Vector3(0,( ocean.getWaterLevelAtMyLocation(waterObject)- waterObject.transform.position.y)+2.0f , 0);
            }
                waterObject.GetComponent<Rigidbody>().isKinematic = false;
            //waterObject.SetActive(true);

            waterObject.GetComponent<WaterBehaviour>().volume = volume;
            float rayon = Mathf.Pow((volume * 3) / (4 * Mathf.PI), (1 / 3.0f)) ;
            waterObject.transform.localScale = new Vector3(rayon/2, rayon/2, rayon/2);

        }

    }


    public static void releaseWater(GameObject waterObject)
    {

        //Debug.Log("release");
        waterObject.GetComponent<Rigidbody>().isKinematic = true;
        //waterObject.SetActive(false);
        waterObject.transform.position = new Vector3(-100 - (cpt/ 100), 100+(cpt % 100), -100);
        cpt++;
        //waterObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        waterPool.Add(waterObject);


    }


}
