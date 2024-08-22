using System;
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class LoadAssetBundles : MonoBehaviour
{
    private string assetBundleUrl = "https://fpl.expvn.com/AssetBundles_update1/movie1"; // Đường dẫn tới AssetBundle
    private string assetBundleName = "movie1"; // Tên của AssetBundle

    private void Start()
    {
        print("start");
        StartCoroutine(LoadAssetBundle());
    }

    private IEnumerator LoadAssetBundle()
    {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(assetBundleUrl);
        www.SendWebRequest();
        while (!www.isDone)
        {
            yield return null;
            Debug.Log("Progress: " + (int)(www.downloadProgress * 100f) + "%");
        }

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Lỗi khi tải AssetBundle: " + www.error);
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            Debug.Log("Đã tải và lưu AssetBundle vào cache: " + assetBundleName);
        }
        www.Dispose();
    }
}