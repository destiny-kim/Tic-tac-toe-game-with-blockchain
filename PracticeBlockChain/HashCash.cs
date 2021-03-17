using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;

namespace PracticeBlockChain
{
    public static class HashCash
    {
        public static Nonce CalculateHash(
            Block previousBlock, 
            BigInteger previousHash,
            BlockChain blockChain
        )
        {
            SHA256 hashAlgo = SHA256.Create();
            BigInteger hashDigest;
            Nonce nonce = null;

            do
            {
                // It's a genesis block.
                if (previousBlock == null)
                {
                    hashDigest = 0;
                    break;
                }
                nonce = new NonceGenerator().GenerateNonce();
                byte[] hashInput =
                    // (���� �ʿ�) ���� ����� �� �� �־�� ��
                    Block.Serialize(
                        previousHash.ToByteArray(),
                        nonce,
                        previousBlock.TimeStamp
                    );
                hashDigest = new BigInteger(hashAlgo.ComputeHash(hashInput));
            } while (hashDigest < blockChain.Difficulty);

            return nonce;
        }
    }
}