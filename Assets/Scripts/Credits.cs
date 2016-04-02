using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Credits : MonoBehaviour {

    [SerializeField]
    float risingSpeed = 1.0f;
    RectTransform rekt;

	// Use this for initialization
	void Start () {

        rekt = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update () {
        rekt.Translate(Vector3.up * risingSpeed * Time.deltaTime);
        if (rekt.position.y > 450)
            Back();
	}


    public void Back()
    {
        SceneManager.LoadScene("Menu scene");
    }
}

