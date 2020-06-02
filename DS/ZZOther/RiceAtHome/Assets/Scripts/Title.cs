using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タイトル
/// </summary>
public class Title : MonoBehaviour
{
    /// <summary>
    /// タイトルイメージ
    /// </summary>
    [SerializeField] private Image Image = default;
    /// <summary>
    /// ユーザ画面
    /// </summary>
    [SerializeField] private GameObject UserScreen = default;
    /// <summary>
    /// 店側画面
    /// </summary>
    [SerializeField] private GameObject StoreScreen = default;

    /// <summary>
    /// ユーザ判定
    /// </summary>
    public bool IsUserMode = true;

    /// <summary>
    /// 開始と同時に実行するかを判定
    /// </summary>
    [SerializeField] private bool playOnAwake = true;

    /// <summary>
    /// リセットイベント
    /// </summary>
    private void Reset()
    {
        Image = gameObject.GetComponentInChildren<Image>();
        UserScreen = GameObject.Find("UserScreen");
        StoreScreen = GameObject.Find("StoreScreen");
    }

    /// <summary>
    /// スタートイベント
    /// </summary>
    private void Start()
    {
        UserScreen.SetActive(false);
        StoreScreen.SetActive(false);

        if (playOnAwake)
            StartCoroutine(ShowTitle());
    }

    /// <summary>
    /// タイトル表示
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShowTitle()
    {
        Color color = Color.clear;
        float interval = Time.deltaTime * 0.1f;
        
        // タイトルフレームイン
        while (color.a <= 1)
        {
            yield return null;
            color += new Color(1, 1, 1, interval);
            Image.color = color;
        }
        // タイトルフレームアウト
        while (0 <= color.a)
        {
            yield return null;
            color -= new Color(1, 1, 1, interval);
            Image.color = color;
        }
        gameObject.SetActive(false);

        // ユーザ/店ごとに画面を表示する
        if (IsUserMode)
            UserScreen.SetActive(true);
        else
            StoreScreen.SetActive(true);
    }
}
