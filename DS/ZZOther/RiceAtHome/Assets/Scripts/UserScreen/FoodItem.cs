using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 食品一覧のボタンアイテム
/// </summary>
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
    [SerializeField] private Text food = default;

    /// <summary>
    /// 値段
    /// </summary>
    [SerializeField] private Text price = default;

    /// <summary>
    /// アイコン
    /// </summary>
    [SerializeField] private Image image = default;

    /// <summary>
    /// 食品ID
    /// </summary>
    private string id;

    /// <summary>
    /// リセットイベント
    /// </summary>
    private void Reset()
    {
        Transform child = transform.Find("Button");
        food = child.Find("food").GetComponent<Text>();
        price = child.Find("price").GetComponent<Text>();
        image = child.Find("image").GetComponent<Image>();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="name"></param>
    /// <param name="id"></param>
    /// <param name="price"></param>
    /// <param name="sprite"></param>
    public void Initialization(string name, string id, int price, Sprite sprite = null)
    {
        this.food.text = name;
        this.price.text = price.ToString() + "円";
        //this.image.sprite = sprite;
        this.id = id;
    }

    /// <summary>
    /// アイコン設定
    /// </summary>
    /// <param name="sprite"></param>
    public void SetIcon(Sprite sprite)
    {
        this.image.sprite = sprite;
    }

    /// <summary>
    /// 食品アイテムクリック時のコールバック追加
    /// </summary>
    /// <param name="callback"></param>
    public void AddCallback(CALLBACK callback)
    {
        this.callback += callback;
    }

    /// <summary>
    /// 食品アイテムのクリックイベント
    /// </summary>
    public void OnClickFoodItem()
    {
        callback?.Invoke(id);
    }
}
