using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// デバッグモード制御
/// </summary>
public class ChangeDebugMode : MonoBehaviour
{
    /// <summary>
    /// ユーザモード
    /// </summary>
    private const string USER_MODE = "User";
    /// <summary>
    /// 店モード
    /// </summary>
    private const string STORE_MODE = "Store";

    /// <summary>
    /// ユーザ画面
    /// </summary>
    [SerializeField] private GameObject UserScreen = default;
    /// <summary>
    /// 店画面
    /// </summary>
    [SerializeField] private GameObject StoreScreen = default;
    /// <summary>
    /// タイトル
    /// </summary>
    [SerializeField] private Title Title = default;

    /// <summary>
    /// ボタンテキスト
    /// </summary>
    [SerializeField] private Text text = default;

    /// <summary>
    /// デバッグ判定
    /// </summary>
    [SerializeField] private bool isDebug = true;

    /// <summary>
    /// ユーザモード判定
    /// </summary>
    [SerializeField] private bool isUserMode = true;

    /// <summary>
    /// リセットイベント
    /// </summary>
    private void Reset()
    {
        UserScreen = transform.parent.Find("UserScreen").gameObject;
        StoreScreen = transform.parent.Find("StoreScreen").gameObject;
        Title = transform.parent.Find("Title").GetComponent<Title>();
        text = transform.Find("ChangeDebugModeButton").Find("Text").GetComponent<Text>();
    }

    /// <summary>
    /// スタートイベント
    /// </summary>
    private void Start()
    {
        if (isDebug)
        {
            Title.IsUserMode = isUserMode;
            text.text = (isUserMode ? USER_MODE : STORE_MODE);
        }
        else
            gameObject.SetActive(false);
    }

    /// <summary>
    /// デバッグモード変更ボタンクリックイベント
    /// </summary>
    public void OnClickChangeDebugMode()
    {
        isUserMode = !isUserMode;

        if (isUserMode)
        {
            // ユーザモード
            text.text = USER_MODE;
            UserScreen.SetActive(true);
            StoreScreen.SetActive(false);
        }
        else
        {
            // 店モード
            text.text = STORE_MODE;
            UserScreen.SetActive(false);
            StoreScreen.SetActive(true);
        }
    }
}
