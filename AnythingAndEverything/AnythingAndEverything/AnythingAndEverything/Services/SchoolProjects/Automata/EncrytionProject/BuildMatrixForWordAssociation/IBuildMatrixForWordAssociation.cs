using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnythingAndEverything.Services.SchoolProjects.Automata.EncryptionProject.BuildMatrixForWordAssociation
{
    interface IBuildMatrixForWordAssociation
    {
        char[,] MatrixForLetterSwapFiveByFive();
    }
}