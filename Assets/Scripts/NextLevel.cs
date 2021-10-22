using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string lvlName;
    public GameObject victory;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name == "Level6")
        {
            victory.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(lvlName);
        }
    }
}
