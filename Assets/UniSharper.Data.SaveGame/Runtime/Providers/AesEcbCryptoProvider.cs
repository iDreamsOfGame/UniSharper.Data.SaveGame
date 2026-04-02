// Copyright (c) Jerry Lee. All rights reserved. Licensed under the MIT License.
// See LICENSE in the project root for license information.

using System.Security.Cryptography;
using ReSharp.Security.Cryptography;

namespace UniSharper.Data.SaveGame.Providers
{
    /// <summary>
    /// Provides AES encryption and decryption functionality using ECB (Electronic Codebook) mode.
    /// This class implements the <see cref="UniSharper.Data.SaveGame.Providers.ICryptoProvider"/> interface for secure data encryption in save game operations.
    /// </summary>
    public class AesEcbCryptoProvider : ICryptoProvider
    {
        public int EncryptionKeyLength => 16;

        public byte[] Encrypt(byte[] data, byte[] key) => AesCryptoUtility.Encrypt(data, key, null, CipherMode.ECB);

        public byte[] Decrypt(byte[] data, byte[] key) => AesCryptoUtility.Decrypt(data, key, null, CipherMode.ECB);
    }
}