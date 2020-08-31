using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class Banner : MonoBehaviour
{
    BannerView banner;
    string bannerId;
    
    void Start()
    {
        RequestBanner();
    }

    void RequestBanner()
    {

#if UNITY_ANDROID
        bannerId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
        bannerId = "ca-app-pub-3940256099942544/6300978111";
#else
        bannerId = null;
#endif

        banner = new BannerView(bannerId, AdSize.Banner, AdPosition.Bottom);


        //call events
        banner.OnAdLoaded += HandleOnAdLoaded;
        banner.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        banner.OnAdOpening += HandleOnAdOpened;
        banner.OnAdClosed += HandleOnAdClosed;
        banner.OnAdLeavingApplication += HandleOnAdLeavingApplication;


        //create and ad request
        if (PlayerPrefs.HasKey("Consent"))
        {
            AdRequest request = new AdRequest.Builder().Build();
            banner.LoadAd(request); //load & show the banner ad
        } else
        {
            AdRequest request = new AdRequest.Builder().AddExtra("npa", "1").Build();
            banner.LoadAd(request); //load & show the banner ad (non-personalised)
        }
    }



    //events below
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //do this when ad loads
    }

    public void HandleOnAdFailedToLoad(object sender, EventArgs args)
    {
        //do this when ad fails to load
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        //do this when ad is opened
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        //do this when ad is closed
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        //do this when on leaving application;
    }
}
