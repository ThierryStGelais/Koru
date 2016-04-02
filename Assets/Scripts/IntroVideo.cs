using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class IntroVideo : MonoBehaviour {

    MovieTexture mt;

    void Awake()
    {
        RawImage rim = GetComponent<RawImage>();
        mt = (MovieTexture)rim.mainTexture;
    }

    // Use this for initialization
    void Start ()
    {
        mt.Play();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!mt.isPlaying || Input.anyKeyDown)
        {
            SceneManager.LoadScene("World1");
        }
    }
}
