using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using NCMB;
using Common;

    /// <summary>
    /// 注文の表示/選択を制御する
    /// </summary>
public class Order : MonoBehaviour
{
    /// <summary>
    /// 注文マスタ
    /// </summary>
    private const string ORDER_MASTER_TABLE = "OrderMaster";

    /// <summary>
    /// 店ID
    /// </summary>
    private const string STOREID_COLUMN = "StoreId";
    /// <summary>
    /// ユーザ名
    /// </summary>
    private const string USER_NAME_COLUMN = "UserName";
    /// <summary>
    /// ユーザ住所
    /// </summary>
    private const string USER_ADDRESS_COLUMN = "UserAddress";
    /// <summary>
    /// ユーザ電話番号
    /// </summary>
    private const string USER_TELEPHONR_COLUMN = "UserTelephone";
    /// <summary>
    /// 注文日付
    /// </summary>
    private const string ORDER_DATE_COLUMN = "OrderDate";
    /// <summary>
    /// ステータス
    /// </summary>
    private const string STATE_COLUMN = "State";
       
    /// <summary>
    /// コンテンツ
    /// </summary>
    [SerializeField] private GameObject Content = default;
    /// <summary>
    /// 注文アイテム
    /// </summary>
    [SerializeField] private GameObject OrderItem = default;
    /// <summary>
    /// 注文詳細
    /// </summary>
    [SerializeField] private OrderDetails OrderDetails = default;

    /// <summary>
    /// リセットイベント
    /// </summary>
    private void Reset()
    {
        Content = transform.Find("OrderScrollView").Find("Viewport").Find("Content").gameObject;
        OrderDetails = GameObject.Find("OrderDetails").GetComponent<OrderDetails>();
    }

    /// <summary>
    /// 表示
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="state"></param>
    public void Show(string storeId, int state = 0)
    {
        gameObject.SetActive(true);
        GetOrder(storeId, state);
    }

    /// <summary>
    /// 注文の一覧表示
    /// </summary>
    /// <param name="nameList"></param>
    /// <param name="dateList"></param>
    /// <param name="stateList"></param>
    /// <param name="orderIdList"></param>
    private void ShowOrderContent(List<string> nameList, List<string> dateList, List<int> stateList, List<string> orderIdList)
    {

        ClearContent();

        for (int i = 0; i < nameList.Count; i++)
        {
            GameObject item = Instantiate(OrderItem, Content.transform);
            OrderItem order = item.GetComponent<OrderItem>();
            order.Initialization(nameList[i], dateList[i], stateList[i], orderIdList[i]);
            order.AddCollback(SelectedOrderCallback);
        }

    }

    /// <summary>
    /// 注文一覧の削除
    /// </summary>
    private void ClearContent()
    {
        foreach (Transform child in Content.transform)
            Destroy(child.gameObject);
    }

    /// <summary>
    /// 注文一覧取得
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="state"></param>
    private void GetOrder(string storeId, int state = 0)
    {
        //NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>(ORDER_MASTER_TABLE);
        //query.WhereEqualTo(STOREID_COLUMN, storeId);

        //if (state == COMPLETION)
        //    query.WhereEqualTo(STATE_COLUMN, state);
        //else
        //    query.WhereNotEqualTo(STATE_COLUMN, COMPLETION);

        //query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        //{
        //    if (e == null)
        //    {

        //    }
        //    else
        //    {

        //    }
        //});

        List<string> nameList = new List<string>() { "相浦　誠", "天王洲　愛瑠", "武部　古杉" };
        List<string> dateList = new List<string>() { "2020/04/11", "2020/04/12", "2020/04/13" };
        List<int> stateList = new List<int>() { state, state, state };
        List<string> orderIdList = new List<string>() { "STR000001", "STR000002", "STR000003" };
        ShowOrderContent(nameList, dateList, stateList, orderIdList);
    }

    /// <summary>
    /// 注文を選択した際のコールバックイベント
    /// </summary>
    /// <param name="orderId"></param>
    private void SelectedOrderCallback(string orderId)
    {
        OrderDetails.Show(orderId);
        gameObject.SetActive(false);
    }
}
