using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{

    //public Menu menuAtual;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void Jogar(string fase1)
    {
        SceneManager.LoadScene(fase1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
