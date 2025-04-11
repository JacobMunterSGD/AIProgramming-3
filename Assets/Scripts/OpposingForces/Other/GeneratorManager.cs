using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{

    public static GameObject[] generators;

    void Start()
    {
        if (generators == null) generators = GameObject.FindGameObjectsWithTag("Generator");
	}
    public static void EndGameCheck()
    {
        bool endGame = true;

        foreach(GameObject g in generators)
        {
            if (g.GetComponent<Generator>().isPoweredOn == false) endGame = false;
		}

        if (endGame == true)
        {
            print("you did it!");
            // end game code
        }
    }
}
