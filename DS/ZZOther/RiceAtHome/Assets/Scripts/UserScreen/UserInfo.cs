using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using NCMB;
using System;

/// <summary>
/// ユーザ情報
/// </summary>
public class UserInfo : MonoBehaviour
{
    /// <summary>
    /// コールバックイベント
    /// </summary>
    public delegate void CALLBACK();
    /// <summary>
    /// コールバックイベント
    /// </summary>
    private CALLBACK callback;

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
    /// ステータス
    /// </summary>
    private const string STATE_COLUMN = "State";

    /// <summary>
    /// 入力フィールド
    /// </summary>
    [SerializeField] private InputField[] InputFields = new InputField[] { };
    /// <summary>
    /// 注文ボタン
    /// </summary>
    [SerializeField] private Button OrderButton = default;

    /// <summary>
    /// OKダイアログ
    /// </summary>
    [SerializeField] private OKDialog OKDialog = default;

    /// <summary>
    /// 店ID
    /// </summary>
    private string storeId;
    /// <summary>
    /// 食品リスト
    /// </summary>
    private List<string> foodList = new List<string>();

    /// <summary>
    /// リセットイベント
    /// </summary>
    private void Reset()
    {
        InputFields = gameObject.GetComponentsInChildren<InputField>();
        OrderButton = transform.Find("OrderButton").GetComponent<Button>();
        OKDialog = GameObject.Find("OKDialog").GetComponent<OKDialog>();
    }

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
        OrderButton.interactable = false;
        OnValueChanged();
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
        //NCMBObject obj = new NCMBObject(ORDER_MASTER_TABLE);
        //obj.Add(STOREID_COLUMN, storeId);
        //obj.Add(FOODID_COLUMN, foodList[0]);
        //obj.Add(USER_NAME_COLUMN, inputFields[0].text);
        //obj.Add(USER_ADDRESS_COLUMN, inputFields[1].text);
        //obj.Add(USER_TELEPHONE_COLUMN, inputFields[2].text);
        //obj.Add(ORDER_DATE_COLUMN, DateTime.Now);
        //obj.Add(STATE_COLUMN, 0);

        //obj.SaveAsync((NCMBException e) =>
        //{
        //    if (e == null)
        //    {
        //        OKDialog.GetComponent<OKDialog>().ShowDialog("注文が完了しました。");
        //        //OKDialog.SetActive(true);
        //    }
        //    else
        //    {

        //    }
        //});

        OKDialog.AddCallback(OnClickOKCallback);
        OKDialog.ShowDialog("登録が完了しました。");
    }

    /// <summary>
    /// 入力項目変更イベント
    /// </summary>
    public void OnValueChanged()
    {
        bool isInteractable = true;

        for (int i = 0; i < InputFields.Length; i++)
            if (string.IsNullOrWhiteSpace(InputFields[i].text))
                isInteractable = false;

        OrderButton.interactable = isInteractable;
    }

    /// <summary>
    /// コールバックイベントの追加
    /// </summary>
    /// <param name="callback"></param>
    public void AddCollback(CALLBACK callback)
    {
        this.callback += callback;
    }

    /// <summary>
    /// OKボタンを押した際のコールバックイベント
    /// </summary>
    private void OnClickOKCallback()
    {
        callback?.Invoke();
        gameObject.SetActive(false);
        OKDialog.RemoveCallback(OnClickOKCallback);
    }
}
