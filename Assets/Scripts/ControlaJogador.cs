using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{

    public int VelocidadeMovimento = 5;
    private Rigidbody rigidbodyJogador;
    private Vector3 direcao;
    public GameObject TextoGameOver;
    public bool Vivo = true;
    private AnimacaoPersonagem animacaoJogador;
    public ControlaInterface ScriptControlaInterface;
    
    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1;
        rigidbodyJogador = GetComponent<Rigidbody>();
        animacaoJogador = GetComponent<AnimacaoPersonagem>();
    }

    // Update is called once per frame
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        animacaoJogador.Movimentar(direcao.magnitude);
    }

    void FixedUpdate()
    {
        rigidbodyJogador.MovePosition
            (rigidbodyJogador.position +
            (direcao * VelocidadeMovimento * Time.deltaTime));

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
        }
    }

    public void TomarDano(bool vivo)
    {
        Vivo = vivo;
        ScriptControlaInterface.GameOver("Você foi pego! \nTente novamente.");
    }

}
