using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlaInimigo : MonoBehaviour
{

    public GameObject Jogador;
    public float VelocidadeMovimento = 2;
    private Rigidbody rigidbodyInimigo;
    private Transform jogador;
    private NavMeshAgent agente;
    public AudioClip SomDeZumbi;
    public AudioClip SomDeDano;
    private AnimacaoPersonagem animacaoInimigo;
    private AudioSource meuAudioSource;
    bool tocarSom;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyInimigo = GetComponent<Rigidbody>();
        jogador = GameObject.FindWithTag("Jogador").transform;
        Jogador = GameObject.FindWithTag("Jogador");
        agente = GetComponent<NavMeshAgent>();
        agente.speed = VelocidadeMovimento;
        animacaoInimigo = GetComponent<AnimacaoPersonagem>();
        meuAudioSource = GetComponent<AudioSource>();
        tocarSom = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jogador.position);
        if (distancia <= 11)
        {
            agente.SetDestination(jogador.position);
            animacaoInimigo.Movimentar(agente.velocity.magnitude);
        } else
        {
            tocarSom = true;
        }
    }

    private void FixedUpdate()
    {

        if (agente.hasPath)
        {
            
            // stoppingDistance definida com valor 2,2 via interface Unity
            bool perto = agente.remainingDistance <= agente.stoppingDistance;
            if (perto)
            {
                animacaoInimigo.Movimentar(0);
                animacaoInimigo.Atacar(true);
            }
            else
            {
                animacaoInimigo.Atacar(false);
            }
        }
    }

    void AtacaJogador()
    {
        meuAudioSource.PlayOneShot(SomDeDano);
        Jogador.GetComponent<ControlaJogador>().TomarDano(false);
    }

}
