using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class OrderDetails : MonoBehaviour
{
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
    [SerializeField] private GameObject Food = default;

    /// <summary>
    /// オーダーオブジェクト
    /// </summary>
    [SerializeField] private GameObject Order = default;

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="orderId"></param>
    public void Initialization(string orderId)
    {
        UserName.text = "";
        UserAddress.text = "";
        UserTelephone.text = "";
        OrderDate.text = "";
        State.value = 0;

        foreach (Transform child in gameObject.transform)
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
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>(ORDER_MASTER_TABLE);
        query.WhereEqualTo(ORDER_ID_COLUMN, orderId);
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e == null)
            {
                UserName.text = objList[0][USER_NAME_COLUMN].ToString();
                UserAddress.text = objList[0][USER_ADDRESS_COLUMN].ToString();
                UserTelephone.text = objList[0][USER_TELEPHONR_COLUMN].ToString();
                OrderDate.text = objList[0][ORDER_DATE_COLUMN].ToString();
                State.value = System.Convert.ToInt32(objList[0][STATE_COLUMN]);

                for (int i = 0; i < objList.Count; i++)
                {
                    Food food = Instantiate(Food, Content.transform).GetComponent<Food>();
                    food.Initialization(objList[i][FOOD_NAME_COLUMN].ToString(), System.Convert.ToInt32(objList[i][FOOD_PRICE_COLUMN]));
                }
            }
        });
    }

    public void OnClickReturn()
    {
        Order.SetActive(true);
        gameObject.SetActive(false);
    }

}
