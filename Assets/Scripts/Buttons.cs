using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

    bool stat;
    bool lab;
    bool store;

    //val for stat Menu
    Stat myStat;
    public GameObject statMenu;
    public Text hr;
    public Text cr;
    public Text ar;
    public Text f;
    public Text rr;

    // Use this for initialization
    void Start () {
        myStat = GameObject.Find("me").GetComponent<Stat>();

        stat = false;
        lab = false;
        store = false;

	}
	
	// Update is called once per frame
	void Update () {
		if(stat == true)
        {
            this.GetComponent<GraphRender>().enabled = true;
            statMenu.SetActive(true);
        }
        else
        {
            this.GetComponent<GraphRender>().enabled = false;
            statMenu.SetActive(false);
        }

	}

    public void StatOn()
    {
        stat = true;
        GameObject.Find("Stat").GetComponent<Image>().color = Color.white;
        GameObject.Find("Test").GetComponent<Image>().color = Color.gray;
        GameObject.Find("Store").GetComponent<Image>().color = Color.gray;

        hr.text = "" + myStat.heatResist + " / " + myStat.maxStat;
        cr.text = "" + myStat.coldResist + " / " + myStat.maxStat;
        ar.text = "" + myStat.antiResist + " / " + myStat.maxStat;
        f.text = "" + myStat.fatality    + " / " + myStat.maxStat;
        rr.text = "" + myStat.reproduce  + " / " + myStat.maxRe;
    }
}
