using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    CharacterController controller;
    Vector3 velocity;


    public Transform ground;
    public float distance = 0.3f;


    public float speed;
    public float jumpHeigh;
    public float gravity;

    public LayerMask mask;
    private bool isGrounded;
    private static readonly CharacterController velosj;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

}
