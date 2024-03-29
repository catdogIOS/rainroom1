﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTimeHandler : MonoBehaviour {

	//비
	public int getRain,rain;
	//시간
	public int talk;
	public Text talkTime_txt,talkNum;
	string lastTime;

    public int coldRain_i, hotRain_i;

    //경고
    public GameObject warring_obj;
    public Text warningTxt;


    //아이폰
    bool bPaused = false;

    public GameObject homePop_obj;
    public Text home_txt;

    // Use this for initialization
    void Start () {

        //빗물
        collectRain ();
		//대화
		StartCoroutine ("talkTimeFlow");
        //이부분은 생성될때 한번만 실행된다
        //돈디스트로이로 씬을 넘어가도 다시 실행되지 않는다
        if (talk >= 5)
        {
            PlayerPrefs.SetString("TalkLastTime", System.DateTime.Now.ToString());
        }
    }

    void Warring()
    {
        //부정행위방지
        if (getRain > 36000)
        {//5일치 이상 모았을때
            if (getRain > 100000)
            {//2주일 되었을 때
                getRain = 0;
                warningTxt.text = "빗물이 너무 모여 물탱크가 터져버렸다." + "\n"+"겨우 수리했다.";
                warring_obj.SetActive(true);
            }
            else
            {
                getRain = 36000; //물탱크가 꽉 찼다
                warningTxt.text = "장기간 방치로 인해 물탱크기능이 멈췄다." + "\n"+"이제 작동한다.";
                warring_obj.SetActive(true);
            }
        }
    }


	void collectRain(){

        string str = PlayerPrefs.GetString("code", "");
        coldRain_i = PlayerPrefs.GetInt(str + "r", 0);
        hotRain_i = PlayerPrefs.GetInt(str + "h", 0);
        

		//모인 빗물
		//현재시간을가져옵니다
		System.DateTime dateTimenow = System.DateTime.Now;
		//str로장되어있는과거접속시간을가져옵니다
		string lastTimem = PlayerPrefs.GetString("lastTime",dateTimenow.ToString());
		//형변환을해줍니다
		System.DateTime lastDateTimem = System.DateTime.Parse(lastTimem);
		//계산
		System.TimeSpan compareTimem =  System.DateTime.Now - lastDateTimem;
		//1분당1씩줍니다
		getRain = (int)compareTimem .TotalMinutes;
        getRain = getRain * 5;
        Warring();
        coldRain_i = coldRain_i + getRain;
		PlayerPrefs.SetInt (str + "r", coldRain_i);
		//rainNum.text = coldRain_i.ToString();
		PlayerPrefs.SetString("lastTime",dateTimenow.ToString());
		PlayerPrefs.Save ();

        //빗물이 마이너스일때
        if (coldRain_i<0)
        {
            PlayerPrefs.SetInt(str + "r", -9);
            PlayerPrefs.Save();
        }
	}
    public void closeWarring()
    {
        warring_obj.SetActive(false);
    }



	//대화시간코루틴
	IEnumerator talkTimeFlow(){
		int minute;
		int sec;
		int a = 0;
		while (a == 0) {
			talk = PlayerPrefs.GetInt ("talk", 5);
			lastTime = PlayerPrefs.GetString ("TalkLastTime", System.DateTime.Now.ToString ());
			System.DateTime lastDateTime = System.DateTime.Parse (lastTime);
			System.TimeSpan compareTime = System.DateTime.Now - lastDateTime;
            if ((int)compareTime.TotalSeconds < 0)
            {
                compareTime = System.DateTime.Now - System.DateTime.Now;
            }
            minute = (int)compareTime.TotalMinutes;
			sec = (int)compareTime.TotalSeconds;
            sec = sec - (sec / 60) * 60;
            sec = 59 - sec;
			minute = 4 - minute;
            
            if (minute < 0) {
				while (minute < 0) {
					minute = minute + 5;
					//sec = sec + 59;
					talk++;
				}
                //시간을 중간부터 하기위해
                //PlayerPrefs.SetInt("timeminhelp", 4-minute);
                //PlayerPrefs.SetInt("timesechelp", 59-sec);
                //Debug.Log("minute" + minute+ "sec" + sec);
                //Debug.Log(""+System.DateTime.Now.ToString());
                PlayerPrefs.SetString ("TalkLastTime", System.DateTime.Now.ToString ());
				//talkTime_txt.text = "04:59";
			} else {
				string str = string.Format (@"{0:00}" + ":", minute) + string.Format (@"{0:00}", sec);
				talkTime_txt.text = "" + str;

            }
            
            if (PlayerPrefs.GetInt("scene", 0) == 3)
            {
                talkTime_txt.color = Color.white;
                talkNum.color = Color.white;
            }
            else
            {
                talkTime_txt.color = new Color(50 / 255f, 50 / 255f, 50 / 255f);
                talkNum.color = new Color(50 / 255f, 50 / 255f, 50 / 255f);
            }

            talkNum.text = talk.ToString ();
			if (talk >= 5) {
				talkTime_txt.text = "00:00";
				talk = 5;
				talkNum.text = talk.ToString ();
            }
			PlayerPrefs.SetInt ("talk", talk);
			PlayerPrefs.Save ();
		
			yield return new WaitForSeconds(0.1f);
		}
	}


    //아이폰 홈버튼 대응
    void OnApplicationPause(bool pause)

    {
        if (pause)

        {
            bPaused = true;

            // todo : 어플리케이션을 내리는 순간에 처리할 행동들 /
            //저장
            PlayerPrefs.Save();
        }
        else
        {
            if (bPaused)
            {
                bPaused = false;
                //todo : 내려놓은 어플리케이션을 다시 올리는 순간에 처리할 행동들
                //비모아두기
                collectRain();
                    //돌아왔을 때 인사
                    //welcomeBackOut();
                    homePop_obj.SetActive(true);
                    home_txt.text = "돌아왔구나.";
                    StartCoroutine("closeToast");
            }
        }
    }

    //토스트
    IEnumerator closeToast()
    {
        Color colorN;
        colorN = new Color(255f / 255f, 255f / 255f, 255f / 255f);
        colorN.a = Mathf.Lerp(0f, 1f, 1f);
        homePop_obj.GetComponent<Image>().color = colorN;
        homePop_obj.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        for (float i = 1f; i > 0f; i -= 0.02f)
        {
            colorN.a = Mathf.Lerp(0f, 1f, i);
            homePop_obj.GetComponent<Image>().color = colorN;
            yield return null;
        }
        homePop_obj.SetActive(false);

    }
}
