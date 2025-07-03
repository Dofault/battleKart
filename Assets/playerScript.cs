using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float speed = 5f;

    void Start() {

    }
    void Update() {
        
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));

    }
}
