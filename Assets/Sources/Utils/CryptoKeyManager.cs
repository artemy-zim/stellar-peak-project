using System;
using System.Security.Cryptography;
using UnityEngine;

public class CryptoKeyManager
{
    public static byte[] GetKey()
    {
        byte[] data = GetData(CryptoKeyData.Params.EncryptionKeyPref);

        return data;
    }

    public static byte[] GetIV()
    {
        byte[] data = GetData(CryptoKeyData.Params.EncryptionIVPref);

        return data;
    }

    private static byte[] GetData(string key)
    {
        if(PlayerPrefs.HasKey(key) == false)
            GenerateNewKey();

        return Convert.FromBase64String(PlayerPrefs.GetString(key));
    }

    private static void GenerateNewKey()
    {
        using Aes aes = Aes.Create();
        aes.GenerateKey();
        aes.GenerateIV();

        PlayerPrefs.SetString(PlayerPrefs.GetString(CryptoKeyData.Params.EncryptionKeyPref), Convert.ToBase64String(aes.Key));
        PlayerPrefs.SetString(PlayerPrefs.GetString(CryptoKeyData.Params.EncryptionIVPref), Convert.ToBase64String(aes.IV));
        PlayerPrefs.Save();
    }
}
