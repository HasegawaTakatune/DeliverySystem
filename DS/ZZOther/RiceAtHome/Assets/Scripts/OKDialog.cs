using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// OKダイアログ
/// </summary>
public class OKDialog : MonoBehaviour
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
        callback?.Invoke();
        
        gameObject.SetActive(false);
    }

    /// <summary>
    /// OKボタンクリック時のコールバックイベント追加
    /// </summary>
    /// <param name="callback"></param>
    public void AddCallback(CALLBACK callback)
    {
        this.callback += callback;
    }

    /// <summary>
    /// OKボタンクリック時のコールバックイベント解除
    /// </summary>
    /// <param name="callback"></param>
    public void RemoveCallback(CALLBACK callback)
    {
        this.callback -= callback;
    }
}
