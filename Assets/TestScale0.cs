using UnityEngine;
using UnityEngine.UI;

public class TestAlpha0 : MonoBehaviour {
    [SerializeField] Transform ui;
    [SerializeField] Button btn;

    bool isShow;
    System.Diagnostics.Stopwatch sw;
    void Start () {
        btn.onClick.AddListener (ToggleVisibility);

        isShow = true;
        ui.localScale = Vector3.one;

        sw = new System.Diagnostics.Stopwatch ();
    }

    void ToggleVisibility () {
        isShow = !isShow;

        sw.Reset (); //重置
        sw.Start ();
        for (int i = 0; i < 10000000; i++) {
            ui.localScale = isShow?Vector3.one : Vector3.zero;
        }
        sw.Stop ();
        Debug.Log (string.Format ("for循环使用时间 {0} ms", sw.ElapsedMilliseconds));
    }
}