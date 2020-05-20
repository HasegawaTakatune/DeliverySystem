using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

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
    /// 配達完了
    /// </summary>
    private const int COMPLETION = 2;

    [SerializeField] private GameObject Content = default;
    [SerializeField] private GameObject OrderItem = default;

    private void ShowOrderContent()
    {

    }

    private void GetOrder(string storeId, int state = 0)
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>(ORDER_MASTER_TABLE);
        query.WhereEqualTo(STOREID_COLUMN, storeId);

        if (state == COMPLETION)
            query.WhereEqualTo(STATE_COLUMN, state);
        else
            query.WhereNotEqualTo(STATE_COLUMN, COMPLETION);

        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e == null)
            {

            }
            else
            {

            }
        });
    }

}
