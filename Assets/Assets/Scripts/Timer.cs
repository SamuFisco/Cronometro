
using System.Collections;                
using System.Collections.Generic;        
using UnityEngine;                       
using TMPro;                             // Para trabajar con texto usando TextMeshPro (texto avanzado en Unity)

public class Timer : MonoBehaviour       // Definimos una clase llamada 'Timer' que hereda de 'MonoBehaviour'
{
    // Variables p�blicas visibles en el Inspector de Unity
    public TMP_Text timertext;           // Almacena la referencia al texto que mostrar� el cron�metro
    public bool paraDelante;               // Indica si el cron�metro cuenta hacia atr�s o hacia adelante
    public float time;                   // Almacena el tiempo total que ha pasado o que queda (en segundos)

    // Variables privadas (solo se usan dentro de este script)
    private int minutos, segundos, centesimas;  // Guardan minutos, segundos y cent�simas que queremos mostrar
    private bool isRunning = false;      // Controla si el cron�metro est� en marcha (true) o detenido (false)

    // La funci�n Start se ejecuta al principio, cuando el objeto con este script aparece en la escena
    void Start()
    {
        // Inicializamos el texto del temporizador a "00:00:00"
        timertext.text = "00:00:00";
    }

    // La funci�n Update se llama una vez por frame (aproximadamente cada 0.016 segundos si el juego corre a 60 FPS)
    void Update()
    {
        // Solo ejecutaremos el c�digo del cron�metro si 'isRunning' es true
        if (isRunning)
        {
            // Si 'backwards' es true, el cron�metro cuenta hacia atr�s
            if (paraDelante)
            {
                // Restamos el tiempo que ha pasado desde el �ltimo frame
                time -= Time.deltaTime;
                // Si el tiempo llega a ser menor que 0, lo forzamos a quedarse en 0
                if (time < 0) time = 0;
            }
            else  // Si 'backwards' es false, el cron�metro cuenta hacia adelante
            {
                // Sumamos el tiempo que ha pasado desde el �ltimo frame
                time += Time.deltaTime;
            }

            // Calculamos cu�ntos minutos han pasado dividiendo el tiempo total entre 60
            minutos = (int)(time / 60f);
            // Calculamos cu�ntos segundos han pasado restando los minutos multiplicados por 60 del tiempo total
            segundos = (int)(time - minutos * 60f);
            // Calculamos las cent�simas de segundo multiplicando el decimal que queda por 100
            centesimas = (int)((time - (int)time) * 100f);

            // Actualizamos el texto del cron�metro con los minutos, segundos y cent�simas, en formato "MM:SS:CC"
            timertext.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, centesimas);
        }
    }

    // Esta funci�n p�blica ser� llamada cuando presionemos el bot�n de "Iniciar"
    public void StartTimer()
    {
        // Ponemos 'isRunning' en true, lo que indica que el cron�metro debe empezar a contar
        isRunning = true;
    }

    // Esta funci�n p�blica ser� llamada cuando presionemos el bot�n de "Pausa"
    public void PauseTimer()
    {
        // Cambiamos el estado de 'isRunning' a false para pausar el cron�metro
        isRunning = false;
    }

    // Esta funci�n p�blica ser� llamada cuando presionemos el bot�n de "Detener"
    public void StopTimer()
    {
        // Reiniciamos el tiempo a 0
        time = 0;
        // Detenemos el cron�metro
        isRunning = false;
        // Actualizamos el texto del cron�metro para mostrar "00:00:00"
        timertext.text = "00:00:00";
    }
}
