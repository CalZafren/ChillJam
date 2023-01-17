using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    private string nextScene;
=======

public class Door : MonoBehaviour
{
>>>>>>> main
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(){
<<<<<<< HEAD
        ChangeScene(nextScene);
    }

    public void ChangeScene(string scene){
        SceneManager.LoadScene(scene);
=======
        Debug.Log("Congrats you win the game");
>>>>>>> main
    }
}
