using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//clase que se usa para recibir los datos del usuario que se expanda 
public class UserData : MonoBehaviour
{

    [Header("Datos Usuario")]

    public Image foto;
    [Header("Text")]

    public TextMeshProUGUI textName;
    public TextMeshProUGUI email;
    public TextMeshProUGUI gender;
    public TextMeshProUGUI edad;
    public TextMeshProUGUI ciudad;
    public GameObject contend;
    public int userList;
    public UserListHandler userListHandler;

    internal void SetData(string _name, string _email, string _gender, string _edad, string _ciudad, Sprite _sprite)
    {
        contend.SetActive(true);
        textName.text = _name;
        email.text = _email;
        gender.text = _gender;
        edad.text = _edad;
        ciudad.text = _ciudad;
        foto.sprite = _sprite;
    }

    public void Liked()
    {
        contend.gameObject.SetActive(false);

        userListHandler.SetUserLiked(userList);
    }

    public void Cancel()
    {
        contend.gameObject.SetActive(false);
    }



}
