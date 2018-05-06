using UnityEngine;

class Workbench :MonoBehaviour
{
    Manipulator mani;
    Player player;

    public GameObject character;

    bool iscomplete;

    private void Start()
    {
        mani = GetComponentInChildren<Manipulator>();
        iscomplete = false;
    }

    public void enter()
    {
        iscomplete = false;
        character.transform.position = Vector3.zero;

        character.GetComponent<Player>().removeAllAction();
        Destroy(character.GetComponent<Player>());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("q");
            iscomplete = true;
        }
    }

    public void quit()
    {
        character.AddComponent<Player>();
    }

    public GameObject getCharacter()
    {
        return character;
    }
    
    public bool isComplete()
    {
        return iscomplete;
    }
}
