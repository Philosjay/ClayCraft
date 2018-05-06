using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    GameObject player;
    GameObject sceneBox;
    PlayerController playerController;
    Rigidbody playerRigidbody;
    Animator playerAnimator;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sceneBox = GameObject.FindGameObjectWithTag("SceneBox");
        playerController = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>();
        playerRigidbody = player.GetComponent<Rigidbody>();
        playerAnimator = player.GetComponent<Animator>();
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

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Work", LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName("Work"));
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
        Debug.Log("unload");
        #endregion

        playerController.ControlUnable();
        
        player.transform.position = new Vector3(-5, 3, 0);
        player.transform.rotation = Quaternion.Euler(-40, -90, 0);
        playerRigidbody.useGravity = false;
        playerAnimator.enabled = false;
        playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;


    }

}
