﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PracticeBlockChain.Test
{
    public class AddressExntensionsTest
    {
        [Fact]
        public void DerivingAddress()
        {
            var key = new PublicKey(
                new byte[]
                {
                        0x03, 0x43, 0x8b, 0x93, 0x53, 0x89, 0xa7, 0xeb, 0xf8,
                        0x38, 0xb3, 0xae, 0x41, 0x25, 0xbd, 0x28, 0x50, 0x6a,
                        0xa2, 0xdd, 0x45, 0x7f, 0x20, 0xaf, 0xc8, 0x43, 0x72,
                        0x9d, 0x3e, 0x7d, 0x60, 0xd7, 0x28,
                }
            );
            Assert.Equal(
                    new byte[]
                    {
                            0xd4, 0x1f, 0xad, 0xf6, 0x1b, 0xad, 0xf5, 0xbe,
                            0x2d, 0xe6, 0x0e, 0x9f, 0xc3, 0x23, 0x0c, 0x0a,
                            0x8a, 0x43, 0x90, 0xf0,
                    },
                new Address(key).AddressValue
            );
        }
    }
}