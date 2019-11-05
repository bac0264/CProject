using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AdManager : MonoBehaviour
{

    private const string inters = "ca-app-pub-3940256099942544/1033173712";
    private const string banner = "ca-app-pub-3940256099942544/6300978111";
    private const string reward = "ca-app-pub-3940256099942544/5224354917";
    public static AdManager Ins;
    public InterstitialAd interstitial;
    public RewardBasedVideoAd rewardBasedVideo;
    public BannerView bannerView;
    bool checkReward;
    // Use this for initialization
    void Awake()
    {
        if (Ins == null)
        {
            Ins = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(this);
        // MobileAds.Initialize("ca-app-pub-1589360682424634~2716163106");
        interstitial = new InterstitialAd(inters);
        bannerView = new BannerView(banner, AdSize.Banner, AdPosition.Bottom);
        rewardBasedVideo = RewardBasedVideoAd.Instance;

        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        VideoRequest();
        BannerRequest();
        AdRequest();
    }
    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        VideoRequest();
        if (checkReward) { checkReward = false; }
        else
        {
        }
    }
    public void HandleRewardBasedVideoRewarded(object sender, Reward e)
    {
        checkReward = true;
    }

    void BannerRequest()
    {
        AdRequest requestBanner = new AdRequest.Builder().Build();
        bannerView.LoadAd(requestBanner);
    }
    public void ShowBanner()
    {
        bannerView.Show();
    }

    void VideoRequest()
    {
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardBasedVideo.LoadAd(request, reward);
    }
    void AdRequest()
    {
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }
    public void ShowVideo()
    {
        //#if UNITY_EDITOR
        //        StartCoroutine(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().giftBoxClickIEnumerator());
        //#endif
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }
        else VideoRequest();

    }
    public void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {

            this.interstitial.Show();
            AdRequest();
        }
        else
        {
            AdRequest();
        }

    }

}
