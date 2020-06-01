using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 店一覧のボタンアイテム
/// </summary>
public class StoreItem : MonoBehaviour
{
    /// <summary>
    /// コールバック
    /// </summary>
    /// <param name="id"></param>
    public delegate void CALLBACK(string id);

    /// <summary>
    /// コールバック
    /// </summary>
    private CALLBACK callback;

    /// <summary>
    /// 店名
    /// </summary>
    [SerializeField] private Text store = default;

    /// <summary>
    /// アイコン
    /// </summary>
    [SerializeField] private Image icon = default;

    /// <summary>
    /// 店ID
    /// </summary>
    private string id;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="name"></param>
    /// <param name="id"></param>
    /// <param name="sprite"></param>
    public void Initialization(string name, string id, Sprite sprite = null)
    {
        this.store.text = name;
        this.icon.sprite = sprite;
        this.id = id;
    }

    /// <summary>
    /// アイコン設定
    /// </summary>
    /// <param name="sprite"></param>
    public void SetIcon(Sprite sprite)
    {
        this.icon.sprite = sprite;
    }

    /// <summary>
    /// コールバック追加
    /// </summary>
    /// <param name="callback"></param>
    public void AddCallback(CALLBACK callback)
    {
        this.callback += callback;
    }

    /// <summary>
    /// クリックイベント
    /// </summary>
    public void OnClickEvent()
    {
        callback(id);
    }
}
