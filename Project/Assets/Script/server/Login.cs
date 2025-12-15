using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Login : MonoBehaviour
{
    [SerializeField] private string loginEndPoint = "http://127.0.0.1:13756/account/login";
    [SerializeField] private string createEndPoint = "http://127.0.0.1:13756/account/create";
    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private Button loginButon;
    [SerializeField] private Button createButon;
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    public CanvasGroup mainGroup;
    public CanvasGroup loginGroup;


    public void OnLoginClick()
    {
        alertText.text = "Signing in...";
        ActivateButtons(false);

        StartCoroutine(TryLogin());
    }

    public void OnCreateClick()
    {
        alertText.text = "Creating account...";
        ActivateButtons(false);

        StartCoroutine(TryCreate());
    }


    private IEnumerator TryLogin()
    {
        string username = usernameInputField.text;
        string password = passwordInputField.text;
        string playerPos = SaveNLoad.saveData.playerPos.ToString();
        string playerRot = SaveNLoad.saveData.playerRot.ToString();


        //string playerPos = GameManager.instance.playerPos.ToString();
        // string playerRot = GameManager.instance.playerRot.ToString();

        if (username.Length < 3 || username.Length > 24)
        {
            alertText.text = "Invalid Username";
            ActivateButtons(true);
            yield break;
        }

        if (password.Length < 3 || password.Length > 24)
        {
            alertText.text = "Invalid Password";
            ActivateButtons(true);
            yield break;
        }

        WWWForm form = new WWWForm();
        form.AddField("rUsername", username);
        form.AddField("rPassword", password);
        form.AddField("rPlayerPos", playerPos);
        form.AddField("rPlayerRot", playerRot);


        UnityWebRequest request = UnityWebRequest.Post(loginEndPoint, form);
        var handler = request.SendWebRequest();

        float startTime = 0.0f;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;

            if (startTime > 10.0f)
            {
                break;
            }
            yield return null;
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(request.downloadHandler.text);
            LoginResponse response = JsonUtility.FromJson<LoginResponse>(request.downloadHandler.text);
            if (response.code == 0)//login success?
            {
                ActivateButtons(false);
                alertText.text = "Welcome " + ((response.data.adminFlag == 1) ? " Admin" : "");
                
                Debug.Log(JsonUtility.ToJson(SaveNLoad.saveData));
                Debug.Log(SaveNLoad.saveData.SceneName);
                
                //Debug.Log(SaveNLoad.saveData.SceneName);
                loginGroup.gameObject.SetActive(false);
                CanvasGroupOff(loginGroup);
                CanvasGroupOn(mainGroup);

            }
            else
            {
                switch (response.code)
                {
                    case 1:
                        alertText.text = "Invalid credentials";
                        ActivateButtons(true);
                        break;
                    default:
                        alertText.text = "Corruption detected";
                        ActivateButtons(false);
                        break;

                }
            }
        }
        else 
        {
            alertText.text = "Error connecting to the server...";
            ActivateButtons(true);
        }

        yield return null;
    }

    private IEnumerator TryCreate()
    {
        string username = usernameInputField.text;
        string password = passwordInputField.text;
        //string playerPos = SaveNLoad.saveData.playerPos.ToString();
        //string playerRot = SaveNLoad.saveData.playerRot.ToString();

        if (username.Length < 3 || username.Length > 24)
        {
            alertText.text = "Invalid Username";
            ActivateButtons(true);
            yield break;
        }

        if (password.Length < 3 || password.Length > 24)
        {
            alertText.text = "Invalid Password";
            ActivateButtons(true);
            yield break;
        }

        WWWForm form = new WWWForm();
        form.AddField("rUsername", username);
        form.AddField("rPassword", password);
        //form.AddField("rPlayerPos", playerPos);
        //form.AddField("rPlayerRot", playerRot);

        UnityWebRequest request = UnityWebRequest.Post(createEndPoint, form);
        var handler = request.SendWebRequest();

        float startTime = 0.0f;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;

            if (startTime > 10.0f)
            {
                break;
            }
            yield return null;
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(request.downloadHandler.text);
            CreateResponse response = JsonUtility.FromJson<CreateResponse>(request.downloadHandler.text);

            if (response.code == 0)
            {
                alertText.text = "Account has been created";
                ActivateButtons(true);
            }
            else
            {
                switch (response.code)
                {
                    case 1:
                        alertText.text = "Invalid credentials";
                        break;
                    case 2:
                        alertText.text = "Username is already taken";
                        break;
                    default:
                        alertText.text = "Corruption detected";
                        break;
                }
                ActivateButtons(true);
            }
        }
        else
        {
            alertText.text = "Error connecting to the server...";
        }
        ActivateButtons(true);

        yield return null;
    }

    private void ActivateButtons(bool toggle)
    {
        loginButon.interactable = toggle;
        createButon.interactable = toggle;
    }
    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.gameObject.SetActive(true);
        cg.alpha = 1;
        cg.interactable = true;
        Debug.Log(cg.interactable);
        cg.blocksRaycasts = true;
    }
    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        Debug.Log(cg.interactable);
        cg.blocksRaycasts = false;
    }
}
