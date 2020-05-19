using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;
using System;

public class UserInfo : MonoBehaviour
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
    /// 食品ID
    /// </summary>
    private const string FOODID_COLUMN = "FoodId";
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
    private const string USER_TELEPHONE_COLUMN = "UserTelephone";
    /// <summary>
    /// 注文日付
    /// </summary>
    private const string ORDER_DATE_COLUMN = "OrderDate";

    /// <summary>
    /// 入力フィールド
    /// </summary>
    [SerializeField] private List<InputField> inputFields = new List<InputField>();
    /// <summary>
    /// 注文ボタン
    /// </summary>
    [SerializeField] private Button orderButton = default;

    /// <summary>
    /// OKダイアログ
    /// </summary>
    [SerializeField] private GameObject OKDialog = default;

    /// <summary>
    /// 店ID
    /// </summary>
    private string storeId;
    /// <summary>
    /// 食品リスト
    /// </summary>
    private List<string> foodList = new List<string>();


    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="foodList"></param>
    public void InitUserInfo(string storeId, List<string> foodList)
    {
        this.storeId = storeId;
        this.foodList = foodList;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// クリックイベント
    /// </summary>
    public void OnClickOrderButton()
    {
        SetOeder();
    }

    /// <summary>
    /// 注文保存
    /// </summary>
    private void SetOeder()
    {
        NCMBObject obj = new NCMBObject(ORDER_MASTER_TABLE);
        obj.Add(STOREID_COLUMN, storeId);
        obj.Add(FOODID_COLUMN, foodList[0]);
        obj.Add(USER_NAME_COLUMN, inputFields[0].text);
        obj.Add(USER_ADDRESS_COLUMN, inputFields[1].text);
        obj.Add(USER_TELEPHONE_COLUMN, inputFields[2].text);
        obj.Add(ORDER_DATE_COLUMN, DateTime.Now);

        obj.SaveAsync((NCMBException e) =>
        {
            if (e == null)
            {
                OKDialog.GetComponent<OKDialog>().ShowDialog("");
                //OKDialog.SetActive(true);
            }
            else
            {

            }
        });
    }

    /// <summary>
    /// 入力項目変更イベント
    /// </summary>
    /// <param name="value"></param>
    public void OnValueChanged(string value)
    {
        bool isAllInput = true;

        if (string.IsNullOrWhiteSpace(value))
        {
            isAllInput = false;
        }
        else
        {
            for (int i = 0; i < inputFields.Count; i++)
                if (inputFields[i].isFocused == false && string.IsNullOrWhiteSpace(inputFields[i].text))
                    isAllInput = false;
        }

        if (isAllInput)
            orderButton.interactable = false;
        else
            orderButton.interactable = true;
    }

}
