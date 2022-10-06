using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;//DllImportに必要
using UnityEngine.UI;

public class Example : MonoBehaviour
{

    [SerializeField] Button _buttonHelloWorld = default;
    [SerializeField] Text text;

    [DllImport("__Internal", EntryPoint = "printHelloWorld")]
    static extern Int32 PrintHelloWorld();

    // Start is called before the first frame update
    void Start()
    {
        _buttonHelloWorld.onClick.AddListener(() =>
        {
#if !UNITY_EDITOR && UNITY_IOS
                // プラグインの呼び出し
                var ret = PrintHelloWorld();
                Debug.Log($"戻り値: {ret}");
                text.text=$"戻り値: {ret}";
#else
            // それ以外のプラットフォームからの呼び出し (Editor含む)
            Debug.Log("Hello World (iOS以外からの呼び出し)");
            text.text = "Hello World (iOS以外からの呼び出し)";
#endif
        });
    }


}
