using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    public int currentExp;
    public int maxExp;
    public int lvl;
    public int maxStat;
    public int maxRe = 10;

    public Image myImage;

    //pentagraph stats
    public int heatResist;
    public int coldResist;
    public int antiResist;
    public int fatality;
    public int reproduce;

    public int money;

    //text on screen
    public Text expText;
    public Text lvlText;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("Start", 0);

        //beginning game bool used only once
        if (PlayerPrefs.GetInt("Start") == 0)
        {
            PlayerPrefs.SetInt("CurrentExp", 0);
            PlayerPrefs.SetInt("MaxExp", 5);
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.SetInt("MaxStat", 50);
            PlayerPrefs.SetInt("HR", 1);
            PlayerPrefs.SetInt("CR", 1);
            PlayerPrefs.SetInt("AR", 1);
            PlayerPrefs.SetInt("F", 1);
            PlayerPrefs.SetInt("RR", 1);

            PlayerPrefs.SetInt("Start", 1);
        }
        currentExp = PlayerPrefs.GetInt("CurrentExp");
        maxExp = PlayerPrefs.GetInt("MaxExp");
        lvl = PlayerPrefs.GetInt("Level");
        maxStat = PlayerPrefs.GetInt("MaxStat");
        heatResist = PlayerPrefs.GetInt("HR");
        coldResist = PlayerPrefs.GetInt("CR");
        antiResist = PlayerPrefs.GetInt("AR");
        fatality = PlayerPrefs.GetInt("F");
        reproduce = PlayerPrefs.GetInt("RR");

        lvlText.text = "Lv " + lvl;
        expText.text = "Exp: " + PlayerPrefs.GetInt("CurrentExp") + " / " + maxExp;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
