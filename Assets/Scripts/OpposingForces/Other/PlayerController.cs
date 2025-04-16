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

	public Transform hasBeenStunnedVisual;
	List<MeshRenderer> stunnedBalls = new();
	public float ballSpinSpeed;

	bool isStunned;
	float timeWhenLastStunned;

	public float playerHasBeenStunnedCooldown;

    void Start()
    {
		isStunned = false;
		TryGetComponent<CharacterController>(out characterController);

		foreach (MeshRenderer mr in hasBeenStunnedVisual.GetComponentsInChildren<MeshRenderer>())
		{
			stunnedBalls.Add(mr);
		}

		UpdateOpacity(0);
	}

    void Update()
    {
		if (!isStunned)
		{
			MovementInputs();
			LookInput();			
		}

		if (isStunned && Time.time - timeWhenLastStunned > playerHasBeenStunnedCooldown)
		{
			isStunned = false;
			LeanTween.value(1, 0, .3f).setOnUpdate(UpdateOpacity);
		}

		HasBeenStunnedVisualRotate();
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
		LeanTween.value(0, 1, .3f).setOnUpdate(UpdateOpacity);
	}
	void HasBeenStunnedVisualRotate()
	{
		hasBeenStunnedVisual.position = transform.position + Vector3.up * 3;
		hasBeenStunnedVisual.Rotate(new Vector3(0, ballSpinSpeed, 0) * Time.deltaTime);
	}

	void UpdateOpacity(float alpha)
	{
		foreach(MeshRenderer mr in stunnedBalls)
		{
			mr.material.color = new Color(mr.material.color.r, mr.material.color.g, mr.material.color.b, alpha);
		}
	}

	 //if collides with enemy, stun player
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.transform.parent.tag == "Enemy")
		{
			Destroy(gameObject);
			Destroy(hasBeenStunnedVisual.gameObject);
        }
	}
}
