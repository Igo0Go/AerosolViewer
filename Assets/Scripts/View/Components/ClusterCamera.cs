using UnityEngine;

public class ClusterCamera : MonoBehaviour
{
    [SerializeField, Min(0.01f)]
    private float speed = 1;

    Vector3 localRotation;

    private void Awake()
    {
        localRotation = transform.localRotation.eulerAngles;
    }

    void Update()
    {
        if(!Input.GetMouseButton(1)) return;


        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if(mouseX == 0 || mouseY == 0)
        {
            return;
        }

        localRotation += new Vector3(-mouseY, mouseX, 0) * speed;
        localRotation.x = Mathf.Clamp(localRotation.x, -90, 90);
        transform.localRotation = Quaternion.Euler(localRotation);
    }
}
