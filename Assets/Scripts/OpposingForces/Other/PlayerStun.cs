using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using NodeCanvas.Tasks.Conditions;

public class PlayerStun : MonoBehaviour
{

    public float stunRange;
    public LayerMask stunLayerMask;

    public GameObject stunVisual;
    MeshRenderer stunVisualMeshRenderer;

    public float offset;

    public Color transparentColor;
    public Color visibleColor;

    public float popInSpeed;
    public float popOutSpeed;

    private void Start()
    {
        stunVisual.transform.localScale = new Vector3(stunVisual.transform.localScale.x, stunVisual.transform.localScale.y, stunRange);
        stunVisual.transform.position = new Vector3(stunVisual.transform.position.x, stunVisual.transform.position.y, stunVisual.transform.position.z + offset + stunVisual.transform.localScale.z / 2);

        stunVisualMeshRenderer = stunVisual.GetComponent<MeshRenderer>();

        transparentColor = stunVisualMeshRenderer.material.color;
        transparentColor.a = 0;

        visibleColor = transparentColor;
        visibleColor.a = .6f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Stun();
            StunVisualStart();
        }
    }

    void Stun()
    {

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, stunRange, stunLayerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow); // remove later
            if (hit.transform.parent.gameObject.TryGetComponent<Blackboard>(out Blackboard hitBlackboard))
            {
                hitBlackboard.SetVariableValue("isStunned", true);                

            }

            //LeanTween.value(stunVisual, 0, 1, 1).setOnUpdate(UpdateColor).setOnComplete(MakeVisualTransparent);
        }
    }

    void StunVisualStart()
    {
        LeanTween.color(stunVisual, visibleColor, popInSpeed).setOnComplete(MakeVisualTransparent).setEaseOutCirc();
    }

    void MakeVisualTransparent()
    {
        //LeanTween.value(stunVisual, 1, 0, 1).setOnUpdate(UpdateColor);
        LeanTween.color(stunVisual, transparentColor, popOutSpeed).setEaseInCirc();
    }

    void UpdateColor(float alpha)
    {
        Color currentColor = stunVisualMeshRenderer.material.color;
        currentColor.a = alpha;
        stunVisualMeshRenderer.material.color = currentColor;
    }

}
