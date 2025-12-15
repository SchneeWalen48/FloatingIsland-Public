using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem; // Put at top of script to access Dialogue System stuff. ... 

// 2021.07.17 created by HY
// Needs : Trigger, LuaCode(isTrue) 
// 씬 넘어가는 코드
public class SceneChange : MonoBehaviour
{
    public string nextSceneName;
    public static SceneChange instance;
    private SaveNLoad theSaveNLoad;
    private Inventory theInven;
    private SaveData saveData = new SaveData();

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && DialogueLua.GetVariable("isTrue").asBool)
        {
            GameObject.Find("PauseMenu").GetComponent<EscapeMenu>().ClickSave();
            //StartCoroutine(LoadCoroutine());
            SceneManager.LoadScene(nextSceneName);
        }
    }

    /*IEnumerator LoadCoroutine()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneName);
        while (operation.isDone)
        {
            yield return null;
        }
        Destroy(gameObject);
    }*/
}
