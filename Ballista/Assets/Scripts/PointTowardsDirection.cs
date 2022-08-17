using UnityEngine;

public class PointTowardsDirection : MonoBehaviour
{

    public Rigidbody rb;
    bool launched;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update(){

        if (rb.velocity.magnitude >= 5f) {
            launched = true;
        }



        if (launched) {
            transform.forward = -rb.velocity;
        }   
    }
}