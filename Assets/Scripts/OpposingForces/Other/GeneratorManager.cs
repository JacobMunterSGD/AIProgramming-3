using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorManager : MonoBehaviour
{

    public static GeneratorManager Instance;

    public TMP_Text generatorsLeftNumber;

    int generatorsLeft = 0;

    public static GameObject[] generators;

    void Start()
    {
        Instance = this;
        if (generators == null) generators = GameObject.FindGameObjectsWithTag("Generator");

        generatorsLeft = generators.Count();

		UpdateGeneratorText(0);
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

    public void UpdateGeneratorText(int changeBy)
    {
        generatorsLeft += changeBy;
		generatorsLeftNumber.text = generatorsLeft.ToString();
	}
}
