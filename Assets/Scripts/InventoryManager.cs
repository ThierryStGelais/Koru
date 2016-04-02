using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InventoryManager : MonoBehaviour {


    public float maxPickUpRange = 10.0f;
    private int noPlayer;
    public float displacementValue=1;
    public float maxAngle = 90;
    public float maxFishElevationDiff = 3;

    public int NoPlayer
    {
        set
        {
            noPlayer = value;
        }
    }


    /*[SerializeField]
    [Tooltip("[ENTIER] Nombre de poissons dans l'inventaire")]
    int nbrFish;

    [SerializeField]
    [Tooltip("[BOOLEEN] Si le joueur tiens une planche")]
    bool isHoldingPlank;*/

    void FixedUpdate()
    {
        if (GameManager.Instance != null && GameManager.Instance.getPlayersManager().players[noPlayer-1].GetGameObject().transform.childCount <= 5)
        {
            FishHighlight();
        }
    }


    /// <summary>
    /// Fonction qui choisi l'objet le plus près satisfaisant aux conditions, l'ajoute à l'inventaire du joueur puis le supprime de la scène
    /// </summary>
    /// <param name="_priorite">Défini la priorité de pickup, soit Planche, soit Poisson</param>
    /// <param name="_force">Défini si la fonction force une réponse même si elle n'est pas prioritaire</param>
    public GameObject Pickup(string _priorite, bool _force = false)
    {
        GameObject result = null;


        bool priorityFound = false;

        float distanceMin = (float)double.PositiveInfinity;


        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, (_priorite=="Pickable"?(maxPickUpRange/2.5f):maxPickUpRange)); //ADD


        foreach (Collider element in hitColliders)
        {
            if (element.tag.Contains(_priorite))
            {

                RaycastHit hit = Raycast(element, _priorite);

                if (hit.collider)
                {
                    if (hit.collider.tag == "Fish" || hit.collider.tag == "Pickable") //Verifie si le premier object toucher par le raycast est un object ramassable
                    {

                        Vector3 PlayerWithDisplacement = gameObject.transform.position;
                        Vector3 FishWithDisplacement = element.transform.position;
                       /*if(hit.collider.tag == "Pickable")
                            Debug.DrawLine(gameObject.transform.position + new Vector3(0, displacementValue, 0), element.transform.position +new Vector3(0, 1, 0), Color.green, 100);
*/
                        // Debug.DrawLine(this.gameObject.transform.position, (element.transform.position + new Vector3(0, displacementValue, 0)), Color.green, 2.5f);
                        switch (element.tag)
                        {
                            case "Fish": //Verification si le poisson est ramassable


                                PlayerWithDisplacement = gameObject.transform.position + new Vector3(0, displacementValue, 0);
                                FishWithDisplacement = element.transform.position + new Vector3(0, displacementValue, 0);

                                if (!Physics.Raycast(PlayerWithDisplacement, FishWithDisplacement - PlayerWithDisplacement, Vector3.Distance(PlayerWithDisplacement, FishWithDisplacement), 1 << 0))
                                {
                                    if ((Vector3.Distance(element.transform.position, this.gameObject.transform.position + new Vector3(0, 1, 0)) < distanceMin) && !element.GetComponent<Fish>().isTargeted)
                                    {
                                        Vector3 direction = new Vector3(element.transform.position.x, 0, element.transform.position.z) - new Vector3(this.transform.position.x, 0, this.transform.position.z);
                                        float angle = Vector3.Angle(this.transform.forward, direction);
                                        if (angle < maxAngle * 0.5f && (Mathf.Abs(element.transform.position.y - transform.position.y) <= maxFishElevationDiff || element.transform.parent.parent.name == "Ocean"))
                                        {
                                            result = element.gameObject;
                                            distanceMin = Vector3.Distance(element.transform.position, this.gameObject.transform.position);
                                            priorityFound = true;
                                        }
                                    }
                                }
                                break;

                            case "Pickable": //Verification si le pickable est ramassable
                                PlayerWithDisplacement = gameObject.transform.position + new Vector3(0, displacementValue, 0);
                                FishWithDisplacement = element.transform.position + new Vector3(0, 1, 0);
                                if (!Physics.Raycast(PlayerWithDisplacement, FishWithDisplacement - PlayerWithDisplacement, Vector3.Distance(PlayerWithDisplacement, FishWithDisplacement), 1 << 0))
                                {
                                    if (Vector3.Distance(element.transform.position, this.gameObject.transform.position) < distanceMin)
                                    {
                                        Vector3 direction = new Vector3(element.transform.position.x, 0, element.transform.position.z) - new Vector3(this.transform.position.x, 0, this.transform.position.z);
                                        float angle = Vector3.Angle(this.transform.forward, direction);
                                        if (angle < maxAngle * 0.5f && (Mathf.Abs(element.transform.position.y - transform.position.y) <= 3))
                                        {
                                            result = element.gameObject;
                                            distanceMin = Vector3.Distance(element.transform.position, this.gameObject.transform.position);
                                            priorityFound = true;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                }
                else
                {
                    //Debug.DrawLine(this.gameObject.transform.position, (element.transform.position + new Vector3(0, displacementValue, 0)), Color.red, 2.5f);
                }
            }
            else if ((!priorityFound && _force) && (Vector3.Distance(element.transform.position, this.gameObject.transform.position) < distanceMin))
            {

                result = element.gameObject;
                distanceMin = Vector3.Distance(element.transform.position, this.gameObject.transform.position);
            }
        }

        /*
        if (result != null && result.tag.Equals("Fish") && !result.GetComponent<Fish>().isTargeted)
            result.GetComponent<Fish>().isTargeted = true;
        */
        return result;
    }

    /// <summary>
    /// Udpate la table de targeting du fish
    /// </summary>
    private void FishHighlight()
    {

        GameObject element = Pickup("Fish");

        foreach (GameObject fish in GameObject.FindGameObjectsWithTag("Fish"))
        {

            fish.GetComponent<Fish>().MakeHighlight(noPlayer, false);

        }
        if (element != null && element.tag == "Fish")
        {
            element.GetComponent<Fish>().MakeHighlight(noPlayer, true);
           // Debug.DrawLine(this.gameObject.transform.position + new Vector3(0, displacementValue, 0), element.transform.position + new Vector3(0, displacementValue, 0), Color.green);
        }
    }

    /// <summary>
    /// Retourne un raycast entre le joueur et le fish
    /// </summary>
    private RaycastHit Raycast(Collider element, String type = "Fish")
    {
        RaycastHit hitTemp;

		Vector3 PlayerWithDisplacement = gameObject.transform.position;
		Vector3 FishWithDisplacement = element.transform.position;

		if (type == "Fish") {
			PlayerWithDisplacement = gameObject.transform.position + new Vector3 (0, displacementValue, 0);
			FishWithDisplacement = element.transform.position + new Vector3 (0, 1, 0);

			Physics.Raycast (PlayerWithDisplacement                                         //Origin (Player+displacement)
				, FishWithDisplacement - PlayerWithDisplacement                  //Direction (Player+displacement jusqua Fish+Displacement)
				, out hitTemp                                                        //Hit info
				, Vector3.Distance (PlayerWithDisplacement, FishWithDisplacement) //Distance (Player+displacement jusqua Fish+Displacement)                                //LayerMask
			    ,1<<14
            );
		} 
		else
		{
			PlayerWithDisplacement = gameObject.transform.position + new Vector3(0, displacementValue, 0);
            FishWithDisplacement = element.transform.position;

			Physics.Raycast(PlayerWithDisplacement                                         //Origin (Player+displacement)
				, FishWithDisplacement - PlayerWithDisplacement                  //Direction (Player+displacement jusqua Fish+Displacement)
				, out hitTemp                                                        //Hit info
				, Vector3.Distance(PlayerWithDisplacement, FishWithDisplacement) //Distance (Player+displacement jusqua Fish+Displacement)
			    , 1<<16
            );
		}


        return hitTemp;
    }
}