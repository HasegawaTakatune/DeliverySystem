using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OKDialog : MonoBehaviour
{
    /// <summary>
    /// メッセージ
    /// </summary>
    [SerializeField] private Text message = default;

    /// <summary>
    /// ダイアログ表示
    /// </summary>
    /// <param name="msg"></param>
    public void ShowDialog(string msg = "")
    {
        message.text = msg;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// OKボタンクリックイベント
    /// </summary>
    public void OnClickOKButton()
    {
        gameObject.SetActive(false);
    }
}
