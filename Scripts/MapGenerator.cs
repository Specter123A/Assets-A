using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject roofPrev;
	public GameObject floorPrev;
	public GameObject roof;
	public GameObject floor;
	
    public GameObject player;

    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;

    public GameObject obstaclePrefab;

    //obstacles position
    public float minObsY;
    public float maxObsY;

    //obstacle spacing
    public float minObsSpace;
    public float maxObsSpace;

    //obstacle scale
    public float minObsScaleY;
    public float maxObsScaleY;

// initialzing
    void Start()
    {
        obstacle1 = GenerateObstacles(player.transform.position.x + 10);
        obstacle2 = GenerateObstacles(obstacle1.transform.position.x + 10);
        obstacle3 = GenerateObstacles(obstacle2.transform.position.x + 10);
        obstacle4 = GenerateObstacles(obstacle4.transform.position.x + 10);     
    }


    GameObject GenerateObstacles (float ReferenceX)
    {
        GameObject obstacle = GameObject.Instantiate (obstaclePrefab);
        SetTransform(obstacle,ReferenceX);
		return obstacle;
    }

    void SetTransform ( GameObject obstacle, float ReferenceX)
    {
        obstacle.transform.position = new Vector3(ReferenceX + Random.Range(minObsSpace, maxObsSpace), Random.Range(minObsY, maxObsY),0);
        obstacle.transform.localScale = new Vector3(obstacle.transform.localScale.x, Random.Range(minObsScaleY, maxObsScaleY), obstacle.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > floor.transform.position.x)
        {
            var temproof = roofPrev;
            var tempfloor = floorPrev;
            roofPrev = roof;
            floorPrev = floor;
            temproof.transform.position += new Vector3 (80,0,0);
            tempfloor.transform.position += new Vector3 (80,0,0);

            roof = temproof;
            floor = tempfloor;
        }

        if (player.transform.position.x > obstacle2.transform.position.x)
        {
            var tempObs = obstacle1;
            obstacle1 = obstacle2;
            obstacle2 = obstacle3;
            obstacle3 = obstacle4;

            SetTransform(tempObs,  obstacle3.transform.position.x);
            obstacle4 = tempObs;
        }
    }
}
