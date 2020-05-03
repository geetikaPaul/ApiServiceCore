using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiServiceCore
{
    public static class Constants
    {
        public const string s3Path = "https://gpblogs.s3.amazonaws.com/";
        public static readonly string resumePath = string.Format("{0}Resume/Geetika_Paul_Resume.pdf",s3Path);
    }
}
