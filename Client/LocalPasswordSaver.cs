using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using Client.Models;
using Client.Properties;
using Microsoft.Win32;

namespace Client
{
    //public class LocalPasswordSaver
    //{
    //    private const string RegisterPath = @"Software\Luna\AudioManager";
    //    private readonly Settings _defaultSettings = Settings.Default;

    //    public List<UserCredentials> GetSavedInfo()
    //    {
    //        var credentials = new List<UserCredentials>();
    //        if (_defaultSettings.Accounts == null)
    //        {
    //            _defaultSettings.Accounts = new StringCollection();
    //            _defaultSettings.Save();
    //        }
    //        else
    //        {
    //            foreach (var account in _defaultSettings.Accounts)
    //            {
    //                var index = account.IndexOf('-');
    //                var value = account.Substring(index + 1, account.Length - index - 1);
    //                //credentials.Add(new LoginedUser {Nickname = account.Substring(0, index),Passwd = value});
    //            }
    //        }
    //        return credentials;
    //    }

    //    private string GetKey(string account)
    //    {
    //        var index = account.IndexOf('-');
    //        return account.Substring(0, index);
    //    }

    //    private void RemoveAccessToken(string key)
    //    {
    //        foreach (var account in _defaultSettings.Accounts)
    //        {
    //            if (key != GetKey(account)) continue;
    //            _defaultSettings.Accounts.Remove(account);
    //            break;
    //        }
    //        _defaultSettings.Save();
    //    }

    //    public void SaveAccessToken(string passwd,string nickname)
    //    {
    //        try
    //        {
    //            var plaintext = Encoding.Unicode.GetBytes(passwd);
    //            var entropy = new byte[20];
    //            using (var rng = new RNGCryptoServiceProvider())
    //            {
    //                rng.GetBytes(entropy);
    //            }
    //            var protectedToken = ProtectedData.Protect(plaintext, entropy, DataProtectionScope.CurrentUser);
    //            SaveSalt(nickname, entropy);
    //            var toSave = Convert.ToBase64String(protectedToken);
    //            var replaced = false;
    //            foreach (var account in _defaultSettings.Accounts)
    //            {
    //                if (GetKey(account) != nickname)
    //                    continue;
    //                _defaultSettings.Accounts.Remove(account);
    //                _defaultSettings.Accounts.Add(nickname + "-" + toSave);
    //                replaced = true;
    //                break;
    //            }
    //            if (!replaced)
    //                _defaultSettings.Accounts.Add(nickname + "-" + toSave);
    //            _defaultSettings.Save();
    //        }
    //        catch (Exception ex) when (ex is ConfigurationException || ex is CryptographicException ||
    //        ex is SecurityException || ex is UnauthorizedAccessException || ex is IOException)
    //        {
    //            MessageBox.Show("Can not save token because of error:" + ex.Message);
    //        }
    //    }

    //    private void SaveSalt(string nickname, IEnumerable salt)
    //    {
    //        var key = Registry.CurrentUser.CreateSubKey(RegisterPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
    //        if (key == null) return;
    //        key.SetValue(nickname, salt, RegistryValueKind.Binary);
    //        key.Close();
    //    }

    //    private string GetAccessToken(string id)
    //    {
    //        var registryKey = Registry.CurrentUser.CreateSubKey(RegisterPath);
    //        if (registryKey != null)
    //        {
    //            try
    //            {
    //                var saltStr = registryKey.GetValue(id);
    //                if (saltStr == null)
    //                {
    //                    MessageBox.Show("Can not get saved access token for " + id +
    //                                    " user id. Program will delete all the stored data related to this id");
    //                    RemoveAccessToken(id);
    //                    return null;
    //                }
    //                var salt = saltStr as byte[];
    //                var toUnprotect = _defaultSettings.Accounts[1];///////////////////////////////////////
    //                var bytes = Convert.FromBase64String(toUnprotect);
    //                var tokenBytes = ProtectedData.Unprotect(bytes, salt, DataProtectionScope.CurrentUser);
    //                var accessToken = Encoding.Unicode.GetString(tokenBytes);
    //                return accessToken;
    //            }
    //            catch (CryptographicException)
    //            {
    //                MessageBox.Show("Can not decrypt saved access token for " + id +
    //                                " user id. Program will delete all the stored data related to this id");
    //                RemoveAccessToken(id);
    //                registryKey.DeleteValue(id);
    //                registryKey.Close();
    //                return null;
    //            }
    //        }
    //        MessageBox.Show("Unknown error ocured while trying to access saved access token for " + id + " user id");
    //        return null;
    //    }
    //}
}