using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class ItemSettings : MonoBehaviour
{
    /// <summary>
    /// 店マスタ
    /// </summary>
    private const string STORE_MASTER_TABLE = "StoreMaster";
    /// <summary>
    /// 食品マスタ
    /// </summary>
    private const string FOOD_MASTER_TABLE = "FoodMaster";

    /// <summary>
    /// 名前
    /// </summary>
    private const string NAME_COLUMN = "Name";
    /// <summary>
    /// ID
    /// </summary>
    private const string ID_COLUMN = "Id";
    /// <summary>
    /// アイコン
    /// </summary>
    private const string ICON_NAME_COLUMN = "IconName";

    /// <summary>
    /// 値段
    /// </summary>
    private const string PRICE_COLUMN = "Price";
    /// <summary>
    /// 店ID
    /// </summary>
    private const string STORE_ID_COLUMN = "StoreId";

    /// <summary>
    /// 店スクロールビュー
    /// </summary>
    [SerializeField] private GameObject StoreScrollView = default;
    /// <summary>
    /// 店コンテンツ
    /// </summary>
    [SerializeField] private GameObject StoreContent = default;
    /// <summary>
    /// 店プレファブ
    /// </summary>
    [SerializeField] private GameObject StorePrefab = default;

    /// <summary>
    /// 食品スクロールビュー
    /// </summary>
    [SerializeField] private GameObject FoodScrollView = default;
    /// <summary>
    /// 食品コンテンツ
    /// </summary>
    [SerializeField] private GameObject FoodContent = default;
    /// <summary>
    /// 食品プレファブ
    /// </summary>
    [SerializeField] private GameObject FoodPrefab = default;

    /// <summary>
    /// ユーザ情報
    /// </summary>
    [SerializeField] private GameObject UserInfo = default;

    /// <summary>
    /// 店ID
    /// </summary>
    private string storeId;

    /// <summary>
    /// 食品リスト
    /// </summary>
    private List<string> foodList = new List<string>();


    /// <summary>
    /// 店の選択ボタンを追加していく
    /// </summary>
    /// <param name="nameList"></param>
    /// <param name="idList"></param>
    /// <param name="iconNameList"></param>
    private void ShowStoreItems(List<string> nameList, List<string> idList, List<string> iconNameList)
    {
        ClearStoreContent();

        StoreScrollView.SetActive(true);
        FoodScrollView.SetActive(false);

        List<StoreItem> storeList = new List<StoreItem>();
        for (int i = 0; i < nameList.Count; i++)
        {
            GameObject item = Instantiate(StorePrefab, StoreContent.transform);
            StoreItem store = item.GetComponent<StoreItem>();
            store.InitStoreButton(nameList[i], idList[i]);
            store.AddCallback(SelectedStoreCallback);
            storeList.Add(store);

            //GetStoreIcon(iconNameList[i], store);
        }
    }

    /// <summary>
    /// 食品ボタンを追加していく
    /// </summary>
    /// <param name="nameList"></param>
    /// <param name="priceList"></param>
    /// <param name="idList"></param>
    /// <param name="iconNameList"></param>
    public void ShowFoodItems(List<string> nameList, List<int> priceList, List<string> idList, List<string> iconNameList)
    {
        ClearFoodContent();

        FoodScrollView.SetActive(true);
        StoreScrollView.SetActive(false);

        List<FoodItem> foodList = new List<FoodItem>();
        for (int i = 0; i < nameList.Count; i++)
        {
            GameObject item = Instantiate(FoodPrefab, FoodContent.transform);
            FoodItem food = item.GetComponent<FoodItem>();
            food.InitFoodButton(nameList[i], idList[i], priceList[i]);
            food.AddCallback(SelectedFoodCallback);
            foodList.Add(food);

            //GetFoodIcon(iconNameList[i], food);
        }
    }

    /// <summary>
    /// 店情報を追加する
    /// </summary>
    private void GetStore()
    {
        //NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>(STORE_MASTER_TABLE);
        //query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        //{
        //    if (e == null)
        //    {
        //        List<string> nameList = new List<string>();
        //        List<string> idList = new List<string>();
        //        List<string> iconNameList = new List<string>();

        //        for (int i = 0; i < objList.Count; i++)
        //        {
        //            string name = objList[i][NAME_COLUMN].ToString();
        //            string id = objList[i][ID_COLUMN].ToString();
        //            string iconName = objList[i][ICON_NAME_COLUMN].ToString();

        //            nameList.Add(name);
        //            idList.Add(id);
        //            iconNameList.Add(iconName);
        //        }
        //        ShowStoreItems(nameList, idList, iconNameList);
        //    }
        //    else
        //    {
        //        // NCMBException
        //    }

        //});

        List<string> nameList = new List<string>() { "軍鶏貴族", "竹屋", "トスバーガー" };
        List<string> idList = new List<string>() { "STR000001", "STR000002", "STR000003" };
        List<string> iconNameList = new List<string>();
        ShowStoreItems(nameList, idList, iconNameList);
    }

    /// <summary>
    /// 店のアイコンを取得する
    /// </summary>
    /// <param name="iconName"></param>
    /// <param name="store"></param>
    private void GetStoreIcon(string iconName, StoreItem store)
    {
        NCMBFile file = new NCMBFile(iconName);
        file.FetchAsync((byte[] fileData, NCMBException e) =>
        {
            if (e == null)
            {
                Sprite sprite = CreateSpriteFromBytes(fileData);
                store.SetIcon(sprite);
            }
            else
            {
                // NCMBException
            }
        });
    }

    /// <summary>
    /// 店のアイテムを削除する。
    /// </summary>
    private void ClearStoreContent()
    {
        foreach (Transform child in StoreContent.transform)
            Destroy(child.gameObject);
    }

    /// <summary>
    /// 食品情報を追加する
    /// </summary>
    /// <param name="storeId"></param>
    private void GetFood(string storeId)
    {
        //NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>(FOOD_MASTER_TABLE);
        //query.WhereEqualTo(STORE_ID_COLUMN, storeId);
        //query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        //{
        //    if (e == null)
        //    {
        //        List<string> nameList = new List<string>();
        //        List<int> priceList = new List<int>();
        //        List<string> foodIdList = new List<string>();
        //        List<string> iconNameList = new List<string>();

        //        for (int i = 0; i < objList.Count; i++)
        //        {
        //            string name = objList[i][NAME_COLUMN].ToString();
        //            int price = System.Convert.ToInt32(objList[i][PRICE_COLUMN]);
        //            string foodId = objList[i][ID_COLUMN].ToString();
        //            string iconName = objList[i][ICON_NAME_COLUMN].ToString();

        //            nameList.Add(name);
        //            priceList.Add(price);
        //            foodIdList.Add(foodId);
        //            iconNameList.Add(iconName);
        //        }

        //        ShowFoodItems(nameList, priceList, foodIdList, iconNameList);
        //    }
        //});

        List<string> nameList = new List<string>() { "唐揚げ", "軟骨唐揚げ", "ポテトフライ", "牛丼", "豚丼", "ネギトロ丼", "ハンバーガー", "てりやきバーガー", "エッグバーガー" };
        List<int> priceList = new List<int>() { 250, 300, 200, 500, 450, 600, 400, 600, 600 };
        List<string> foodIdList = new List<string>() { "FOD100001", "FOD100002", "FOD100003", "FOD200001", "FOD200002", "FOD200003", "FOD300001", "FOD300002", "FOD300003" };
        List<string> iconNameList = new List<string>();
        ShowFoodItems(nameList, priceList, foodIdList, iconNameList);
    }

    /// <summary>
    /// 食品のアイコンを取得する
    /// </summary>
    /// <param name="iconName"></param>
    /// <param name="store"></param>
    private void GetFoodIcon(string iconName, FoodItem food)
    {
        NCMBFile file = new NCMBFile(iconName);
        file.FetchAsync((byte[] fileData, NCMBException e) =>
        {
            if (e == null)
            {
                Sprite sprite = CreateSpriteFromBytes(fileData);
                food.SetIcon(sprite);
            }
            else
            {
                // NCMBException
            }
        });
    }

    /// <summary>
    /// 食品のアイテムを削除する
    /// </summary>
    private void ClearFoodContent()
    {
        foreach (Transform child in gameObject.transform)
            Destroy(child.gameObject);
    }

    /// <summary>
    /// バイナリ―データからスプライトに変換する
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    private Sprite CreateSpriteFromBytes(byte[] bytes)
    {
        //横サイズの判定
        int pos = 16;
        int width = 0;
        for (int i = 0; i < 4; i++)
        {
            width = width * 256 + bytes[pos++];
        }
        //縦サイズの判定
        int height = 0;
        for (int i = 0; i < 4; i++)
        {
            height = height * 256 + bytes[pos++];
        }

        //byteからTexture2D作成
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(bytes);

        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    /// <summary>
    /// 店を選択した際のコールバックイベント
    /// </summary>
    /// <param name="id"></param>
    public void SelectedStoreCallback(string id)
    {
        storeId = id;
        GetFood(id);
    }

    /// <summary>
    /// 食品を選択した際のコールバックイベント
    /// </summary>
    /// <param name="id"></param>
    private void SelectedFoodCallback(string id)
    {
        foodList.Add(id);
        UserInfo.SetActive(true);
        UserInfo.GetComponent<UserInfo>().InitUserInfo(storeId, foodList);
    }
}
