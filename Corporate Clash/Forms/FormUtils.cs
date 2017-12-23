using System.Windows.Forms;

namespace CorporateClash.Forms
{
    public class FormUtils
    {
        public static void HideAllForms()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                int i1 = i; // Modified Closure for delegates. Can't directly access the index variable.

                if (Application.OpenForms[i] is FrmMain)
                {
                    Application.OpenForms[i]?.BeginInvoke((MethodInvoker)delegate
                    {
                        Application.OpenForms[i1]?.Hide();
                    });
                }
                else
                {
                    Application.OpenForms[i]?.BeginInvoke((MethodInvoker)delegate
                    {
                        Application.OpenForms[i1]?.Dispose();
                    });
                }
            }
        }
    }
}
