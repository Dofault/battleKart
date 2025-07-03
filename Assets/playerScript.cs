using UnityEngine;
using UnityEngine.InputSystem;


public class playerScript : MonoBehaviour
{
    public float speed = 5f;
    public bool isPlayer1; // cocher si c’est le joueur 1 dans l’inspecteur

    void FixedUpdate()
    {
        float moveVertical = 0f;
        float moveHorizontal = 0f;

        if (isPlayer1)
        {
            if (Keyboard.current.zKey.isPressed) moveVertical += 1f;
            if (Keyboard.current.sKey.isPressed) moveVertical -= 1f;
            if (Keyboard.current.qKey.isPressed) moveHorizontal -= 1f;
            if (Keyboard.current.dKey.isPressed) moveHorizontal += 1f;
        }
        else
        {
            if (Keyboard.current.upArrowKey.isPressed) moveVertical += 1f;
            if (Keyboard.current.downArrowKey.isPressed) moveVertical -= 1f;
            if (Keyboard.current.leftArrowKey.isPressed) moveHorizontal -= 1f;
            if (Keyboard.current.rightArrowKey.isPressed) moveHorizontal += 1f;
        }

        Vector3 move = (Vector3.forward * moveVertical + Vector3.right * moveHorizontal).normalized;
        transform.Translate(move * speed * Time.fixedDeltaTime);
    }
}
