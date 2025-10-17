using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [Header("�÷��̾� ����")]
    public float speed = 5f;
    public float jumpPower = 5f;
    public float gravity = -9.81f;

    [Header("ī�޶� ����")]
    public Camera playerCamera; // 1��Ī ���� ī�޶�
    public float mouseSensitivity = 2f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private float xRotation = 0f; // ���Ʒ� ȸ����

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // ���콺 Ŀ�� ����
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        MovePlayer();
        RotateCamera();
    }

    void MovePlayer()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpPower;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); // ���Ʒ� ����

        // ī�޶� ȸ��
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}

