using UnityEngine;
using UnityEngine.InputSystem;


public class playerScript : MonoBehaviour
{
    public float speed = 7f;
    public float forceShot = 190f;
    public bool isPlayer1;

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

        if(!isPlayer1) {
            if (Keyboard.current.upArrowKey.isPressed) moveVertical += 1f;
            if (Keyboard.current.downArrowKey.isPressed) moveVertical -= 1f;
            if (Keyboard.current.leftArrowKey.isPressed) moveHorizontal -= 1f;
            if (Keyboard.current.rightArrowKey.isPressed) moveHorizontal += 1f;
        }

        Vector3 move = (Vector3.forward * moveVertical + Vector3.right * moveHorizontal).normalized;
        transform.Translate(move * speed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision) // tire fonction 
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>(); // rigid body de la balle
            if (ballRb != null)
            {
                Vector3 direction = (collision.transform.position - transform.position).normalized; // vecteur qui va du joueur vers la balle

                ballRb.AddForce(direction * forceShot);
            }
        }
    }
}
