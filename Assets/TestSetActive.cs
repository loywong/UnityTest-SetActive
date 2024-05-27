using UnityEngine;
using UnityEngine.UI;

public class TestSetActive : MonoBehaviour {
    [SerializeField] GameObject ui;
    [SerializeField] Button btn;

    bool isShow;
    System.Diagnostics.Stopwatch sw;
    void Start () {
        btn.onClick.AddListener (ToggleVisibility);

        isShow = true;
        ui.SetActive (true);

        sw = new System.Diagnostics.Stopwatch ();
    }

    void ToggleVisibility () {
        isShow = !isShow;

        sw.Reset (); //重置
        sw.Start ();
        for (int i = 0; i < 10000000; i++) {
            ui.SetActive (isShow);
        }
        sw.Stop ();
        Debug.Log (string.Format ("for循环使用时间 {0} ms", sw.ElapsedMilliseconds));
    }
}