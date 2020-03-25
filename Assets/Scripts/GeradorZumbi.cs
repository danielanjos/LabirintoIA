using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbi : MonoBehaviour
{
    public GameObject zumbi;
    public Transform[] posicoes;
    // Start is called before the first frame update
    void Start()
    {
        calcularPosicao();
    }

    Vector3 calcularPosicao()
    {
        Vector3 posicao = Vector3.zero;
        
        int caminhoVazio = Random.Range(0, 2);

        int i = 0;
        foreach(Transform p in posicoes)
        {
            if(i != caminhoVazio)
            {
                Instantiate(zumbi, p.transform.position, Quaternion.identity);
            } else
            {
                Debug.Log("Nao gera!" + i);
            }
            i++;
        }

        return posicao;
    }
}
