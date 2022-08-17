using UnityEngine;

public class TurnWheel : MonoBehaviour
{
    Rigidbody rb;
    public float force;
    float input;

    public bool lift;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        

        if (lift) {
            input = Input.GetAxisRaw("Vertical");
        } else {
            input = Input.GetAxisRaw("Horizontal");
        }
    }

    private void FixedUpdate() {



        var rot = new Vector3(0, 0, force * input);

        rb.AddRelativeTorque(rot, ForceMode.Acceleration);
    }
}
