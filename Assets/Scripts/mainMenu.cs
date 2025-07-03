using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // si tu utilises le nouveau Input System

public class mainMenu : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}