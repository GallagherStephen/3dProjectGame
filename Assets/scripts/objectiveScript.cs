using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectiveScript : MonoBehaviour
{
    //===================================================
    //Variables
    //===================================================
    public GameObject UiObject;
    public GameObject cube;


    // Start is called before the first frame update
    void Start()
    {
        UiObject.SetActive(true);
    }

    //===================================================
    // WHEN "player" ENTERS TRIGGER 
    //====================================================
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            UiObject.SetActive(true);
    }
    //===================================================
    // WHEN "player" EXITs TRIGGER 
    //====================================================
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        UiObject.SetActive(false);
        Destroy(cube);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
