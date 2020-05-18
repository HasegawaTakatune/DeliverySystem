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
    /// 店コンテンツ
    /// </summary>
    [SerializeField] private GameObject StoreContent;
    /// <summary>
    /// 店プレファブ
    /// </summary>
    [SerializeField] private GameObject StorePrefab;

    /// <summary>
    /// 食品コンテンツ
    /// </summary>
    [SerializeField] private GameObject FoodContent;
    /// <summary>
    /// 食品プレファブ
    /// </summary>
    [SerializeField] private GameObject FoodPrefab;


    /// <summary>
    /// 店の選択ボタンを追加していく
    /// </summary>
    /// <param name="nameList"></param>
    /// <param name="idList"></param>
    /// <param name="iconNameList"></param>
    private void ShowStoreItems(List<string> nameList, List<string> idList, List<string> iconNameList)
    {
        List<StoreItem> storeList = new List<StoreItem>();
        for (int i = 0; i < nameList.Count; i++)
        {
            GameObject item = Instantiate(StorePrefab, StoreContent.transform);
            StoreItem store = item.GetComponent<StoreItem>();
            store.InitStoreButton(nameList[i], idList[i]);
            store.AddCallback(SelectedStoreCallback);
            storeList.Add(store);

            GetStoreIcon(iconNameList[i], store);
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
        List<FoodItem> foodList = new List<FoodItem>();
        for (int i = 0; i < nameList.Count; i++)
        {
            GameObject item = Instantiate(FoodPrefab, FoodContent.transform);
            FoodItem food = item.GetComponent<FoodItem>();
            food.InitFoodButton(nameList[i], idList[i], priceList[i]);
            food.AddCallback(SelectedFoodCallback);
            foodList.Add(food);

            GetFoodIcon(iconNameList[i], food);
        }
    }

    /// <summary>
    /// 店情報を追加する
    /// </summary>
    private void GetStore()
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>(STORE_MASTER_TABLE);
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e == null)
            {
                List<string> nameList = new List<string>();
                List<string> idList = new List<string>();
                List<string> iconNameList = new List<string>();

                for (int i = 0; i < objList.Count; i++)
                {
                    string name = objList[i][NAME_COLUMN].ToString();
                    string id = objList[i][ID_COLUMN].ToString();
                    string iconName = objList[i][ICON_NAME_COLUMN].ToString();

                    nameList.Add(name);
                    idList.Add(id);
                    iconNameList.Add(iconName);
                }
                ShowStoreItems(nameList, idList, iconNameList);
            }
            else
            {
                // NCMBException
            }

        });
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
    /// 食品情報を追加する
    /// </summary>
    /// <param name="storeId"></param>
    private void GetFood(string storeId)
    {
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>(FOOD_MASTER_TABLE);
        query.WhereEqualTo(STORE_ID_COLUMN, storeId);
        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e == null)
            {
                List<string> nameList = new List<string>();
                List<int> priceList = new List<int>();
                List<string> foodIdList = new List<string>();
                List<string> iconNameList = new List<string>();

                for (int i = 0; i < objList.Count; i++)
                {
                    string name = objList[i][NAME_COLUMN].ToString();
                    int price = System.Convert.ToInt32(objList[i][PRICE_COLUMN]);
                    string foodId = objList[i][ID_COLUMN].ToString();
                    string iconName = objList[i][ICON_NAME_COLUMN].ToString();

                    nameList.Add(name);
                    priceList.Add(price);
                    foodIdList.Add(foodId);
                    iconNameList.Add(iconName);
                }

                ShowFoodItems(nameList, priceList, foodIdList, iconNameList);
            }
        });

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
        GetFood(id);
    }

    /// <summary>
    /// 食品を選択した際のコールバックイベント
    /// </summary>
    /// <param name="id"></param>
    private void SelectedFoodCallback(string id)
    {

    }
}
