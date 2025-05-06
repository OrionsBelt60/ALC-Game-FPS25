using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
   [Header("Movement")]
    public float moveSpeed; 
    public float jumpForce; 
    [Header("Camera")]
    public float lookSensitivity; 
    public float maxLookX;// lowest down we can look
    public float minLookX;// highest up we can look
    private float rotX; 

    private Camera cam;
    private Rigidbody rig;
    [Header("Weapon")]
    private ProjectileWeapon weapon;

    

    
    void Awake()
    {
        //Get the components
        cam = Camera.main;
        rig = GetComponent<Rigidbody>();
        weapon = GetComponent<ProjectileWeapon>();

        // Disable and Hide the Cursor
        Cursor.lockState = CursorLockMode.Locked;

    }
    
    // Update is called once per frame
    void Update()
    {
       Move(); 
       CamLook();

       if(Input.GetButtonDown("Jump"))
            TryJump();
        if(Input.GetButtonDown("Fire1"))
        {
            if(weapon.CanShoot())
                weapon.Shoot();
        }


            
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // Move relative to the cameras forward direction
        Vector3 dir = transform.right * x + transform.forward * z;
        dir.y = rig.velocity.y;

        rig.velocity = dir;       

    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX = Mathf.Clamp(rotX, minLookX, maxLookX); // Clamp the vertical rotation on the x-axis

        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0); // drive rotation on the x-axis
        transform.eulerAngles += Vector3.up * y; // drive rotation on the y-axis
    }

    void TryJump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 1.1f))
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

}
