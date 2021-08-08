using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adManager : MonoBehaviour,IUnityAdsListener
{
public static adManager Instance;
private GameOverHandler gameOverHandler;

[SerializeField] private bool testMode = true;


#if UNITY_ANDROID
    private string gameId = "4253511";
#elif UNITY_IOS
    private string gameId = "4253510";
#endif

    

    private void Awake() 
 {
     if(Instance != null && Instance != this)
     {
         Destroy(gameObject);
     }else
     {
         Instance = this;
         DontDestroyOnLoad(gameObject);

         Advertisement.AddListener(this);
         Advertisement.Initialize(gameId,testMode);
     }
 }

 public void showAd(GameOverHandler gameOverHandler)
 {
     this.gameOverHandler = gameOverHandler;

     Advertisement.Show("Rewarded_Video");
 }


public void OnUnityAdsDidError(string message)
    {
        Debug.LogError($"Unity Ads Error:{message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch(showResult)
        { case ShowResult.Finished:
               
            gameOverHandler.ContinueGame();

               break;
          case ShowResult.Skipped:

               //ad was skipped

               break;
          case ShowResult.Failed:
             
               Debug.Log("Ads Failed");

               break;

        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Unity Ads Started");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Unity Ads Ready");
    }

}
