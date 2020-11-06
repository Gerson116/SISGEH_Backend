using SISGEH_Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISGEH_Backend.Services.SEncriptando
{
    public interface IHashService
    {
        HashResult Hash(string input);
        HashResult Hash(string input, byte[] salt);
    }
}
