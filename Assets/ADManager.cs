using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADManager : MonoBehaviour
{
    
    private BannerView banner;
    private string BannerID = "ca-app-pub-3940256099942544/6300978111";

    private InterstitialAd interstitialAd;
    private string interstitialAdID = "ca-app-pub-3940256099942544/1033173712";

    private string appID ="ca-app-pub-3985965740648311~4979116246";

    private void Start() {
        requestBanner();
        requestInterstitial ();
    }

    void requestBanner (){
        banner = new BannerView (BannerID , AdSize.Banner, AdPosition.Bottom);

        AdRequest request= new AdRequest.Builder().Build();

        banner.LoadAd(request);

        banner.Show();
    }

    void requestInterstitial (){
        interstitialAd = new InterstitialAd ( BannerID);

        AdRequest request = new AdRequest.Builder().Build();
        
        interstitialAd.LoadAd(request);
      }

     public void ShowFullScreenAd (){
          if (interstitialAd.IsLoaded()){
              interstitialAd.Show();
          }
          else{
              Debug.Log("Not Working");
          }
      }

}
