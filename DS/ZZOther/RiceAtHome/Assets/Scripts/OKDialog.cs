using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// OKダイアログ
/// </summary>
public class OKDialog : MonoBehaviour
{
    /// <summary>
    /// メッセージ
    /// </summary>
    [SerializeField] private Text Message = default;

    /// <summary>
    /// リセットイベント
    /// </summary>
    private void Reset()
    {
        Message = transform.Find("Message").GetComponent<Text>();
    }

    /// <summary>
    /// ダイアログ表示
    /// </summary>
    /// <param name="msg"></param>
    public void ShowDialog(string msg = "")
    {
        Message.text = msg;
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
