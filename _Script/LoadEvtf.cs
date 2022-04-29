using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadEvtf : MonoBehaviour
{
    AsyncOperation async;
    int i = 0;
    //카메라 태그로 찾고 적용
    public GameObject menu_obj;
    public Camera camera_c;

    // Use this for initialization
    void Start()
    {

        PlayerPrefs.SetInt("titlecheck", 0);
        PlayerPrefs.Save();
    }
    IEnumerator Load()
    {
        async = SceneManager.LoadSceneAsync("Main");
        while (!async.isDone)
        {
            yield return true;
        }
    }


    
    // Update is called once per frame
    void Update()
    {
        i++;
        if (i == 70)
        {
            StartCoroutine(Load());
        }
    }
    



}
