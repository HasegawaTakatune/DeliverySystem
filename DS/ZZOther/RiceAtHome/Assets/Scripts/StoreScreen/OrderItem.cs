using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderItem : MonoBehaviour
{
    public delegate void CALLBACK(string id);

    private CALLBACK callback;

    private readonly string[] StateName = { "未達成", "配達中", "配達完了" };

    [SerializeField] private Text UserName = default;
    [SerializeField] private Text OrderDate = default;
    [SerializeField] private Text State = default;
    private string orderId;

    public void Initialization(string userName, string orderDate, int state, string orderId)
    {
        UserName.text = userName;
        OrderDate.text = orderDate;
        State.text = StateName[state];
        this.orderId = orderId;
    }

    public void AddCollback(CALLBACK callback)
    {
        this.callback += callback;
    }

    public void OnClickDetails()
    {
        callback(orderId);
    }
}
