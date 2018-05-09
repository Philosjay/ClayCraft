using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;


public class SceneController : MonoBehaviour
{

    GameObject player;
    GameObject sceneBox;
    GameObject mainCamera;
    GameController gameController;
    PlayerController playerController;
    Rigidbody playerRigidbody;
    Animator playerAnimator;
    CinemachineBrain cinemachineBrain;



    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sceneBox = GameObject.FindGameObjectWithTag("SceneBox");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        playerController = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>();
        playerRigidbody = player.GetComponent<Rigidbody>();
        playerAnimator = player.GetComponent<Animator>();
        cinemachineBrain = mainCamera.GetComponent<CinemachineBrain>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ChangeSceneToWork());
    }

    public IEnumerator WaitAndBeSceneBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        sceneBox.AddComponent<SceneController>();
    }

    IEnumerator ChangeSceneToWork()
    {
        #region SceneChange
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        DontDestroyOnLoad(mainCamera);
        DontDestroyOnLoad(player);

        #region playerSettings
        playerController.ControlUnable();

        player.transform.position = new Vector3(-5.5f, 3.5f, 0);
        player.transform.rotation = Quaternion.Euler(-40, -90, 0);
        playerRigidbody.useGravity = false;
        playerAnimator.enabled = false;
        playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        #endregion

        #region sceneSettings
        gameController.currentPlot = 4;
        cinemachineBrain.enabled = false;
        mainCamera.transform.position = new Vector3(-8, 7, 0);
        mainCamera.transform.rotation = Quaternion.Euler(40, 90, 0);
        #endregion

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Work", LoadSceneMode.Single);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(mainCamera, SceneManager.GetSceneByName("Work"));
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName("Work"));

        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
        Debug.Log("unload");
        #endregion
    }

    public IEnumerator ChangeSceneToPlot()
    {
        #region SceneChange
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        DontDestroyOnLoad(mainCamera);
        DontDestroyOnLoad(player);

        #region sceneSettings

        gameController.currentPlot = 4;

        cinemachineBrain.enabled = true;
        //mainCamera.transform.position = new Vector3(-8, 7, 0);
        //mainCamera.transform.rotation = Quaternion.Euler(40, 90, 0);
        #endregion

        #region playerSettings

        playerController.ControlEnable();

        player.transform.position = new Vector3(5f, 2, 3);
        //player.transform.rotation = Quaternion.Euler(-40, -90, 0);
        playerRigidbody.useGravity = true;
        playerAnimator.enabled = true;
        playerRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        #endregion

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Plot1", LoadSceneMode.Additive);

        Debug.Log(asyncLoad.isDone);
        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(mainCamera, SceneManager.GetSceneByName("Plot1"));
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName("Plot1"));

        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
        Debug.Log("unload");
        #endregion



    }




}
