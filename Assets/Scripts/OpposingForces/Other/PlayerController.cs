using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerController : MonoBehaviour
{

    CharacterController characterController;

    public float speed;

	public LayerMask stunLayerMask;

	public float stunRange;

    void Start()
    {
        TryGetComponent<CharacterController>(out characterController);
    }

    void Update()
    {
        MovementInputs();
		LookInput();

		if (Input.GetKeyDown(KeyCode.Space)) Stun();
	}

	void Stun()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, stunRange, stunLayerMask))
		{
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow); // remove later

		}
	}

	void LookInput()
	{
		// code to rotate character is from https://discussions.unity.com/t/rotate-towards-mouse-position/883950/4
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out RaycastHit raycastHit))
		{
			transform.LookAt(new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z));
		}
	}

    void MovementInputs()
    {
		Vector3 direction = Vector3.zero;

		if (Input.GetKey(KeyCode.W))
		{
			direction += Vector3.forward;
			//characterController.Move(speed * Vector3.forward * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.S))
		{
			direction += -Vector3.forward;
			//characterController.Move(speed * -Vector3.forward * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.A))
		{
			direction += -Vector3.right;
			//characterController.Move(speed * -Vector3.right * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D))
		{
			direction += Vector3.right;
			//characterController.Move(speed * Vector3.right * Time.deltaTime);
		}

		direction = direction.normalized;

		characterController.Move(direction * speed * Time.deltaTime);
	}
}
