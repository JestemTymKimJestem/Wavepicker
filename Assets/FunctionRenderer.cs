using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(LineRenderer))]
public class FunctionPlotter : MonoBehaviour
{
    public float xStart = -5f;       // Początek zakresu X
    public float xEnd = 5f;          // Koniec zakresu X
    public int points = 200;         // Ilość punktów (gęstość)
    public float scale = 1f;         // Skala osi
    [SerializeField] bool isAScreen=false;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] TimerBehaviour timerBehaviour;
    [SerializeField] GameObject timerObject;
    private float elapsedTime=0f;
    [Header("Parametry funkcji y = a*sin(bx + c) + d")]
    public float a=1f;
    public float b=1f;
    public float c=1f;
    public float d = 1f;
    public bool wannaSetNewParameters = false;

    [SerializeField] bool isTimeBased=false;
    [SerializeField] public float value=0f;
    [SerializeField] UnityEngine.Vector2 position;
    [SerializeField] UnityEngine.Vector2 lastPosition;
    [SerializeField] public UnityEngine.Vector2 directionVector;

    [SerializeField] signalGenerator fc;
    [SerializeField] float functionArea = 0;

    public void newSignalGen(signalGenerator gen)
    {
        this.fc=gen;
    }
    public float getFunctionArea()
    {
        return functionArea;
    }
    public void updateFunctionArea()
    {
        functionArea = fc.calculateArea(elapsedTime, Convert.ToInt16(xStart),Convert.ToInt16(xEnd));
    }
    public float GetValue()
    {
        return value;
    }

    void Start()
    {
        if(!isAScreen)
            fc.setBaseSignalParameter( a, b, c, d);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = points;
        timerObject=GameObject.Find("Timer");
        timerBehaviour=timerObject.GetComponent<TimerBehaviour>();
        lineRenderer.useWorldSpace = false;
        position = new UnityEngine.Vector2(0f, 0f);
        lastPosition = new UnityEngine.Vector2(0f, 0f);
        directionVector = new UnityEngine.Vector2(0f, 0f);

    }

    void DrawFunction()
    {
        for (int i = 0; i < points; i++)
        {
            float x = Mathf.Lerp(-xStart, xEnd, i / (float)(points - 1));
            float y = a*Mathf.Sin(b*x+c)+d;  // ← tu wpisz swoją funkcję
            value=y;
            lineRenderer.SetPosition(i, new UnityEngine.Vector3(x*scale, y * scale, 0));
        }
    }

    void DrawFunction(float time)
    {
        for (int i = 0; i < points; i++)
        {
            float x = Mathf.Lerp(-xStart,xEnd, i / (float)(points - 1));
            float y=fc.returnValue(x+ time);
            value=y;
            lineRenderer.SetPosition(i, new UnityEngine.Vector3(x*scale, y * scale, 0));
        }
    }
    void Update()
    {
        elapsedTime=timerBehaviour.getTime();

        if(fc!=null){
        if (isTimeBased == false)
            DrawFunction();
        else
            DrawFunction(elapsedTime);

        lastPosition = position;
        position = transform.position;
        directionVector = position - lastPosition;
        updateFunctionArea();

        if(wannaSetNewParameters)
        {
            fc.setBaseSignalParameter(a, b, c, d);
            wannaSetNewParameters = false;
        }
        }
    }
}
