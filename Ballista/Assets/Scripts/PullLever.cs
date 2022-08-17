using UnityEngine;

public class PullLever : MonoBehaviour
{
    private Rigidbody thisRB;
    public float force;

    void Start(){


        thisRB = GetComponent<Rigidbody>();
    
    }
    void Update(){



        if (Input.GetKey(KeyCode.Return)) {


            thisRB.AddRelativeTorque(new Vector3(force, 0, 0), ForceMode.Impulse);

        }  
    
    
    }
}
