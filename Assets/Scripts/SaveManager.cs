using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveManager
{

    public static void SaveAccount(GameAccount account)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + " /user.info";
       
        FileStream stream = new FileStream(path, FileMode.Create);

        UserData acc = new UserData(account);

        formatter.Serialize(stream, acc);
        stream.Close();
    }


    public static UserData LoadAccount()
    {
        string path = Application.persistentDataPath + "/user.info";
        
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            UserData data = formatter.Deserialize(stream) as UserData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file no found in " + path);
            return null;
        }
    }
}
