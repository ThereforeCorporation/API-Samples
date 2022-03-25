using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Therefore.KeyVault
{
    class TheAzureKeyVault
    {
        public TheAzureKeyVault(string azureAppID_, string azureAuthKey_, string azureKeyVaultUri_)
        {
            azureAppID = azureAppID_;
            azureAuthKey = azureAuthKey_;
            azureKeyVaultUri = azureKeyVaultUri_;
            keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetAzureADToken));
        }

        /// <summary>
        /// Key Vault Client instance with callback function set.
        /// </summary>
        public KeyVaultClient keyVaultClient = null;
        /// <summary>
        /// A timeout value in ms that limits cancels calls to Azure. Default value is 15000 if not configured.
        /// </summary>
        private int nTimeout = String.IsNullOrEmpty(Environment.GetEnvironmentVariable("Azure.RequestTimeout")) ? 15000 : int.Parse(Environment.GetEnvironmentVariable("Azure.RequestTimeout"));
        /// <summary>
        /// App ID (or client ID) of an App registered in the Azure Active Directory.
        /// </summary>
        private string azureAppID;
        /// <summary>
        /// Authentication Key (or client secret) of an App registered in the Azure Active Directory.
        /// </summary>
        private string azureAuthKey;
        /// <summary>
        /// URI to an Azure Key Vault.
        /// </summary>
        private string azureKeyVaultUri;
        /// <summary>
        /// Name of a cryptographic key, stored in the Azure Key Vault.
        /// </summary>
        private string azureKeyName = "";

        /// <summary>
        /// Name of a cryptographic key, stored in the Azure Key Vault.
        /// </summary>
        public string KeyName
        {
            get { return azureKeyName; }
            set { azureKeyName = value; }
        }

        /// <summary>
        /// Checks if the app.config contains all required settings for accessing the Azure Key Vault.
        /// </summary>
        /// <returns>Returns true if Azure settings are configured.</returns>
        public bool IsConfigured()
        {
            if (String.IsNullOrEmpty(azureAppID) ||
                String.IsNullOrEmpty(azureAuthKey) ||
                String.IsNullOrEmpty(azureKeyVaultUri))
                return false;
            return true;
        }

        /// <summary>
        /// Decrypts the parameter by using RSA.
        /// </summary>
        /// <param name="strTextToDecrypt">A Base64 text string to be decrypted.</param>
        /// <returns>Returns the decrypted value as string.</returns>
        public string DecryptText(string strTextToDecrypt)
        {
            return DecryptText(strTextToDecrypt, azureKeyName);
        }

        /// <summary>
        /// Decrypts the parameter by using RSA.
        /// </summary>
        /// <param name="strTextToDecrypt">A Base64 text string to be decrypted.</param>
        /// <param name="strKeyName">Name of a cryptographic key, stored in the Azure Key Vault.</param>
        /// <returns>Returns the decrypted value as string.</returns>
        public string DecryptText(string strTextToDecrypt, string strKeyName)
        {
            byte[] data = Convert.FromBase64String(strTextToDecrypt);
            return Decrypt(data, strKeyName);
        }

        /// <summary>
        /// Decrypts the parameter by using RSA.
        /// </summary>
        /// <param name="data">Data to be decrypted.</param>
        /// <returns>Returns the decrypted value as string.</returns>
        public string Decrypt(byte[] data)
        {
            return Decrypt(data, azureKeyName);
        }

        /// <summary>
        /// Decrypts the parameter by using RSA.
        /// </summary>
        /// <param name="data">Data to be decrypted.</param>
        /// <param name="strKeyName">Name of a cryptographic key, stored in the Azure Key Vault.</param>
        /// <returns>Returns the decrypted value as string.</returns>
        public string Decrypt(byte[] data, string strKeyName)
        {
            if (String.IsNullOrEmpty(strKeyName))
                throw new Exception("Please specify a key for decryption.");

            try
            {
                var ts = new CancellationTokenSource();
                ts.CancelAfter(nTimeout);
                var key = keyVaultClient.GetKeyAsync(azureKeyVaultUri, strKeyName, ts.Token).GetAwaiter().GetResult();

                var publicKey = Convert.ToBase64String(key.Key.N);
                using (var rsa = new RSACryptoServiceProvider())
                {
                    var p = new RSAParameters() { Modulus = key.Key.N, Exponent = key.Key.E };
                    rsa.ImportParameters(p);

                    // Decrypt
                    var decryptedData = keyVaultClient.DecryptAsync(azureKeyVaultUri, strKeyName, "", JsonWebKeyEncryptionAlgorithm.RSA15, data).GetAwaiter().GetResult();
                    var decryptedText = Encoding.Unicode.GetString(decryptedData.Result);

                    return decryptedText;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured during decryption.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Encrypts the parameter by using RSA.
        /// </summary>
        /// <param name="textToEncrypt">A text string to be encrypted.</param>
        /// <returns>Returns a Base64 string of the enrypted text.</returns>
        public string EncryptText(string textToEncrypt)
        {
            return EncryptText(textToEncrypt, azureKeyName);
        }
        /// <summary>
        /// Encrypts the parameter by using RSA.
        /// </summary>
        /// <param name="textToEncrypt">A text string to be encrypted.</param>
        /// <param name="strKeyName">Name of a cryptographic key, stored in the Azure Key Vault.</param>
        /// <returns>Returns a Base64 string of the enrypted text.</returns>
        public string EncryptText(string textToEncrypt, string strKeyName)
        {
            return Convert.ToBase64String(Encrypt(textToEncrypt, strKeyName));
        }


        /// <summary>
        /// Encrypts the parameter by using RSA.
        /// </summary>
        /// <param name="textToEncrypt">A text string to be encrypted.</param>
        /// <returns>Returns a Byte Array of the enrypted text.</returns>
        public byte[] Encrypt(string textToEncrypt)
        {
            return Encrypt(textToEncrypt, azureKeyName);
        }

        /// <summary>
        /// Encrypts the parameter by using RSA.
        /// </summary>
        /// <param name="textToEncrypt">A text string to be encrypted.</param>
        /// <param name="strKeyName">Name of a cryptographic key, stored in the Azure Key Vault.</param>
        /// <returns>Returns a Byte Array of the enrypted text.</returns>

        public byte[] Encrypt(string textToEncrypt, string strKeyName)
        {
            if (String.IsNullOrEmpty(strKeyName))
                throw new Exception("Please specify a key for encryption.");

            try
            {
                var ts = new CancellationTokenSource();
                ts.CancelAfter(nTimeout);
                var key = keyVaultClient.GetKeyAsync(azureKeyVaultUri, strKeyName, ts.Token).GetAwaiter().GetResult();

                var publicKey = Convert.ToBase64String(key.Key.N);
                using (var rsa = new RSACryptoServiceProvider())
                {
                    var p = new RSAParameters() { Modulus = key.Key.N, Exponent = key.Key.E };
                    rsa.ImportParameters(p);
                    var byteData = Encoding.Unicode.GetBytes(textToEncrypt);

                    // Encrypt
                    return rsa.Encrypt(byteData, false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured during encryption.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the public RSA key stored in the Key Vault.
        /// </summary>
        /// <param name="rsaParams">Reference to store RSA parameters into.</param>
        /// <returns>Returns true if the key could be retrieved.</returns>
        public bool GetPublicKey(ref RSAParameters rsaParams)
        {
            return GetPublicKey(ref rsaParams, azureKeyName);
        }

        /// <summary>
        /// Retrieves the public RSA key stored in the Key Vault.
        /// </summary>
        /// <param name="rsaParams">Reference to store RSA parameters into.</param>
        /// <param name="strKeyName">Name of a cryptographic key to be retrieved.</param>
        /// <returns>Returns true if the key could be retrieved.</returns>

        public bool GetPublicKey(ref RSAParameters rsaParams, string strKeyName)
        {
            try
            {
                var ts = new CancellationTokenSource();
                ts.CancelAfter(nTimeout);
                var key = keyVaultClient.GetKeyAsync(azureKeyVaultUri, strKeyName, ts.Token).GetAwaiter().GetResult();
                rsaParams.Modulus = key.Key.N;
                rsaParams.Exponent = key.Key.E;
                return true;
            }
            catch (KeyVaultErrorException ex)
            {
                if (String.Compare("KeyNotFound", ex.Body.Error.Code, true) == 0)
                    return false;
                throw new Exception("Failed to retrieve public key.\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve public key.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Creates a new RSA key in the Azure Key Vault.
        /// </summary>
        /// <param name="rsaParams">Reference to store RSA parameters of the created key into.</param>
        public void CreateKey(ref RSAParameters rsaParams)
        {
            CreateKey(ref rsaParams, azureKeyName);
        }

        /// <summary>
        /// Creates a new RSA key in the Azure Key Vault.
        /// </summary>
        /// <param name="rsaParams">Reference to store RSA parameters of the created key into.</param>
        /// <param name="strKeyName">Name of the cryptographic key to be created.</param>

        public void CreateKey(ref RSAParameters rsaParams, string strKeyName)
        {
            try
            {
                var ts = new CancellationTokenSource();
                ts.CancelAfter(nTimeout);
                var key = keyVaultClient.CreateKeyAsync(azureKeyVaultUri, strKeyName, JsonWebKeyType.Rsa, cancellationToken: ts.Token).GetAwaiter().GetResult();
                rsaParams.Modulus = key.Key.N;
                rsaParams.Exponent = key.Key.E;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured during key generation.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Callback function for retrieving an Azure Active Directory Token.
        /// </summary>
        private async Task<string> GetAzureADToken(string authority, string resource, string scope)
        {
            var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(azureAppID, azureAuthKey);
            AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);

            if (result == null)
                throw new InvalidOperationException("Failed to obtain the Azure AD token");

            return result.AccessToken;
        }

        public string GetSecret(string sKeyVaultBaseUrl, string sSecretName)
        {
            string sSecret = "";
            if (String.IsNullOrEmpty(sKeyVaultBaseUrl))
            {
                sKeyVaultBaseUrl = azureKeyVaultUri;
            }
            try
            {
                var ts = new CancellationTokenSource();
                ts.CancelAfter(15000);
                var secretKey = keyVaultClient.GetSecretAsync(sKeyVaultBaseUrl, sSecretName, ts.Token).GetAwaiter().GetResult();
                sSecret = secretKey.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get secret from key vault.\n" + ex.Message);
            }
            return sSecret;
        }
        public string GetSecret(string sSecretName)
        {
            return GetSecret(azureKeyVaultUri, sSecretName);
        }
        public string SetSecret(string sKeyVaultBaseUrl, string sSecretName, string sSecret)
        {
            SecretBundle secretBundle;
            try
            { 
                var ts = new CancellationTokenSource();
                ts.CancelAfter(15000);
                secretBundle = keyVaultClient.SetSecretAsync(sKeyVaultBaseUrl, sSecretName, sSecret, null,
                    null, null, ts.Token).GetAwaiter().GetResult();

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to save secret to key vault.\n" + ex.Message);
            }

            if (secretBundle.Value != sSecret)
            {
                throw new Exception("Failed to save secret to key vault.\n");
            }
            return secretBundle.Value;
        }
        public string SetSecret(string sSecretName, string sSecret)
        {
            return SetSecret(azureKeyVaultUri, sSecretName, sSecret);
        }

        public CertificateBundle GetCertificate(string sKeyVaultBaseUrl, string sCertificateName)
        {
            CertificateBundle certificate;
            try
            {
                var ts = new CancellationTokenSource();
                ts.CancelAfter(15000);
                certificate = keyVaultClient.GetCertificateAsync(sKeyVaultBaseUrl, sCertificateName, ts.Token).Result;

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get certificate from vault.\n" + ex.Message);
            }

            return certificate;
        }

        public CertificateBundle GetCertificate(string sCertificateName)
        {
            return GetCertificate(azureKeyVaultUri, sCertificateName);
        }
    }
}

