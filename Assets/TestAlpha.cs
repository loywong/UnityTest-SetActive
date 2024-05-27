using UnityEngine;
using UnityEngine.UI;

public class TestAlpha : MonoBehaviour {
    [SerializeField] CanvasGroup ui;
    [SerializeField] Button btn;

    bool isShow;
    System.Diagnostics.Stopwatch sw;
    void Start () {
        btn.onClick.AddListener (ToggleVisibility);

        isShow = true;
        ui.alpha = 1;

        sw = new System.Diagnostics.Stopwatch ();
    }

    void ToggleVisibility () {
        isShow = !isShow;

        sw.Reset ();
        sw.Start ();
        for (int i = 0; i < 10000000; i++) {
            ui.alpha = isShow?1 : 0;
            ui.blocksRaycasts = isShow;
        }
        sw.Stop ();
        Debug.Log ($"for循环使用时间 {sw.ElapsedMilliseconds} ms");
    }
}