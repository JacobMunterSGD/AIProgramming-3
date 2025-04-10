using NodeCanvas.Framework;
using NodeCanvas.Tasks.Conditions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerController : MonoBehaviour
{

    CharacterController characterController;

    public float speed;

	public LayerMask playerDeathLayer;


	bool isStunned;
	float timeWhenLastStunned;

	public float playerHasBeenStunnedCooldown;

    void Start()
    {
		isStunned = false;
		TryGetComponent<CharacterController>(out characterController);
    }

    void Update()
    {
		if (!isStunned)
		{
			MovementInputs();
			LookInput();

			
		}

		if (isStunned && Time.time - timeWhenLastStunned > playerHasBeenStunnedCooldown) isStunned = false;
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
		}
		if (Input.GetKey(KeyCode.S))
		{
			direction += -Vector3.forward;
		}
		if (Input.GetKey(KeyCode.A))
		{
			direction += -Vector3.right;
		}
		if (Input.GetKey(KeyCode.D))
		{
			direction += Vector3.right;
		}

		direction = direction.normalized;

		characterController.Move(direction * speed * Time.deltaTime);
	}

	public void GetStunned()
	{
		isStunned = true;
		timeWhenLastStunned = Time.time;
	}

	 //if collides with enemy, stun player
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.transform.parent.tag == "Enemy")
		{
			Destroy(gameObject);
        }
	}
}
