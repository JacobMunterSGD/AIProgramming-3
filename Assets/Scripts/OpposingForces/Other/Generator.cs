using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

	public bool isPoweredOn;

	public Color poweredOnColour;
	public MeshRenderer boxMeshRenderer;

	private void Awake()
	{
		isPoweredOn = false;
	}

	public void ChangePower(bool on)
	{
		isPoweredOn = on;
		GeneratorManager.EndGameCheck();
		if (on) boxMeshRenderer.material.color = poweredOnColour;
	}

}
