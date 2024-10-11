
using System.Collections;                
using System.Collections.Generic;        
using UnityEngine;                       
using TMPro;                             // Para trabajar con texto usando TextMeshPro (texto avanzado en Unity)

public class Timer : MonoBehaviour       // Definimos una clase llamada 'Timer' que hereda de 'MonoBehaviour'
{
    // Variables públicas visibles en el Inspector de Unity
    public TMP_Text timertext;           // Almacena la referencia al texto que mostrará el cronómetro
    public bool paraDelante;               // Indica si el cronómetro cuenta hacia atrás o hacia adelante
    public float time;                   // Almacena el tiempo total que ha pasado o que queda (en segundos)

    // Variables privadas (solo se usan dentro de este script)
    private int minutos, segundos, centesimas;  // Guardan minutos, segundos y centésimas que queremos mostrar
    private bool isRunning = false;      // Controla si el cronómetro está en marcha (true) o detenido (false)

    // La función Start se ejecuta al principio, cuando el objeto con este script aparece en la escena
    void Start()
    {
        // Inicializamos el texto del temporizador a "00:00:00"
        timertext.text = "00:00:00";
    }

    // La función Update se llama una vez por frame (aproximadamente cada 0.016 segundos si el juego corre a 60 FPS)
    void Update()
    {
        // Solo ejecutaremos el código del cronómetro si 'isRunning' es true
        if (isRunning)
        {
            // Si 'backwards' es true, el cronómetro cuenta hacia atrás
            if (paraDelante)
            {
                // Restamos el tiempo que ha pasado desde el último frame
                time -= Time.deltaTime;
                // Si el tiempo llega a ser menor que 0, lo forzamos a quedarse en 0
                if (time < 0) time = 0;
            }
            else  // Si 'backwards' es false, el cronómetro cuenta hacia adelante
            {
                // Sumamos el tiempo que ha pasado desde el último frame
                time += Time.deltaTime;
            }

            // Calculamos cuántos minutos han pasado dividiendo el tiempo total entre 60
            minutos = (int)(time / 60f);
            // Calculamos cuántos segundos han pasado restando los minutos multiplicados por 60 del tiempo total
            segundos = (int)(time - minutos * 60f);
            // Calculamos las centésimas de segundo multiplicando el decimal que queda por 100
            centesimas = (int)((time - (int)time) * 100f);

            // Actualizamos el texto del cronómetro con los minutos, segundos y centésimas, en formato "MM:SS:CC"
            timertext.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, centesimas);
        }
    }

    // Esta función pública será llamada cuando presionemos el botón de "Iniciar"
    public void StartTimer()
    {
        // Ponemos 'isRunning' en true, lo que indica que el cronómetro debe empezar a contar
        isRunning = true;
    }

    // Esta función pública será llamada cuando presionemos el botón de "Pausa"
    public void PauseTimer()
    {
        // Cambiamos el estado de 'isRunning' a false para pausar el cronómetro
        isRunning = false;
    }

    // Esta función pública será llamada cuando presionemos el botón de "Detener"
    public void StopTimer()
    {
        // Reiniciamos el tiempo a 0
        time = 0;
        // Detenemos el cronómetro
        isRunning = false;
        // Actualizamos el texto del cronómetro para mostrar "00:00:00"
        timertext.text = "00:00:00";
    }
}
