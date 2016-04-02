using UnityEngine;
using System.Collections.Generic;

public class Bassin : MonoBehaviour {


    public float bassinWidth = 10;
    public float bassinLenght = 10;

    public float cornersScale = 1;
    public float wallsScale = 1;
    public float wallsOffset = 0;

    [Range(0.01f, 100.0f)]
    public float volumeModifier = 1;

    [Range(0.001f, 1.0f)]
    public float rootModifier = 0.1f;

    public List<Bassin> childs = new List<Bassin>();

    private float colliderHeight = 2.0f;
    public float Edge = 10;
    private float baseEdge = 10;

    public float Deept = 10;
    public float initialLevel;
    public float WaterLevel = 1;
    public bool isRootBassin = false;
    public bool displayWalls = true;

    private float volume;
    public float overFlow=0;

    private GameObject Corners;
    private GameObject Walls;
    private GameObject Bottom;
    private GameObject Water;

    private List<int> tri = new List<int>();
    private List<Vector3> vertices = new List<Vector3>();
    private Mesh mesh;


    public GameObject spawnPoint;
    private float timeCount = 0;
    public bool isLocked = false;

    public float overFlowRate = 0.9f;
    private Vector3 positionBassin;
    // Use this for initialization
    void Start()
    {

        baseEdge = Edge;
        mesh = new Mesh();
        if (!isRootBassin)
        {
            SaveCurentWaterLevel();
        }
        Corners = this.transform.GetChild(0).gameObject;
        Walls = this.transform.GetChild(1).gameObject;
        Bottom = this.transform.GetChild(2).gameObject;
        Water = this.transform.GetChild(3).gameObject;

        positionBassin = this.transform.position;
        float height = (Edge - positionBassin.y);
        if (!isLocked)
        {
            if (displayWalls)
            {
                Corners.transform.GetChild(0).position = new Vector3((-bassinWidth) / 2, height / 2, (-bassinLenght) / 2) + positionBassin;
                Corners.transform.GetChild(1).position = new Vector3((bassinWidth) / 2, height / 2, (-bassinLenght) / 2) + positionBassin;
                Corners.transform.GetChild(2).position = new Vector3((-bassinWidth) / 2, height / 2, (bassinLenght) / 2) + positionBassin;
                Corners.transform.GetChild(3).position = new Vector3((bassinWidth) / 2, height / 2, (bassinLenght) / 2) + positionBassin;


                Walls.transform.GetChild(0).position = new Vector3(0, height / 2, ((-bassinLenght) / 2) - wallsOffset) + positionBassin;
                Walls.transform.GetChild(1).position = new Vector3(0, height / 2, ((bassinLenght) / 2) + wallsOffset) + positionBassin;
                Walls.transform.GetChild(2).position = new Vector3(((-bassinWidth) / 2) - wallsOffset, height / 2, 0) + positionBassin;
                Walls.transform.GetChild(3).position = new Vector3(((bassinWidth) / 2) + wallsOffset, height / 2, 0) + positionBassin;


                Vector3 scaleModifierCorner = new Vector3(cornersScale, height, cornersScale);
                for (int i = 0; i < Corners.transform.childCount; i++)
                {
                    Corners.transform.GetChild(i).localScale = scaleModifierCorner;
                }

                Walls.transform.GetChild(0).localScale = new Vector3(bassinWidth, height, wallsScale);
                Walls.transform.GetChild(1).localScale = new Vector3(bassinWidth, height, wallsScale);
                Walls.transform.GetChild(2).localScale = new Vector3(wallsScale, height, bassinLenght);
                Walls.transform.GetChild(3).localScale = new Vector3(wallsScale, height, bassinLenght);

            }
            else
            {
                Walls.SetActive(false);
            }
            Bottom.transform.position = new Vector3(positionBassin.x, Edge - Deept, positionBassin.z);
            Bottom.transform.localScale = new Vector3(bassinWidth, 1, bassinLenght);

            Water.transform.position = new Vector3(positionBassin.x, (Edge - Deept) + WaterLevel, positionBassin.z);
            if (!isRootBassin)
            {
                this.GetComponent<BoxCollider>().size = new Vector3(bassinWidth, 1, bassinLenght);
                this.GetComponent<BoxCollider>().center = new Vector3(0, Edge - 0.7f, 0);
            }
            else
            {
                this.GetComponent<BoxCollider>().size = new Vector3(bassinWidth, 5, bassinLenght);
                this.GetComponent<BoxCollider>().center = new Vector3(0, (Edge - Deept + WaterLevel - 1.5f) - positionBassin.y, 0);
            }
        }
        // Water.transform.localScale = new Vector3(bassinWidth / 10, 1, bassinLenght / 10);


        

        childs = new List<Bassin>();
        foreach (GameObject bassin in GameObject.FindGameObjectsWithTag("Bassin"))
        {
            if (bassin != gameObject && IsInsideMe(bassin))
            {
                Bassin bassinComponen = bassin.GetComponent<Bassin>();
                childs.Add(bassinComponen);
            }
        }

        volume = bassinWidth * bassinLenght * volumeModifier;
        if (isRootBassin)
        {
            transform.FindChild("Bottom").tag = "OceanRef";
            volume /= rootModifier * 100000;
        }






        tri = new List<int>();
        vertices = new List<Vector3>();

        vertices.Add(new Vector3(-bassinWidth / 2, 0, -bassinLenght / 2));
        vertices.Add(new Vector3(bassinWidth / 2, 0, -bassinLenght / 2));
        vertices.Add(new Vector3(-bassinWidth / 2, 0, bassinLenght / 2));
        vertices.Add(new Vector3(bassinWidth / 2, 0, bassinLenght / 2));
        splitPlane(0, 1, 2, 3, 0);

        vertices.Add(new Vector3(-bassinWidth / 2, -colliderHeight, -bassinLenght / 2));
        vertices.Add(new Vector3(bassinWidth / 2, -colliderHeight, -bassinLenght / 2));
        vertices.Add(new Vector3(-bassinWidth / 2, -colliderHeight, bassinLenght / 2));
        vertices.Add(new Vector3(bassinWidth / 2, -colliderHeight, bassinLenght / 2));
        int verticesCount = vertices.Count;
        splitPlane(verticesCount - 4, verticesCount - 3, verticesCount - 2, verticesCount - 1, -colliderHeight);

        updatePlane();



    }


    private void splitPlane(int pt1, int pt2, int pt3, int pt4, float elevation)
    {
        int nbPts = 0;
        int typeTrigngleDraw = 0;
        Vector3 ptPos = new Vector3(0, 0, 0);
        Vector3 ptUpper = vertices[pt1];
        Vector3 ptLower = vertices[pt4];

        foreach (Bassin subBassin in childs)
        {
            if (subBassin.Edge > (Edge - Deept + WaterLevel) || !(subBassin.WaterLevel >= subBassin.Deept))
            {
                int nbOutX = 0;
                int outXType = 0;
                int nbOutZ = 0;
                int outZType = 0;
                Vector3 outXVal = new Vector3(0, 0, 0);
                Vector3 outZVal = new Vector3(0, 0, 0);

                for (int i = 1; i < 5 && !(nbPts > 1); i++)
                {
                    Vector3 pt = new Vector3(0, 0, 0);
                    switch (i)
                    {
                        case 1:
                            pt = new Vector3(subBassin.transform.position.x - (subBassin.bassinWidth / 2), elevation, subBassin.transform.position.z - (subBassin.bassinLenght / 2));
                            break;
                        case 2:
                            pt = new Vector3(subBassin.transform.position.x + (subBassin.bassinWidth / 2), elevation, subBassin.transform.position.z - (subBassin.bassinLenght / 2));
                            break;
                        case 3:
                            pt = new Vector3(subBassin.transform.position.x - (subBassin.bassinWidth / 2), elevation, subBassin.transform.position.z + (subBassin.bassinLenght / 2));
                            break;
                        case 4:
                            pt = new Vector3(subBassin.transform.position.x + (subBassin.bassinWidth / 2), elevation, subBassin.transform.position.z + (subBassin.bassinLenght / 2));
                            break;
                    }

                    if (ptUpper.x < pt.x && ptLower.x > pt.x && ptUpper.z < pt.z && ptLower.z > pt.z)
                    {
                        nbPts++;
                        typeTrigngleDraw = i;
                        ptPos = pt;
                    }
                    else if (ptUpper.z < pt.z && ptLower.z > pt.z)
                    {
                        if (nbOutX == 0 || outXVal.x < ptUpper.x && pt.x > ptLower.x || pt.x < ptUpper.x && outXVal.x > ptLower.x)
                        {
                            nbOutX++;
                            outXType = i;
                            outXVal = pt;
                        }
                    }
                    else if (ptUpper.x < pt.x && ptLower.x > pt.x)
                    {
                        if (nbOutZ == 0 || outZVal.z < ptUpper.z && pt.z > ptLower.z || pt.z < ptUpper.z && outZVal.z > ptLower.z)
                        {
                            nbOutZ++;
                            outZType = i;
                            outZVal = pt;
                        }
                    }
                }

                if (nbOutX > 2)
                {
                    vertices.Add(new Vector3(ptUpper.x, elevation, outXVal.z));
                    vertices.Add(new Vector3(ptLower.x, elevation, outXVal.z));
                    splitPlane(pt1, pt2, vertices.Count - 2, vertices.Count - 1, elevation);
                    splitPlane(vertices.Count - 2, vertices.Count - 1, pt3, pt4, elevation);
                }
                else if (nbOutZ > 2)
                {
                    vertices.Add(new Vector3(outZVal.x, elevation, ptUpper.z));
                    vertices.Add(new Vector3(outZVal.x, elevation, ptLower.z));
                    splitPlane(pt1, vertices.Count - 1, pt3, vertices.Count - 2, elevation);
                    splitPlane(vertices.Count - 1, pt2, vertices.Count - 2, pt4, elevation);
                }
                else if (nbOutX == 2)
                {
                    if (outXType <= 2)
                    {
                        Vector3 tempVect = vertices[pt3];
                        tempVect.z = outXVal.z;
                        vertices[pt3] = tempVect;
                        tempVect = vertices[pt4];
                        tempVect.z = outXVal.z;
                        vertices[pt4] = tempVect;
                    }
                    else
                    {
                        Vector3 tempVect = vertices[pt1];
                        tempVect.z = outXVal.z;
                        vertices[pt1] = tempVect;
                        tempVect = vertices[pt2];
                        tempVect.z = outXVal.z;
                        vertices[pt2] = tempVect;
                    }
                    splitPlane(pt1, pt2, pt3, pt4, elevation);
                }
                else if (nbOutZ == 2)
                {
                    if (outZType == 1 || outZType == 3)
                    {
                        Vector3 tempVect = vertices[pt2];
                        tempVect.x = outZVal.x;
                        vertices[pt2] = tempVect;
                        tempVect = vertices[pt4];
                        tempVect.x = outZVal.x;
                        vertices[pt4] = tempVect;
                    }
                    else
                    {
                        Vector3 tempVect = vertices[pt1];
                        tempVect.x = outZVal.x;
                        vertices[pt1] = tempVect;
                        tempVect = vertices[pt3];
                        tempVect.x = outZVal.x;
                        vertices[pt3] = tempVect;
                    }
                    splitPlane(pt1, pt2, pt3, pt4, elevation);
                }
            }
        }

        if (nbPts > 1)
        {
            vertices.Add(new Vector3(ptUpper.x + (ptLower.x - ptUpper.x) / 2, elevation, ptUpper.z));                                    //  -5
            vertices.Add(new Vector3(ptUpper.x, elevation, ptLower.z - (ptLower.z - ptUpper.z) / 2));                                    //  -4
            vertices.Add(new Vector3(ptUpper.x + (ptLower.x - ptUpper.x) / 2, elevation, ptLower.z - (ptLower.z - ptUpper.z) / 2));      //  -3
            vertices.Add(new Vector3(ptLower.x, elevation, ptLower.z - (ptLower.z - ptUpper.z) / 2));                                    //  -2
            vertices.Add(new Vector3(ptUpper.x + (ptLower.x - ptUpper.x) / 2, elevation, ptLower.z));                                    //  -1
            int countVert = vertices.Count;
            splitPlane(pt1, countVert - 5, countVert - 4, countVert - 3, elevation);    //sub square uper left
            splitPlane(countVert - 5, pt2, countVert - 3, countVert - 2, elevation);   //sub square uper right
            splitPlane(countVert - 4, countVert - 3, pt3, countVert - 1, elevation);    //sub square lower left
            splitPlane(countVert - 3, countVert - 2, countVert - 1, pt4, elevation);     //sub square lower right
        }
        else
        {
            if (typeTrigngleDraw != 0)
            {
                vertices.Add(ptPos);
            }
            else
            {
                vertices.Add(new Vector3(ptUpper.x + (ptLower.x - ptUpper.x) / 2, elevation, ptLower.z - (ptLower.z - ptUpper.z) / 2));
            }

            switch (typeTrigngleDraw)
            {
                case 0:
                    drawPlane(vertices.Count - 1, pt1, pt2, pt3, pt4, -1);
                    break;
                case 1:
                    vertices.Add(new Vector3(ptPos.x, elevation, ptLower.z));
                    vertices.Add(new Vector3(ptLower.x, elevation, ptPos.z));
                    drawPlane(vertices.Count - 3, pt1, pt2, pt3, vertices.Count - 2, vertices.Count - 1);
                    break;
                case 2:
                    vertices.Add(new Vector3(ptUpper.x, elevation, ptPos.z));
                    vertices.Add(new Vector3(ptPos.x, elevation, ptLower.z));
                    drawPlane(vertices.Count - 3, pt2, pt4, pt1, vertices.Count - 2, vertices.Count - 1);
                    break;
                case 3:
                    vertices.Add(new Vector3(ptLower.x, elevation, ptPos.z));
                    vertices.Add(new Vector3(ptPos.x, elevation, ptUpper.z));
                    drawPlane(vertices.Count - 3, pt3, pt1, pt4, vertices.Count - 2, vertices.Count - 1);
                    break;
                case 4:
                    vertices.Add(new Vector3(ptPos.x, elevation, ptUpper.z));
                    vertices.Add(new Vector3(ptUpper.x, elevation, ptPos.z));
                    drawPlane(vertices.Count - 3, pt4, pt3, pt2, vertices.Count - 2, vertices.Count - 1);
                    break;
            }
        }
    }

    private void updatePlane()
    {


        MeshFilter mf = Water.GetComponent<MeshFilter>();
        MeshCollider mc = Water.GetComponent<MeshCollider>();
        //MeshCollider mcBassin = GetComponent<MeshCollider>();
        mesh.MarkDynamic();
        //mesh.Clear();


        //mcBassin.sharedMesh = mesh;

        Vector3[] bufferVertices = new Vector3[vertices.Count];
        int[] bufferTri = new int[tri.Count];

        int cpt = 0;
        foreach (Vector3 pt in vertices)
        {
            bufferVertices[cpt] = pt;
            cpt++;
        }

        cpt = 0;
        foreach (int thing in tri)
        {
            bufferTri[cpt] = thing;
            cpt++;
        }
        mesh.vertices = bufferVertices;
        mesh.triangles = bufferTri;
        mesh.RecalculateNormals();
        
        mf.mesh = mesh;
        mc.sharedMesh = mesh;
    }

    private void drawPlane(int ptCross, int pt1, int pt2, int pt3, int pt4, int pt5)
    {
        if (pt5 == -1)
        {
            tri.Add(pt2);
            tri.Add(pt1);
            tri.Add(ptCross);

            tri.Add(pt1);
            tri.Add(pt3);
            tri.Add(ptCross);

            tri.Add(pt3);
            tri.Add(pt4);
            tri.Add(ptCross);

            tri.Add(pt4);
            tri.Add(pt2);
            tri.Add(ptCross);
        }
        else
        {
            tri.Add(pt1);
            tri.Add(pt3);
            tri.Add(ptCross);

            tri.Add(pt3);
            tri.Add(pt4);
            tri.Add(ptCross);

            tri.Add(pt5);
            tri.Add(pt2);
            tri.Add(ptCross);

            tri.Add(pt2);
            tri.Add(pt1);
            tri.Add(ptCross);
        }
    }


    private bool IsInsideMe(GameObject bassin, bool isBassin = true)
    {
        bool val = false;
        if (isBassin )
        {
            Bassin bassinScript = bassin.GetComponent<Bassin>();

            if ( bassinScript != null && positionBassin.x + (bassinWidth / 2) >= bassin.transform.position.x + (bassinScript.bassinWidth / 2) && positionBassin.x - (bassinWidth / 2) <= bassin.transform.position.x - (bassinScript.bassinWidth / 2))
            {
                if (positionBassin.z + (bassinLenght / 2) >= bassin.transform.position.z + (bassinScript.bassinLenght / 2) && positionBassin.z - (bassinLenght / 2) <= bassin.transform.position.z - (bassinScript.bassinLenght / 2))
                {
                    val = true;
                }
            }
        }
        else
        {
            if (positionBassin.x + (bassinWidth / 2) > bassin.transform.position.x && positionBassin.x - (bassinWidth / 2) < bassin.transform.position.x)
            {
                if (positionBassin.z + (bassinLenght / 2) > bassin.transform.position.z && positionBassin.z - (bassinLenght / 2) < bassin.transform.position.z)
                {
                    val = true;
                }
            }

        }
        return val;
    }


    public float getWaterLevelAtMyLocation(GameObject point)
    {
        float val = 0;
        bool found = false;
        if (childs.Count > 0)
        {
            foreach (Bassin child in childs)
            {
                if (!found && child.IsInsideMe(point, false))
                {
                    if (child.Edge > (Edge - Deept + WaterLevel) || !(child.WaterLevel >= child.Deept))
                    {
                        val = child.getWaterLevelAtMyLocation(point);
                        found = true;
                    }
                }
            }
        }

        if (!found)
        {
            val = Water.transform.position.y;
        }
        return val;
    }


    void OnValidate ()
    {
        mesh = new Mesh();

        Corners = this.transform.GetChild(0).gameObject;
        Walls = this.transform.GetChild(1).gameObject;
        Bottom = this.transform.GetChild(2).gameObject;
        Water = this.transform.GetChild(3).gameObject;

        positionBassin = this.transform.position;
        float height = (Edge - positionBassin.y);

        if (!isLocked)
        {

            if (displayWalls)
            {
                Corners.transform.GetChild(0).position = new Vector3((-bassinWidth) / 2, height / 2, (-bassinLenght) / 2) + positionBassin;
                Corners.transform.GetChild(1).position = new Vector3((bassinWidth) / 2, height / 2, (-bassinLenght) / 2) + positionBassin;
                Corners.transform.GetChild(2).position = new Vector3((-bassinWidth) / 2, height / 2, (bassinLenght) / 2) + positionBassin;
                Corners.transform.GetChild(3).position = new Vector3((bassinWidth) / 2, height / 2, (bassinLenght) / 2) + positionBassin;


                Walls.transform.GetChild(0).position = new Vector3(0, height / 2, ((-bassinLenght) / 2) - wallsOffset) + positionBassin;
                Walls.transform.GetChild(1).position = new Vector3(0, height / 2, ((bassinLenght) / 2) + wallsOffset) + positionBassin;
                Walls.transform.GetChild(2).position = new Vector3(((-bassinWidth) / 2) - wallsOffset, height / 2, 0) + positionBassin;
                Walls.transform.GetChild(3).position = new Vector3(((bassinWidth) / 2) + wallsOffset, height / 2, 0) + positionBassin;


                Vector3 scaleModifierCorner = new Vector3(cornersScale, height, cornersScale);
                for (int i = 0; i < Corners.transform.childCount; i++)
                {
                    Corners.transform.GetChild(i).localScale = scaleModifierCorner;
                }

                Walls.transform.GetChild(0).localScale = new Vector3(bassinWidth, height, wallsScale);
                Walls.transform.GetChild(1).localScale = new Vector3(bassinWidth, height, wallsScale);
                Walls.transform.GetChild(2).localScale = new Vector3(wallsScale, height, bassinLenght);
                Walls.transform.GetChild(3).localScale = new Vector3(wallsScale, height, bassinLenght);
            }
            else
            {
                Walls.SetActive(false);
            }

            Bottom.transform.position = new Vector3(positionBassin.x, Edge - Deept, positionBassin.z);
            Bottom.transform.localScale = new Vector3(bassinWidth, 1, bassinLenght);

            Water.transform.position = new Vector3(positionBassin.x, (Edge - Deept) + WaterLevel, positionBassin.z);

            if (!isRootBassin)
            {
                this.GetComponent<BoxCollider>().size = new Vector3(bassinWidth, 1, bassinLenght);
                this.GetComponent<BoxCollider>().center = new Vector3(0, Edge - 0.7f, 0);

            }
            else
            {
                this.GetComponent<BoxCollider>().size = new Vector3(bassinWidth, 5, bassinLenght);
                this.GetComponent<BoxCollider>().center = new Vector3(0, Edge - Deept + WaterLevel - 2.5f, 0);

            }
            volume = bassinWidth * bassinLenght * volumeModifier;
        }// Water.transform.localScale = new Vector3(bassinWidth/10, 1, bassinLenght/10);

        
        childs = new List<Bassin>();
        foreach (GameObject bassin in GameObject.FindGameObjectsWithTag("Bassin"))
        {
            if (bassin != gameObject && IsInsideMe(bassin))
            {
                Bassin bassinComponen = bassin.GetComponent<Bassin>();
                childs.Add(bassinComponen);
            }
        }


        
        if (isRootBassin)
        {
            transform.FindChild("Bottom").tag = "OceanRef";
            volume /=  rootModifier * 100000;
        }


        tri = new List<int>();
        vertices = new List<Vector3>();

        vertices.Add(new Vector3(-bassinWidth / 2, 0, -bassinLenght / 2));
        vertices.Add(new Vector3(bassinWidth / 2, 0, -bassinLenght / 2));
        vertices.Add(new Vector3(-bassinWidth / 2, 0, bassinLenght / 2));
        vertices.Add(new Vector3(bassinWidth / 2, 0, bassinLenght / 2));
        splitPlane(0, 1, 2, 3, 0);

        vertices.Add(new Vector3(-bassinWidth / 2, -colliderHeight, -bassinLenght / 2));
        vertices.Add(new Vector3(bassinWidth / 2, -colliderHeight, -bassinLenght / 2));
        vertices.Add(new Vector3(-bassinWidth / 2, -colliderHeight, bassinLenght / 2));
        vertices.Add(new Vector3(bassinWidth / 2, -colliderHeight, bassinLenght / 2));
        int verticesCount = vertices.Count;
        splitPlane(verticesCount - 4, verticesCount - 3, verticesCount - 2, verticesCount - 1, -colliderHeight);

        updatePlane();


    }

    public void RaiseLevel(float debit)
    {


        if (isRootBassin && WaterLevel>=Deept)
        {
            debit = 0;
        }
        if (WaterLevel < Deept)
        {
            WaterLevel += (debit) / volume;
            Water.transform.position = Water.transform.position + new Vector3(0, (debit) / volume, 0);
        }
        else
        {
            WaterLevel = Deept;
            overFlow +=debit;
        }


        if (isRootBassin)
        {
            this.GetComponent<BoxCollider>().size = new Vector3(bassinWidth, 5, bassinLenght);
            this.GetComponent<BoxCollider>().center = new Vector3(0, Edge - Deept + WaterLevel - 2.5f, 0);
        }
    }


    private void InnerFlow()
    {
        foreach (Bassin child in childs)
        {
            if (child.WaterLevel<child.Deept && child.Edge <= Edge - Deept + WaterLevel && child.Edge - child.Deept +child.WaterLevel < Edge - Deept + WaterLevel )
            {
                float transfer = ((Edge - Deept + WaterLevel)-child.Edge)*volume;
                //Debug.Log(transfer);


                child.RaiseLevel(transfer);
                if (isRootBassin)
                {
                    transfer /= 4;
                }

                WaterLevel -= (transfer / volume) *4;
                Water.transform.position = Water.transform.position - new Vector3(0, (transfer / volume)*4, 0);
            }

        }

    }

    private void OverFlow()
    {
        float transfer =  (overFlow*overFlowRate) * Time.deltaTime;
        Vector3 positionEdge = transform.position;
        positionEdge.y = Edge+0.5f;

        Faucet.spawnWater(positionEdge + new Vector3(Random.Range(-bassinWidth / 2, bassinWidth / 2), 0, (bassinLenght / 2) + 1.9f), transfer/12);
        Faucet.spawnWater(positionEdge + new Vector3((bassinWidth / 2) + 1.9f, 0, Random.Range(-bassinLenght / 2, bassinLenght / 2)), transfer / 12);
        Faucet.spawnWater(positionEdge + new Vector3(Random.Range(-bassinWidth / 2, bassinWidth / 2), 0, (-bassinLenght / 2) - 1.9f), transfer / 12);
        Faucet.spawnWater(positionEdge + new Vector3((-bassinWidth / 2) - 1.9f, 0, Random.Range(-bassinLenght / 2, bassinLenght / 2)), transfer / 12);

        //instance.transform.localScale = new Vector3(overflow, overflow, overflow) * 2;
        WaterLevel -= transfer / volume;
        Water.transform.position = Water.transform.position - new Vector3(0, transfer / volume, 0);
       /* foreach (Bassin child in childs)
        {
            child.outerWaterOffset = Mathf.Max(((Edge - Deept + WaterLevel) - (child.WaterLevel - child.Deept + child.Edge)),0);
        }*/
    }


    private void OuterFlow()
    {
        if (overFlow > 1)
        {
            float transfer = (overFlow * overFlowRate) * Time.deltaTime;
            overFlow -= transfer;
            Faucet.spawnWater(spawnPoint.transform.position, transfer, true);
        }
    }

  


    public void SaveCurentWaterLevel(float raisedLevel = 0)
    {
        if (gameObject.name == "Ocean" && WaterLevel + raisedLevel > initialLevel)
        {
            initialLevel = WaterLevel + raisedLevel;
        }
    }


    public void ResetToSavedWaterLevel()
    {
        overFlow = 0;
        childs = new List<Bassin>();

        foreach (GameObject bassin in GameObject.FindGameObjectsWithTag("Bassin"))
        {
            if (bassin != gameObject && IsInsideMe(bassin))
            {
                Bassin bassinComponen = bassin.GetComponent<Bassin>();
                childs.Add(bassinComponen);
            }
        }

        WaterLevel = initialLevel;
        Water.transform.position = new Vector3(positionBassin.x, (Edge - Deept) + WaterLevel, positionBassin.z);

        if (isRootBassin)
        {
            foreach (Bassin child in childs)
            {
                child.ResetToSavedWaterLevel();
            }
        }
    }

    public void updateNewLevelBassins()
    {
        if (!isRootBassin)
        {
            this.transform.position = new Vector3(this.transform.position.x,  (this.transform.position.y - this.transform.parent.transform.position.y)+ this.transform.parent.transform.position.y, this.transform.position.z);
            Edge = (this.transform.parent.transform.position.y + (this.transform.position.y - this.transform.parent.transform.position.y)) + baseEdge;
        }
        else
        {
            SaveCurentWaterLevel();
        }
        foreach (GameObject bassin in GameObject.FindGameObjectsWithTag("Bassin"))
        {
            if (bassin != gameObject && IsInsideMe(bassin))
            {
                Bassin bassinComponen = bassin.GetComponent<Bassin>();
                childs.Add(bassinComponen);
                bassinComponen.updateNewLevelBassins();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        timeCount += Time.deltaTime;
        if (timeCount>= 0.2f)
        {



            timeCount = 0;
            tri = new List<int>();
            vertices = new List<Vector3>();

            vertices.Add(new Vector3(-bassinWidth / 2, 0, -bassinLenght / 2));
            vertices.Add(new Vector3(bassinWidth / 2, 0, -bassinLenght / 2));
            vertices.Add(new Vector3(-bassinWidth / 2, 0, bassinLenght / 2));
            vertices.Add(new Vector3(bassinWidth / 2, 0, bassinLenght / 2));
            splitPlane(0, 1, 2, 3, 0);

            vertices.Add(new Vector3(-bassinWidth / 2, -colliderHeight, -bassinLenght / 2));
            vertices.Add(new Vector3(bassinWidth / 2, -colliderHeight, -bassinLenght / 2));
            vertices.Add(new Vector3(-bassinWidth / 2, -colliderHeight, bassinLenght / 2));
            vertices.Add(new Vector3(bassinWidth / 2, -colliderHeight, bassinLenght / 2));
            int verticesCount = vertices.Count;
            splitPlane(verticesCount - 4, verticesCount - 3, verticesCount - 2, verticesCount - 1, -colliderHeight);

            updatePlane();

        }

     
        InnerFlow();
        if (overFlow > 25  && !isRootBassin)
        {
            OuterFlow();
        }
    }
}
