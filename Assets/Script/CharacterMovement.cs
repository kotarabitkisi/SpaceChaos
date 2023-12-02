using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed,XInput,YInput,Xrot,Zrot,RotSpeed;
    private void FixedUpdate()
    {
        YInput = Input.GetAxisRaw("Vertical");
        XInput = Input.GetAxisRaw("Horizontal");

        if (XInput != 0)
        {
            Zrot -= XInput * RotSpeed;
        }
        else {
            if (Zrot > 0)
            {
                Zrot -= 1 * RotSpeed;
            }
            else if(Zrot < 0)
            {
                Zrot += 1 * RotSpeed;
            }
        }
        if (YInput != 0)
        {
            Xrot -= YInput * RotSpeed;
        }
        else
        {
            if (Xrot > 0)
            {
                Xrot -= 1 * RotSpeed;
            }
            else if (Xrot < 0)
            {
                Xrot += 1 * RotSpeed;
            }
        }
        Xrot = Mathf.Clamp(Xrot, -30, 30);
        Zrot = Mathf.Clamp(Zrot, -30, 30);
        transform.rotation =Quaternion.Euler(Xrot,0,Zrot);
        rb.AddForce(new Vector3(XInput,YInput,0)*speed);
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -3, 3) * speed/5, Mathf.Clamp(rb.velocity.y, -3, 3)*speed/5, 0);

    }
}
