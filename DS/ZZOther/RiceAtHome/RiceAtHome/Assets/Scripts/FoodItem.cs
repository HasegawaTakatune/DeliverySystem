using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodItem : MonoBehaviour
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
    /// 食品名
    /// </summary>
    [SerializeField] private Text food;

    /// <summary>
    /// 値段
    /// </summary>
    [SerializeField] private Text price;

    /// <summary>
    /// アイコン
    /// </summary>
    [SerializeField] private Image icon;

    /// <summary>
    /// 食品ID
    /// </summary>
    private string id;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="name"></param>
    /// <param name="id"></param>
    /// <param name="price"></param>
    /// <param name="sprite"></param>
    public void InitFoodButton(string name, string id, int price, Sprite sprite = null)
    {
        this.food.text = name;
        this.price.text = price.ToString() + "円";
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
