using System.Collections.Generic;
using System.Data.Common;
using JetBrains.Annotations;
using UnityEngine;

public class signalGenerator : MonoBehaviour
{
    [Header("Parametry funkcji y = a*sin(bx + c) + d")]
    public float a = 1f;
    public float b = 1f;
    public float c = 0f;
    public float d = 0f;
    public void setA(float value)
    {
        a=value;
    }
    public void setB(float value)
    {
        b=value;
    }
    public void setC(float value)
    {
        c=value;
    }
    public void setD(float value)
    {
        d=value;
    }
    [SerializeField] int additionalSignalCount = 0;

    [SerializeField] float[] secondSignal=new float[]{0,0,0,0};

    [SerializeField] List<float[]> additionalSignals = new List<float[]>();
    
    public float[] getParameters()
    {
        float[] data = new float[4];
        data[0] = this.a;
        data[1] = this.b;
        data[2] = this.c;
        data[3] = this.d;
        return data;
    }
    public void setBaseSignalParameter(float a, float b, float c, float d) //Parametry funckji y = a*sin(bx + c) + d
    {
        this.a = a;
        this.b = b;
        this.c = c;
        this.d = d;
    }
    public void setBaseSignalParameter(float[] data) //Parametry funckji y = a*sin(bx + c) + d
    {
        this.a = data[0];
        this.b = data[1];
        this.c =data[2];
        this.d=data[3];
    }
    public float returnValue(float T) 
    {
        
            float value = (a * Mathf.Sin(b * T + c) + d);
            value+=(secondSignal[0] * Mathf.Sin(secondSignal[1] * T + secondSignal[2]) + secondSignal[3]);
            foreach (float[] data in additionalSignals)
            {
                value += (data[0] * Mathf.Sin(data[1] * T + data[2]) + data[3]);
            }
            return value;
        
    }
    public void modifySecondSignal(float a, float b, float c, float d) //Parametry funckji y = a*sin(bx + c) + d
    {
        secondSignal[0] = a;
        secondSignal[1] = b;
        secondSignal[2] = c;
        secondSignal[3] = d;
    }
    public void resetSecondSignal()
    {
        modifySecondSignal(0,0,0,0);
    }
    public void modifySecondSignal(float[] data) //Parametry funckji y = a*sin(bx + c) + d
    {
        secondSignal=data;
    }
    public void addAnotherSignal(float[] data) //Parametry funckji y = a*sin(bx + c) + d
    {
        additionalSignals[additionalSignalCount] = data;
        additionalSignalCount++;
    }
    public void addAnotherSignal(float a, float b, float c, float d) //Parametry funckji y = a*sin(bx + c) + d
    {

        float[] data = new float[4];
        data[0] = a;
        data[1] = b;
        data[2] = c;
        data[3] = d;
        additionalSignals[additionalSignalCount] = data;
        additionalSignalCount++;
    }
    
    public float calculateArea(float time, int startX, int endX)
    {
        float area = 0f;
        for (int i = -startX; i <= endX; i++)
            area += Mathf.Abs(returnValue(time + i));


        return area;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
