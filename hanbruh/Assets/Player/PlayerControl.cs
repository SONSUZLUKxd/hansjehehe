using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float vertical;
    public float horizontal;
    Animator anim;
    public Camera cam;
    public Transform camRoot;
    float xRot;
    float yRot;
    public float sensivity;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    float camvec;
    private void Update()
    {
        horizontal = Mathf.Lerp(horizontal, Input.GetAxis("Horizontal"), 9 * Time.fixedDeltaTime);
        vertical = Mathf.Lerp(vertical, Input.GetAxis("Vertical"), 9 * Time.fixedDeltaTime);
        anim.SetFloat("VelocityY", vertical * speed);
        anim.SetFloat("VelocityX", horizontal * speed);
        Vector3 vec = new Vector3(horizontal, 0, vertical);
        rb.AddForce(transform.TransformVector(vec) * speed / 3, ForceMode.VelocityChange);
        cam.transform.position = camRoot.position;
        xRot -= Input.GetAxisRaw("Mouse Y") * sensivity * Time.deltaTime;
        xRot = Mathf.Clamp(xRot, -40f, 70f);
        cam.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        camvec = Input.GetAxisRaw("Mouse X") * sensivity * Time.deltaTime;
        transform.Rotate(Vector3.up, camvec);
        if (Input.GetKey(KeyCode.LeftShift)) { speed = Mathf.Lerp(speed, 6, 9 * Time.fixedDeltaTime); } 
        else { speed = Mathf.Lerp(speed, 2, 9 * Time.fixedDeltaTime); }
    }
}
