using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 食品一覧のアイテム
/// </summary>
public class FoodItem2 : MonoBehaviour
{
    /// <summary>
    /// 食品名
    /// </summary>
    [SerializeField] private Text Name = default;

    /// <summary>
    /// 値段
    /// </summary>
    [SerializeField] private Text Price = default;

    /// <summary>
    /// リセットイベント
    /// </summary>
    private void Reset()
    {
        Name = transform.Find("Name").GetComponent<Text>();
        Price = transform.Find("Price").GetComponent<Text>();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="name"></param>
    /// <param name="price"></param>
    public void Initialization(string name, int price)
    {
        Name.text = name;
        Price.text = price + "円";
    }
}
