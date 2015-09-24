using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnythingAndEverything.Services.SchoolProjects.Automata.EncryptionProject.EncryptMessageUsingCypher
{
    interface IEncryptMessageUsingCypher
    {
        string UseCypherToEncodeNewString(char[,] cypher, string message);
        string UserCypherToDecodeString(char[,] cypher, string message);
    }
}
