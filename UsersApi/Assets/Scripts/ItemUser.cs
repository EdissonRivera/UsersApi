using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


//clase que se usa para cada item dentro de las listas, aqui se setea las imagenes y valores del usuario 
public class ItemUser : MonoBehaviour
{

    [Header("UI")]
    public Image image;
    public Sprite photoMedium;
    public Sprite photoLarge;
    public TextMeshProUGUI textName;
    public string name;
    public string email;
    public string gender;
    public string edad;
    public string ciudad;

    public UserListHandler userListHandler;
    
    internal void SetData(string _name,string _email,string _gender,string _edad,string _ciudad, Sprite _spriteMedium)
    {
        name = _name;
        textName.text = _name;
        email = _email;
        gender = _gender;
        edad = _edad;   
        ciudad = _ciudad;
        image.sprite = _spriteMedium;
        photoMedium = _spriteMedium;


    }

    public void ButtonLike()
    {
        userListHandler.SetUserLiked(transform.GetSiblingIndex());
    }

    public void ButtonInfo()
    {
        Debug.Log("Info user");
        userListHandler.userData.SetData(name,email,gender,edad,ciudad,photoLarge);
        userListHandler.userData.userList = transform.GetSiblingIndex();
        userListHandler.OffPanels();
        userListHandler.usersProfile.SetActive(true);
        //gameObject.SetActive(false);
    }

    public void NoLiked()
    {

    }

}
