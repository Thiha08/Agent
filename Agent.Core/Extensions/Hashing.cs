using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Agent.Core.Extensions
{
    public static class Hashing
    {
        public static string GetHMAC(string signatureString, string secretKey)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(secretKey);
            HMACSHA1 hmac = new HMACSHA1(keyByte);
            byte[] messageBytes = encoding.GetBytes(signatureString);
            byte[] hashmessage = hmac.ComputeHash(messageBytes);
            return ByteArrayToHexString(hashmessage);
        }

        private static string ByteArrayToHexString(byte[] Bytes)
        {
            StringBuilder Result = new StringBuilder();
            string HexAlphabet = "0123456789ABCDEF";
            foreach (byte B in Bytes)
            {
                Result.Append(HexAlphabet[(int)(B >> 4)]);
                Result.Append(HexAlphabet[(int)(B & 0xF)]);
            }
            return Result.ToString();
        }
    }
}
