using UnityEngine;

public class BallistaRope : MonoBehaviour
{
    public Transform ropePosition;
    public Transform ropePosition2;
    public Transform ropePosition3;
    public Transform ropePosition4;

    public LineRenderer line1;
    public LineRenderer line2;

    private void Update() {

        line1.SetPosition(0, ropePosition.position);
        line1.SetPosition(1, ropePosition2.position);

        line2.SetPosition(0, ropePosition3.position);
        line2.SetPosition(1, ropePosition4.position);
    }
}
