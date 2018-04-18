using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodForThought : MonoBehaviour
{
    Vector3 centerPos;    //center of circle/elipsoid
    int numPoints = 1;
    public GameObject pointPrefab;                    //generic prefab to place on each point
    GameObject[] foods;
    int center = 190;
    public Canvas myCanvas;
    int radiusX, radiusY;                    //radii for each x,y axes, respectively

    Vector3 pointPos;                                //position to place each prefab along the given circle/eliptoid
                                                     //*is set during each iteration of the loop

    // Use this for initialization
    void Start()
    {
        SpawnFood(3);

        InvokeRepeating("SpawnFood", 13, 13);

        
    }

    private void SpawnFood(int numPoints)
    {
        foods = new GameObject[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            //multiply 'i' by '1.0f' to ensure the result is a fraction
            float pointNum = ((i + 1) * 1.0f) / (numPoints + 1);
            
            Vector3 randomVec = Random.insideUnitCircle;

            radiusX = (int)Random.Range(250, 350);
            radiusY = (int)Random.Range(200, 300);

            pointPos = new Vector3(randomVec.x * radiusX, randomVec.y * radiusY);

            Vector3 final = Camera.main.ScreenToWorldPoint(new Vector3(pointPos.x + 400, pointPos.y + 640 + center));

            //place the prefab at given position
            foods[i] = Instantiate(pointPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            foods[i].transform.SetParent(GameObject.Find("Canvas").transform, false);
            foods[i].transform.position = new Vector3(final.x, final.y, 89.9f);
        }
    }
    private void SpawnFood()
    {
        foods = new GameObject[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            //multiply 'i' by '1.0f' to ensure the result is a fraction
            float pointNum = ((i + 1) * 1.0f) / numPoints + 1;
                        
            Vector3 randomVec = Random.insideUnitCircle;

            radiusX = (int)Random.Range(0, 350);
            radiusY = (int)Random.Range(0, 300);

            pointPos = new Vector3(randomVec.x * radiusX, randomVec.y * radiusY);

            Vector3 final = Camera.main.ScreenToWorldPoint(new Vector3(pointPos.x + 400, pointPos.y + 640 + center));

            //place the prefab at given position
            foods[i] = Instantiate(pointPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            foods[i].transform.SetParent(GameObject.Find("Canvas").transform, false);
            foods[i].transform.position = new Vector3(final.x, final.y, 89.9f);
        }
    }
}
