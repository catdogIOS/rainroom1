using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdmobADSnew : MonoBehaviour
{
    private string gameId = "4270906";//★ Window > Services 설정 테스트 바꿀것 (test용 1486550)
    string _adUnitId;

    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        _adUnitId = gameId;

        //Disable button until ad is ready to show
    }

    private void Start()
    {

    }


    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            ShowAd();
        }
    }

    // Implement a method to execute when the user clicks the button.
    public void ShowAd()
    {
            Debug.Log("테ㅅ");
    }


}


