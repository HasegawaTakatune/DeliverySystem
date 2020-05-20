using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
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
