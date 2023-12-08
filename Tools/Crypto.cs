using System;
using System.Security.Cryptography;

namespace Tools
{
  public class Crypto
  {
    private static readonly string CARACTERES_MINUSCULES = "abcdefgijkmnopqrstwxyz";
    private static readonly string CARACTERES_MAJUSCULES = "ABCDEFGHJKLMNPQRSTWXYZ";
    private static readonly string CARACTERES_NUMERIQUES = "23456789";
    private static readonly string CARACTERES_SPECIAUX = "*$-+?_=!%{}#";

    public static string Generate(int length)
    {
      return Generate(length, length);
    }

    public static string Generate(int minLength, int maxLength)
    {
      char[] privateKey = null;
      try
      {
        if (minLength <= 0 || maxLength <= 0 || minLength > maxLength)
        {
          return null;
        }

        char[][] charGroups = new char[][]
            {
                CARACTERES_MINUSCULES.ToCharArray(),
                CARACTERES_MAJUSCULES.ToCharArray(),
                CARACTERES_NUMERIQUES.ToCharArray(),
                CARACTERES_SPECIAUX.ToCharArray()
            };

        int[] charsLeftInGroup = new int[charGroups.Length];

        for (int i = 0; i < charsLeftInGroup.Length; i++)
        {
          charsLeftInGroup[i] = charGroups[i].Length;
        }

        int[] leftGroupsOrder = new int[charGroups.Length];

        for (int i = 0; i < leftGroupsOrder.Length; i++)
        {
          leftGroupsOrder[i] = i;
        }

        byte[] randomBytes = new byte[4];

        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        rng.GetBytes(randomBytes);

        int seed = (randomBytes[0] & 0x7f) << 24 |
                    randomBytes[1] << 16 |
                    randomBytes[2] << 8 |
                    randomBytes[3];

        Random random = new Random(seed);

        if (minLength < maxLength)
        {
          privateKey = new char[random.Next(minLength, maxLength + 1)];
        }
        else
        {
          privateKey = new char[minLength];
        }

        int nextCharIdx;
        int nextGroupIdx;
        int nextLeftGroupsOrderIdx;
        int lastCharIdx;
        int lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;

        for (int i = 0; i < privateKey.Length; i++)
        {
          if (lastLeftGroupsOrderIdx == 0)
          {
            nextLeftGroupsOrderIdx = 0;
          }
          else
          {
            nextLeftGroupsOrderIdx = random.Next(0, lastLeftGroupsOrderIdx);
          }

          nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];
          lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;

          if (lastCharIdx == 0)
          {
            nextCharIdx = 0;
          }
          else
          {
            nextCharIdx = random.Next(0, lastCharIdx + 1);
          }

          privateKey[i] = charGroups[nextGroupIdx][nextCharIdx];
          if (lastCharIdx == 0)
          {
            charsLeftInGroup[nextGroupIdx] = charGroups[nextGroupIdx].Length;
          }
          else
          {
            if (lastCharIdx != nextCharIdx)
            {
              char temp = charGroups[nextGroupIdx][lastCharIdx];
              charGroups[nextGroupIdx][lastCharIdx] = charGroups[nextGroupIdx][nextCharIdx];
              charGroups[nextGroupIdx][nextCharIdx] = temp;
            }

            charsLeftInGroup[nextGroupIdx]--;
          }

          if (lastLeftGroupsOrderIdx == 0)
          {
            lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
          }
          else
          {
            if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
            {
              int temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
              leftGroupsOrder[lastLeftGroupsOrderIdx] = leftGroupsOrder[nextLeftGroupsOrderIdx];
              leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
            }

            lastLeftGroupsOrderIdx--;
          }
        }

      }
      catch (Exception exception)
      {
        throw new Exception(exception.Message); ;
      }

      return new string(privateKey);
    }
  }
}
