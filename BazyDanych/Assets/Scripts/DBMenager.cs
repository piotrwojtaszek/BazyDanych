using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBMenager
{

    public static string username;
    public static bool LoggedIn { get { return username != null; } }

    public static void LogOut()
    {
        PlayerPrefs.DeleteKey("username");
        PlayerPrefs.DeleteKey("password");
        username = null;
    }
}
