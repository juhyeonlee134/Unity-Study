using UnityEngine;

public class Goal : MonoBehaviour
{
    private void Update()
    {
        Vector3 angle = new Vector3(60, 60, 60) * Time.deltaTime;

        transform.Rotate(angle);
    }
}
