using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDMAgent
{
    public static class FormExtension
    {
        public static void AppendLine(this TextBox source, string str)
        {
            if (source.Lines.Count() > 100)
                source.Text = "";

            if (source.TextLength == 0)
                source.Text = str;
            else
                source.AppendText("\r\n" + str);
        }
    }
}
