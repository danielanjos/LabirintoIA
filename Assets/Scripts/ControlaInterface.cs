using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ControlaInterface : MonoBehaviour
{
    private float tempoRestante;
    public float TempoMaximo = 3;
    public Slider MeuSlider;
    public Text TextoTimer;
    public Text TextoNivel;
    public GameObject MensagemGameOver;
    public GameObject MensagemPause;
    private ControlaJogador scriptControlaJogador;
    public Text TextoGameOver;
    public Text TextoPause;

    // Start is called before the first frame update
    void Start()
    {
        MeuSlider.maxValue = TempoMaximo;
        MeuSlider.value = TempoMaximo;
        tempoRestante = TempoMaximo;
        TextoTimer.text = "";
        TextoNivel.text = SceneManager.GetActiveScene().name;
        scriptControlaJogador = GameObject.FindWithTag("Jogador").GetComponent<ControlaJogador>();
    }

    private void Update()
    {
        MeuSlider.value = tempoRestante;
        int segundos = (int)tempoRestante % 60;
        int minutos = (int)tempoRestante / 60;
        TextoTimer.text = minutos.ToString().PadLeft(2, '0') + ":" + segundos.ToString().PadLeft(2, '0');

        if (tempoRestante <= 0)
        {
            tempoRestante = 0;
            GameOver("Tempo esgotado! \nClique para reiniciar");
        }
        else if (tempoRestante >= 0)
        {
            tempoRestante -= Time.deltaTime;
        }
    }

    public void GameOver(string mensagem)
    {
        Time.timeScale = 0;
        TextoGameOver.text = mensagem;
        MensagemGameOver.SetActive(true);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pausar()
    {
        Time.timeScale = 0;
        TextoPause.text = "Jogo Pausado";
        MensagemPause.SetActive(true);
    }

    public void Retomar()
    {
        MensagemPause.SetActive(false);
        Time.timeScale = 1;
    }
}

