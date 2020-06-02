using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 注文一覧のアイテム
/// </summary>
public class OrderItem : MonoBehaviour
{
    /// <summary>
    /// コールバック
    /// </summary>
    /// <param name="orderId"></param>
    public delegate void CALLBACK(string orderId);
    /// <summary>
    /// コールバック
    /// </summary>
    private CALLBACK callback;

    /// <summary>
    /// ステータス名称
    /// </summary>
    private readonly string[] StateName = { "未達成", "配達中", "配達完了" };

    /// <summary>
    /// ユーザ名テキスト
    /// </summary>
    [SerializeField] private Text UserName = default;
    /// <summary>
    /// 注文日付
    /// </summary>
    [SerializeField] private Text OrderDate = default;
    /// <summary>
    /// 注文ステータス
    /// </summary>
    [SerializeField] private Text State = default;

    /// <summary>
    /// 注文ID
    /// </summary>
    private string orderId;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="orderDate"></param>
    /// <param name="state"></param>
    /// <param name="orderId"></param>
    public void Initialization(string userName, string orderDate, int state, string orderId)
    {
        UserName.text = userName;
        OrderDate.text = orderDate;
        State.text = StateName[state];
        this.orderId = orderId;
    }

    /// <summary>
    /// 注文アイテムクリック時のコールバックイベント追加
    /// </summary>
    /// <param name="callback"></param>
    public void AddCollback(CALLBACK callback)
    {
        this.callback += callback;
    }

    /// <summary>
    /// 注文アイテムのクリックイベント
    /// </summary>
    public void OnClickOrderItem()
    {
        callback?.Invoke(orderId);
    }
}
