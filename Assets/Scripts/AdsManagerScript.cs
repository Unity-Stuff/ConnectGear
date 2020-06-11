using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class AdsManagerScript : MonoBehaviour {

    public bool enableVideoAds;
    public bool enableBannerAds;
    public bool enableInterAds;


    private BannerView bannerView;
    private RewardBasedVideoAd rewardBasedVideo;
    // Initialize the Google Mobile Ads SDK.
    // Use this for initialization
    void Start () {

#if UNITY_ANDROID
        string appId = "ca-app-pub-1017665115933587~6259521289";
#elif UNITY_IPHONE
            string appId = "NotSetupYet";
#else
            string appId = "unexpected_platform";
#endif
        MobileAds.Initialize(appId);
        if(enableBannerAds)
            this.RequestBanner();

        if(enableVideoAds)
            this.RequestRewardBasedVideo();

        if(enableInterAds)
            this.RequestInterstitial();
        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;
    }




    private void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID

        string adUnitId = "ca-app-pub-1017665115933587/5920609933";
#elif UNITY_IPHONE
            string adUnitId = "NotSetupYet";
#else
            string adUnitId = "unexpected_platform";
#endif
        //TestAdsId
        //string adUnitId = "ca-app-pub-3940256099942544/5224354917";

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        if (enableVideoAds)
        {
            // Load the rewarded video ad with the request.
            this.rewardBasedVideo.LoadAd(request, adUnitId);
        }
        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }
    }





    private void RequestBanner()
    {
#if UNITY_ANDROID

        string adUnitId = "ca-app-pub-1017665115933587/3597575218";
#elif UNITY_IPHONE
            string adUnitId = "NotYetSetup";
#else
            string adUnitId = "unexpected_platform";
#endif
        //TestAdsId
        //string adUnitId = "ca-app-pub-3940256099942544/6300978111";

        // Create a 320x50 banner at the bottom of the screen.
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        if (enableBannerAds)
        {
            // Load the banner with the request.
            bannerView.LoadAd(request);
        }
        // Called when an ad request has successfully loaded.
        bannerView.OnAdLoaded += HandleOnBannerAdLoaded;
    }

    public void HandleOnBannerAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleBannerAdLoaded event received");
        bannerView.Show();
    }




    private InterstitialAd interstitial;

    private void RequestInterstitial()
    {
#if UNITY_ANDROID

        string adUnitId = "ca-app-pub-1017665115933587/3055661498";
#elif UNITY_IPHONE
        string adUnitId = "NotYetSetup";
#else
        string adUnitId = "unexpected_platform";
#endif
        //TestAdsId
        //string adUnitId = "ca-app-pub-3940256099942544/1033173712";

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        if (enableInterAds)
        {
            // Load the interstitial with the request.
            this.interstitial.LoadAd(request);
        }
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    private void Update()
    {
        if(enableInterAds)
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
            }
        if(enableVideoAds)
            if (this.rewardBasedVideo.IsLoaded())
            {
                this.rewardBasedVideo.Show();
            }
    }

}
