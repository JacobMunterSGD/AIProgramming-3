using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GeneratorManager : MonoBehaviour
{

    public static GeneratorManager Instance;

    public TMP_Text generatorsLeftNumber;
    public GameObject winText;

    int generatorsLeft = 0;

    public static GameObject[] generators;

    void Start()
    {
        Instance = this;
        if (generators == null) generators = GameObject.FindGameObjectsWithTag("Generator");

        generatorsLeft = generators.Count();

        winText.SetActive(false);
		UpdateGeneratorText(0);
	}
    public void EndGameCheck()
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
			StartCoroutine(EndGame());

		}
    }

    public void UpdateGeneratorText(int changeBy)
    {
        generatorsLeft += changeBy;
		generatorsLeftNumber.text = generatorsLeft.ToString();
	}

    public IEnumerator EndGame()
    {
        winText.SetActive(true);

		yield return new WaitForSeconds(3);

		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);

	}
}
