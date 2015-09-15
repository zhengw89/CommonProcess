using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonProcess.Demo
{
    public static class StringBuilderExtend
    {
        public static StringBuilder AppendSpace(this StringBuilder sb, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                sb.Append(" ");
            }
            return sb;
        }
    }
}
