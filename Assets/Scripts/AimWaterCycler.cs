using UnityEngine;
using System.Collections;

public class AimWaterCycler : MonoBehaviour {

    private SpriteRenderer spriteRendereur;
    public Sprite[] sprites;
    private int i = 0;
    private bool incrementing = true;

    // Use this for initialization
    void Start () {
        spriteRendereur = this.gameObject.GetComponent<SpriteRenderer>();
        i = 0;
        StartCoroutine(Cycle());
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void Switch()
    {
        if (i == 2)
            incrementing = false;
        else if (i == 0)
            incrementing = true;
        if (incrementing)
            i++;
        else
            i--;
        spriteRendereur.sprite = sprites[i];
        
    }

    IEnumerator Cycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Switch();

        }
    }
}
