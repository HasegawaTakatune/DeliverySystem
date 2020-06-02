using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 表示する注文の種類を切り替える
/// </summary>
public class Top : MonoBehaviour
{
    /// <summary>
    /// オーダー
    /// </summary>
    [SerializeField] private Order Order = default;

    /// <summary>
    /// リセットイベント
    /// </summary>
    private void Reset()
    {
        Order = GameObject.Find("Order").GetComponent<Order>();
    }

    /// <summary>
    /// 選択イベント
    /// </summary>
    /// <param name="state"></param>
    public void OnClickSelect(int state = 0)
    {
        gameObject.SetActive(false);
        Order.Show("0000001", state);
    }

}
