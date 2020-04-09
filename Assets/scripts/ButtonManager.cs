using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{
    [SerializeField] private string nextlevel; //scene to move too!

    public void ButtonMoveScene(string nextlevel)
    {
        SceneManager.LoadScene(nextlevel);
    }
}
