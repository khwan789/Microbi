using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphRender : MonoBehaviour
{
    //variables for radar graph
    Vector3[] dotPos;

    LineRenderer radarGraph;
    LineRenderer myLine;

    Stat myStat;


    // Use this for initialization
    void Start()
    {
        myStat = GameObject.Find("me").GetComponent<Stat>();
        dotPos = new Vector3[5];
        RadarGraph();

        myLine = GameObject.Find("Lines").GetComponent<LineRenderer>();
        radarGraph = GameObject.Find("RadarGraph").GetComponent<LineRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            radarGraph.SetPosition(i, dotPos[i]);
        }
        radarGraph.SetPosition(5, dotPos[0]);

        myLine.SetPosition(0, CalculatePosi(0, myStat.heatResist));
        myLine.SetPosition(1, CalculatePosi(1, myStat.coldResist));
        myLine.SetPosition(2, CalculatePosi(2, myStat.antiResist));
        myLine.SetPosition(3, CalculatePosi(3, myStat.fatality));
        myLine.SetPosition(4, CalculatePosi(4, myStat.reproduce));
        myLine.SetPosition(5, CalculatePosi(0, myStat.heatResist));
    }

    private void RadarGraph()
    {
        for (int i = 0; i < 5; i++)
        {
            //multiply 'i' by '1.0f' to ensure the result is a fraction
            float pointNum = ((i + 1) * 1.0f) / 5;

            //angle along the unit circle for placing points
            float angle = pointNum * Mathf.PI * 2;

            float radiusX = 110; // (int)Random.Range(0, 350);
            float radiusY = 110; // (int)Random.Range(0, 300);

            //Debug.Log(radiusX + " " + radiusY);

            int x = (int)(Mathf.Sin(angle) * radiusX);
            int y = (int)(Mathf.Cos(angle) * radiusY);
            Vector3 pointPos = new Vector3(x, y);

            Vector3 final = Camera.main.ScreenToWorldPoint(new Vector3(pointPos.x + 600, pointPos.y + 580 - 360)); //-360 is center;

            //place the prefab at given position
            dotPos[i] = new Vector3(final.x, final.y, 89.9f);
        }
    }

    private Vector3 CalculatePosi(int i, float num)
    {
        //multiply 'i' by '1.0f' to ensure the result is a fraction
        float pointNum = ((i + 1) * 1.0f) / 5;

        //angle along the unit circle for placing points
        float angle = pointNum * Mathf.PI * 2;

        float radiusX = num; // (int)Random.Range(0, 350);
        float radiusY = num; // (int)Random.Range(0, 300);

        //Debug.Log(radiusX + " " + radiusY);

        int x = (int)(Mathf.Sin(angle) * radiusX);
        int y = (int)(Mathf.Cos(angle) * radiusY);
        Vector3 pointPos = new Vector3(x, y);

        Vector3 final = Camera.main.ScreenToWorldPoint(new Vector3(pointPos.x + 600, pointPos.y + 580 - 360, 1)); //-360 is center;

        return final;
    }

    private void ShowStat()
    {

    }
}
