using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleDeFases : MonoBehaviour
{
    public string ProximaFase;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jogador"))
        {
            SceneManager.LoadScene(ProximaFase);
        }
    }
}
