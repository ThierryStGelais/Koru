using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

    public enum ObjectType {Fish,FishAi,Planche};
    public ObjectType objectToSpawn;

#if UNITY_EDITOR
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }
#endif

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Spawn()
    {
        GameObject objectOriginal;
        switch (objectToSpawn)
        {
            case ObjectType.Fish:
                objectOriginal = Resources.Load("Fish") as GameObject;
                break;
            case ObjectType.FishAi:
                objectOriginal = Resources.Load("Fish_AI") as GameObject;
                break;
            case ObjectType.Planche:
                objectOriginal = Resources.Load("Planche") as GameObject;
                break;
            default:
                objectOriginal = Resources.Load("Fish") as GameObject;
                break;
        }
        Instantiate(objectOriginal,this.transform.position,this.transform.rotation);
    }
}
