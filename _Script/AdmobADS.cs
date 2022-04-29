using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GoogleMobileAds.Api;
using UnityEngine.UI;


public class AdmobADS : MonoBehaviour {

    //배너
   // private BannerView bannerView;
   // AdRequest request;

    //영상


   // private RewardedAd rewardedAd;
    //private RewardBasedVideoAd rewardBasedVideo;
    string adUnitIdvideo;

    //보상형 전면 광고
   // private RewardedInterstitialAd rewardedInterstitialAd;

    //전면
   // private InterstitialAd interstitial;

    int rewardCoin;
    Color color;
    public GameObject Toast_obj;
    public Text adPop_txt;
    public Button cutTime_btn;

    System.DateTime now;
    System.DateTime lastDateTimenow;

    public GameObject GM;


    // Use this for initialization 앱 ID
    void Start () {



        if (PlayerPrefs.GetInt("outtimecut", 4) == 4 && PlayerPrefs.GetInt("scene", 0) == 0)
        {

            cutTime_btn.interactable = false;
        }
        color = new Color(1f, 1f, 1f);

#if UNITY_ANDROID
        string appId = "ca-app-pub-9179569099191885~5921342761"; //테스트용ca-app-pub-3940256099942544~3347511713
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-9179569099191885~1168848531";
#else
        string appId = "unexpected_platform";
#endif


        this.RequestRewardedVideo();
        //this.RequestInterstitial();

}


    //동영상닫음
    private void HandleRewardedAdClosed(object sender, System.EventArgs args)
    {
        RequestRewardedVideo();
    }


    //배너
 /*   private void RequestBanner()
    {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }


    */
    //동영상
    private void RequestRewardedVideo()
    {

#if UNITY_ANDROID
            adUnitIdvideo = "ca-app-pub-9179569099191885/8650861151"; // 테스트 ca-app-pub-3940256099942544/1712485313
#elif UNITY_IPHONE
        adUnitIdvideo = "ca-app-pub-3940256099942544/1712485313"; ///ㅊㅔ스츠영상넣어짐
#else
        adUnitIdvideo = "unexpected_platform";
#endif


     //   this.rewardedAd = new RewardedAd(adUnitIdvideo);



        // Called when the user should be rewarded for watching a video.
     //   this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
     //   this.rewardedAd.OnAdClosed += HandleRewardBasedVideoClosed;


     //  AdRequest request = new AdRequest.Builder().Build();
     //   this.rewardedAd.LoadAd(request);

    }
    /*
    //시청보상
    public void HandleUserEarnedReward(object sender, Reward args)
    {

        lastDateTimenow = System.DateTime.Now;
        if (PlayerPrefs.GetInt("scene", 0) == 2)
        {
            PlayerPrefs.SetString("adtimespark", lastDateTimenow.ToString());
        }
        else if (PlayerPrefs.GetInt("scene", 0) == 3)
        {
            PlayerPrefs.SetString("adtimescity", lastDateTimenow.ToString());
        }
        else if (PlayerPrefs.GetInt("scene", 0) == 0)
        {
            PlayerPrefs.SetString("adtimes", lastDateTimenow.ToString());
        }
        else
        {
            PlayerPrefs.SetString("adtimes", lastDateTimenow.ToString());
        }
        GM.GetComponent<ShowAds>().AdReward();
        PlayerPrefs.SetInt("talk", 5);
    }
    */

    //동영상닫음
    private void HandleRewardBasedVideoClosed(object sender, System.EventArgs args)
    {
        this.RequestRewardedVideo();
    }

    public void showAdmobVideo()
    {/*
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
        else
        {
            Toast_obj.SetActive(true);
            adPop_txt.text = "아직 볼 수 없다." + "\n" + " 나중에 시도해보자.";
        }
        */
    }
    

    /*
    public void callBanner()
    {
        this.RequestBanner();
    }
    */

    /*
    //전면광고
    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9179569099191885/1598954374"; // 테스트ca-app-pub-3940256099942544/4411468910
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-9179569099191885/5160064432"; 
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
        
    }
    

    public void ShowAdInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            PlayerPrefs.SetInt("outtimecut", 4);
            cutTime_btn.interactable = false;
        }
    }

    //보상형 전면 광고
    private void adLoadCallback(RewardedInterstitialAd ad, AdFailedToLoadEventArgs error)
    {
        if (error == null)
        {
            rewardedInterstitialAd = ad;
            rewardedInterstitialAd.OnAdFailedToPresentFullScreenContent += HandleAdFailedToPresent;

        }
    }

    //보상형 전면 광고 보여주기
    public void ShowRewardedInterstitialAd()
    {
        if (rewardedInterstitialAd != null)
        {
            rewardedInterstitialAd.Show(userEarnedRewardCallback);
        }
    }

    private void userEarnedRewardCallback(Reward reward)
    {
        // TODO: Reward the user.
        PlayerPrefs.SetInt("outtimecut", 4);
        cutTime_btn.interactable = false;
    }
    private void HandleAdFailedToPresent(object sender, AdErrorEventArgs args)
    {
        //MonoBehavior.print("Rewarded interstitial ad has failed to present.");
    }
    */
}
