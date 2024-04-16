using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppsFlyerSDK;
using UnityEngine.SceneManagement;

// This class is intended to be used with the AppsFlyerObject.prefab
public class AppsFlyerObjectScript : MonoBehaviour, IAppsFlyerConversionData
{
    // These fields are set from the editor so do not modify!
    //******************************//
    public string devKey;
    public string appID;
    public string UWPAppID;
    public string macOSAppID;
    public bool isDebug;
    public bool getConversionData;
    public string deeplinkURL;
    //******************************//

    void Start()
    {
        // Initialization code
    }

    void OnDeepLink(object sender, EventArgs args)
    {
        var deepLinkEventArgs = args as DeepLinkEventsArgs;
        // Handling deep link
        if (!string.IsNullOrEmpty(Application.absoluteURL))
        {
            HandlerDLScene(Application.absoluteURL);
        }
        // Other deep link handling code...
    }

    private void HandlerDLScene(string url)
    {
        // Update deep link URL
        deeplinkURL = url;

        // Decode the URL to determine action
        string sceneName = url.Split('?')[1].Split('&')[0];

        bool validScene;
        switch (sceneName)
        {
            case "scene1":
                validScene = true;
                break;
            case "SampleScene":
                validScene = true;
                break;
            default:
                validScene = false;
                break;
        }

        if (validScene)
            SceneManager.LoadScene(sceneName);
    }

    // Implementing AppsFlyer callbacks
    public void onConversionDataSuccess(string conversionData)
    {
        // Callback implementation
    }

    public void onConversionDataFail(string error)
    {
        // Callback implementation
    }

    public void onAppOpenAttribution(string attributionData)
    {
        // Callback implementation
    }

    public void onAppOpenAttributionFailure(string error)
    {
        // Callback implementation
    }
}
