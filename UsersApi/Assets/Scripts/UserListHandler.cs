using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserListHandler : MonoBehaviour
{
    [Header("Instancia prefas")]

    public Transform fatherItemsAllUsers;
    public Transform fatherItemsLikedUsers;

    [Header("Prefabs")]

    public GameObject userItemPrefab;

    [Header("Clase Json")]
    public JsonDataClass jsonDataClass;

    public Sprite defaultIcon;
    public UserData userData;


    [Header("Panels")]
    public GameObject usersAll;
    public GameObject usersLiked;
    public GameObject usersProfile;


    //Obttiene las imagenes de la URL para cada item de usuario
    public void GetUserImage()
    {
        StartCoroutine(GetSprite());
    }

    IEnumerator GetSprite()
    {
        OffPanels();
        usersAll.SetActive(true);
        for (int i = 0; i < jsonDataClass.results.Length; i++)
        {
            WWW UrlSprite = new WWW(jsonDataClass.results[i].picture.medium);
            yield return UrlSprite;

            if (UrlSprite.error != null)
            {
                ItemUser item = Instantiate(userItemPrefab, fatherItemsAllUsers).GetComponent<ItemUser>();
                item.SetData(jsonDataClass.results[i].name.first,
                    jsonDataClass.results[i].email,
                    jsonDataClass.results[i].gender,
                    jsonDataClass.results[i].dob.age.ToString(),
                    jsonDataClass.results[i].location.city,
                    defaultIcon);
                item.userListHandler = GetComponent<UserListHandler>();
            }
            else
            {
                if (UrlSprite.isDone)
                {
                    Texture2D tx = UrlSprite.texture;
                    Sprite iconUser = Sprite.Create(tx, new Rect(0f, 0f, tx.width, tx.height), Vector2.zero, 10f);

                    ItemUser item = Instantiate(userItemPrefab, fatherItemsAllUsers).GetComponent<ItemUser>();
                    item.SetData(jsonDataClass.results[i].name.first,
                    jsonDataClass.results[i].email,
                    jsonDataClass.results[i].gender,
                    jsonDataClass.results[i].dob.age.ToString(),
                    jsonDataClass.results[i].location.city,
                    iconUser);

                    item.userListHandler = GetComponent<UserListHandler>();
                }
            }
        }
        StartCoroutine(SetSpriteLarge());
    }

    //agrega la imagen mas grante para luego utilizar cuando se maxee el perfil
    IEnumerator SetSpriteLarge()
    {
        for (int i = 0; i < jsonDataClass.results.Length; i++)
        {
            WWW UrlSprite = new WWW(jsonDataClass.results[i].picture.large);
            yield return UrlSprite;

            if (UrlSprite.error != null)
            {
                fatherItemsAllUsers.GetChild(i).GetComponent<ItemUser>().photoLarge = defaultIcon;
            }
            else
            {
                if (UrlSprite.isDone)
                {
                    Texture2D tx = UrlSprite.texture;
                    Sprite iconUser = Sprite.Create(tx, new Rect(0f, 0f, tx.width, tx.height), Vector2.zero, 10f);


                    fatherItemsAllUsers.GetChild(i).GetComponent<ItemUser>().photoLarge = iconUser;
                }
            }
        }
    }

    //funcion que recibe cuando se oprime el perfil de algun usuario
    public void SetUserLiked(int user)
    {
        OffPanels();

        fatherItemsAllUsers.GetChild(user).gameObject.SetActive(false);

        ItemUser item = Instantiate(userItemPrefab, fatherItemsLikedUsers).GetComponent<ItemUser>();
        item.SetData(jsonDataClass.results[user].name.first,
            jsonDataClass.results[user].email,
            jsonDataClass.results[user].gender,
            jsonDataClass.results[user].dob.age.ToString(),
            jsonDataClass.results[user].location.city,
            fatherItemsAllUsers.GetChild(user).GetComponent<ItemUser>().photoMedium);

        item.photoLarge = fatherItemsAllUsers.GetChild(user).GetComponent<ItemUser>().photoLarge;
                    item.userListHandler = GetComponent<UserListHandler>();

        usersProfile.SetActive(true);
    }

    //activa la lista de personas que te gustadon
    public void ListLiked()
    {
        OffPanels();
        fatherItemsLikedUsers.gameObject.SetActive(true);
        usersLiked.SetActive(true);
    }

    //apaga todos los paneles

   public  void OffPanels()
    {
        usersLiked.SetActive(false);
        usersAll.SetActive(false);
        usersProfile.SetActive(false);
    }
       



}
