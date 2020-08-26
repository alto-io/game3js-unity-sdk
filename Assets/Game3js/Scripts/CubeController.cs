using System.Runtime.InteropServices;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    private float rotationSpeed = 30;
    private bool isRotating = true;

    [DllImport("__Internal")]
    private static extern void SendNumber(float number);

    private void Update()
    {
        if (this.isRotating == true)
        {
            this.transform.Rotate(new Vector3(0, this.rotationSpeed * Time.deltaTime));
            SendNumber(this.transform.localEulerAngles.y);
        }
    }

    // these public functions are callable from the ReactUnityWebGL container
    public void SetRotationSpeed(float rotationSpeed)
    {
        this.rotationSpeed = rotationSpeed;
    }

    public void StopRotation()
    {
        this.isRotating = false;
    }

    public void StartRotation()
    {
        this.isRotating = true;
    }
}