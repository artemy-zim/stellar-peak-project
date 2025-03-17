using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class JsonFileHandler
{
    private static string FilePath => Application.persistentDataPath + "/settings.json";

    public static void SaveToFile<T>(T data)
    {
        string json = JsonUtility.ToJson(data, true);
        string encryptedJson = Encrypt(json);

        File.WriteAllText(FilePath, encryptedJson);
    }

    public static T LoadFromFile<T>() where T : new()
    {
        if (File.Exists(FilePath))
        {
            string encryptedJson = File.ReadAllText(FilePath);
            string json = Decrypt(encryptedJson);

            return JsonUtility.FromJson<T>(json);
        }

        return new T();
    }

    private static string Encrypt(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = CryptoKeyManager.GetKey();
            aes.IV = CryptoKeyManager.GetIV();

            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                return Convert.ToBase64String(encryptedBytes);
            }
        }
    }

    private static string Decrypt(string encryptedText)
    {
        using Aes aes = Aes.Create();
        aes.Key = CryptoKeyManager.GetKey();
        aes.IV = CryptoKeyManager.GetIV();

        using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

        return Encoding.UTF8.GetString(decryptedBytes);
    }
}
