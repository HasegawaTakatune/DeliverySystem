using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using NCMB;

/// <summary>
/// 注文詳細を表示
/// </summary>
public class OrderDetails : MonoBehaviour
{
    /// <summary>
    /// 詳細構造体
    /// </summary>
    private struct DETAIL
    {
        public string userName;
        public string userAddress;
        public string userTelephone;
        public string orderDate;
        public int state;
        public List<string> foodName;
        public List<int> foodPrice;
    }
    /// <summary>
    /// 詳細構造体
    /// </summary>
    DETAIL detail;

    /// <summary>
    /// 注文マスタ
    /// </summary>
    private const string ORDER_MASTER_TABLE = "OrderMaster";
    /// <summary>
    /// 注文ID
    /// </summary>
    private const string ORDER_ID_COLUMN = "OrderId";
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
    /// 食品名
    /// </summary>
    private const string FOOD_NAME_COLUMN = "FoodName";
    /// <summary>
    /// 食品値段
    /// </summary>
    private const string FOOD_PRICE_COLUMN = "FoodPrice";

    /// <summary>
    /// ユーザ名
    /// </summary>
    [SerializeField] private Text UserName = default;
    /// <summary>
    /// ユーザ住所
    /// </summary>
    [SerializeField] private Text UserAddress = default;
    /// <summary>
    /// ユーザ電話番号
    /// </summary>
    [SerializeField] private Text UserTelephone = default;
    /// <summary>
    /// 注文日付
    /// </summary>
    [SerializeField] private Text OrderDate = default;
    /// <summary>
    /// ステータス
    /// </summary>
    [SerializeField] private Dropdown State = default;

    /// <summary>
    /// コンテンツ
    /// </summary>
    [SerializeField] private GameObject Content = default;
    /// <summary>
    /// 食品プレファブ
    /// </summary>
    [SerializeField] private GameObject FoodItem2 = default;

    /// <summary>
    /// 注文オブジェクト
    /// </summary>
    [SerializeField] private GameObject Order = default;

    /// <summary>
    /// リセットイベント
    /// </summary>
    private void Reset()
    {
        UserName = transform.Find("UserName").GetComponent<Text>();
        UserAddress = transform.Find("UserAddress").GetComponent<Text>();
        UserTelephone = transform.Find("UserTelephone").GetComponent<Text>();
        OrderDate = transform.Find("OrderDate").GetComponent<Text>();
        State = transform.Find("State").GetComponent<Dropdown>();
        Content = transform.Find("Foods").transform.Find("Viewport").Find("Content").gameObject;
        Order = GameObject.Find("Order");
    }

    /// <summary>
    /// 注文詳細の表示
    /// </summary>
    /// <param name="orderId"></param>
    public void Show(string orderId)
    {
        UserName.text = "";
        UserAddress.text = "";
        UserTelephone.text = "";
        OrderDate.text = "";
        State.value = 0;

        foreach (Transform child in Content.transform)
            Destroy(child.gameObject);

        gameObject.SetActive(true);

        GetOrderDetails(orderId);
    }

    /// <summary>
    /// 注文情報取得
    /// </summary>
    /// <param name="orderId"></param>
    private void GetOrderDetails(string orderId)
    {
        //NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>(ORDER_MASTER_TABLE);
        //query.WhereEqualTo(ORDER_ID_COLUMN, orderId);
        //query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        //{
        //    if (e == null)
        //    {
        //        UserName.text = objList[0][USER_NAME_COLUMN].ToString();
        //        UserAddress.text = objList[0][USER_ADDRESS_COLUMN].ToString();
        //        UserTelephone.text = objList[0][USER_TELEPHONR_COLUMN].ToString();
        //        OrderDate.text = objList[0][ORDER_DATE_COLUMN].ToString();
        //        State.value = System.Convert.ToInt32(objList[0][STATE_COLUMN]);

        //        for (int i = 0; i < objList.Count; i++)
        //        {
        //            Food food = Instantiate(Food, Content.transform).GetComponent<Food>();
        //            food.Initialization(objList[i][FOOD_NAME_COLUMN].ToString(), System.Convert.ToInt32(objList[i][FOOD_PRICE_COLUMN]));
        //        }
        //    }
        //});



        switch (orderId)
        {
            case "00000001":
                break;

            case "00000002":
                break;

            case "00000003":
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// 注文詳細表示
    /// </summary>
    /// <param name="detail"></param>
    private void ShowOrderDetails(DETAIL detail)
    {
        UserName.text = detail.userName;
        UserAddress.text = detail.userAddress;
        UserTelephone.text = detail.userTelephone;
        OrderDate.text = detail.orderDate;
        State.value = detail.state;

        for (int i = 0; i < detail.foodName.Count; i++)
        {
            GameObject item = Instantiate(FoodItem2, Content.transform);
            FoodItem2 food = item.GetComponent<FoodItem2>();
            food.Initialization(detail.foodName[i], detail.foodPrice[i]);
        }
    }

    /// <summary>
    /// 戻るボタンイベント
    /// </summary>
    public void OnClickReturn()
    {
        Order.SetActive(true);
        gameObject.SetActive(false);
    }

}
