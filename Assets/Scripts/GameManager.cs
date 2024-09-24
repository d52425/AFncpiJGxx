using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Process exProcess;

    // Start is called before the first frame update
    void Start()
    {
        if (exProcess == null)
        {
            exProcess = new Process();
            exProcess.StartInfo.FileName = "C:\\Windows\\system32\\cmd.exe";

            //外部プロセスの終了を検知してイベントを発生させます.
            exProcess.EnableRaisingEvents = true;
            exProcess.Exited += exProcess_Exited;

            //外部のプロセスを実行する
            exProcess.Start();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    void exProcess_Exited(object sender, System.EventArgs e)
    {
        UnityEngine.Debug.Log("Event!");
        exProcess.Dispose();
        exProcess = null;
    }

    private void OnApplicationQuit()
    {
        if (exProcess.HasExited == false)
        {
            exProcess.CloseMainWindow();
            exProcess.Dispose();
            exProcess = null;
        }

    }
}
