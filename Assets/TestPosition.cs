using UnityEngine;
using UnityEngine.UI;
using Screen = UnityEngine.Screen;

public class TestPosition : MonoBehaviour {
    [SerializeField] RectTransform ui;
    [SerializeField] Button btn;

    bool isShow;
    System.Diagnostics.Stopwatch sw;
    float screenW;
    float screenH;
    float offsetX;
    float originX;
    Vector3 outsidePos = Vector3.zero;
    void Start () {
        screenW = Screen.width;
        originX = screenW / 2;
        screenH = Screen.height;
        offsetX = screenW + ui.rect.width / 2;
        Debug.Log ("screenW:" + screenW);
        Debug.Log ("ui.sizeDelta.x:" + ui.sizeDelta.x);
        Debug.Log ("ui.rect.width:" + ui.rect.width);
        btn.onClick.AddListener (ToggleVisibility);

        isShow = false;
        outsidePos.x = offsetX;
        outsidePos.y = screenH / 2;
        ui.position = outsidePos;

        sw = new System.Diagnostics.Stopwatch ();
    }

    void ToggleVisibility () {
        isShow = !isShow;

        sw.Reset (); //重置
        sw.Start ();
        for (int i = 0; i < 10000000; i++) {
            outsidePos.x = isShow?originX : offsetX;
            ui.position = outsidePos;
        }
        sw.Stop ();
        Debug.Log (string.Format ("for循环使用时间 {0} ms", sw.ElapsedMilliseconds));
    }
}