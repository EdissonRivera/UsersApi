using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

//Funcion que consulta los datos a la api
public class Request : MonoBehaviour
{
    [Header("URL API")]
    public string URLTest;
    public string newData;
    public UserListHandler userListHandler;


    public void ButtonGetRequest()
    {
        StartCoroutine(GetData_Coroutine());
    }

    IEnumerator GetData_Coroutine()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URLTest))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                Debug.Log(request.error);
            else
            {
                Debug.Log(request.downloadHandler.text);
                string data = request.downloadHandler.text;
                ProccessJsonData(data);
            }
        }
    }

    //elimina los primeros caracteres del json 
    public void ProccessJsonData(string datos)
    {
        string valorEliminar = "randomuserdata.(";

        Debug.Log(valorEliminar.Count() + "valor eliminar");
        Debug.Log(datos.Count() + "valor eliminar");

         newData = "";
        for (int i = 0; i < datos.Length-2; i++)
        {
            if(i <valorEliminar.Length)
            {

                if (valorEliminar[i] == datos[i])
                {
                }
            }
            else
            {
                newData = newData + datos[i];

            }
        }
        //convierte el json a una clase para poder usar en el userlisthander
        userListHandler.jsonDataClass = JsonUtility.FromJson<JsonDataClass>(newData);
        userListHandler.GetUserImage();
    }


    public void ButtonPostRequest()
    {
        StartCoroutine(GetData_Coroutine());
    }

    public void ButtonSetRequest()
    {
        StartCoroutine(GetData_Coroutine());
    }


}
