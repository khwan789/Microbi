using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{

    GameObject mainChar;
    PuddingEffect pudding;
    Buttons myButtonOptions;

    Stat myStat;

    // Use this for initialization
    void Start()
    {
        mainChar = GameObject.Find("me");
        myStat = mainChar.GetComponent<Stat>();
        myButtonOptions = GameObject.Find("Controller").GetComponent<Buttons>();

        this.GetComponent<Button>().onClick.AddListener(EatFood);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void EatFood()
    {
        Vector3 target = new Vector3(this.transform.position.x, this.transform.position.y, -1);

        StartCoroutine(MoveOverSeconds(mainChar, target, 0.5f));
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
        Destroy(this.gameObject);
        //change stat info
        myStat.currentExp++;

        LevelUp();
    }

    private void LevelUp()
    {
        //levelUP
        if (myStat.currentExp == myStat.maxExp)
        {
            PlayerPrefs.SetInt("Level", myStat.lvl + 1);
            PlayerPrefs.SetInt("MaxExp", myStat.maxExp * 2);
            PlayerPrefs.SetInt("CurrentExp", 0);
            myStat.currentExp = PlayerPrefs.GetInt("CurrentExp");
            myStat.lvl = PlayerPrefs.GetInt("Level");
            myStat.maxExp = PlayerPrefs.GetInt("MaxExp");

            PlayerPrefs.SetInt("HR", myStat.heatResist + 2);
            PlayerPrefs.SetInt("CR", myStat.coldResist + 2);
            PlayerPrefs.SetInt("AR", myStat.antiResist + 2);
            PlayerPrefs.SetInt("F", myStat.fatality + 2);
            //PlayerPrefs.SetInt("RR", myStat.reproduce + 2);
            myStat.heatResist = PlayerPrefs.GetInt("HR");
            myStat.coldResist = PlayerPrefs.GetInt("CR");
            myStat.antiResist = PlayerPrefs.GetInt("AR");
            myStat.fatality = PlayerPrefs.GetInt("F");
            //myStat.reproduce = PlayerPrefs.GetInt("RR");

        }
        myStat.lvlText.text = "Lv " + myStat.lvl;
        myStat.expText.text = "Exp: " + myStat.currentExp + " / " + myStat.maxExp;

        myButtonOptions.hr.text = "" + myStat.heatResist + " / " + myStat.maxStat;
        myButtonOptions.cr.text = "" + myStat.coldResist + " / " + myStat.maxStat;
        myButtonOptions.ar.text = "" + myStat.antiResist + " / " + myStat.maxStat;
        myButtonOptions.f.text = "" + myStat.fatality    + " / " + myStat.maxStat;
        myButtonOptions.rr.text = "" + myStat.reproduce  + " / " + myStat.maxRe;
    }

}
