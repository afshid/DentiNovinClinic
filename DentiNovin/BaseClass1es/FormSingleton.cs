using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace DentiNovin
{
    public class Singleton<T> where T : new()
    {
        protected Singleton()
        {
            if (Instance != null)
            {
                throw (new Exception("You have tried to create a new singleton class where you should have instanced it. Replace your \"new class()\" with \"class.Instance\""));
            }
        }

        public static T Instance
        {
            get
            {
                if (SingletonCreator.exception != null)
                {
                    throw SingletonCreator.exception;
                }
                return SingletonCreator.instance;
            }
        }

        class SingletonCreator
        {
            static SingletonCreator()
            {
                try
                {
                    instance = new T();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        exception = ex.InnerException;
                    }
                    else
                    {
                        exception = ex;
                    }
                    Trace.WriteLine("Singleton: " + exception);
                }
            }
            internal static readonly T instance;
            internal static readonly Exception exception;
        }

    }

    public class FormSingleton<TForm> where TForm : Form, new()
    {
        private static TForm _instance;
        public static TForm Form
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new TForm();
                }
                return _instance;
            }
        }
        public static void Show()
        {
            //Ensure the form is visible and has focus.
            Form.Show();
            Form.Activate();
        }

    }

    public class MdiFormSingleton<TForm> : FormSingleton<TForm> where TForm : Form, new()
    {
        public static void ShowChild(Form mdiParent)
        {
            {
                Form.MdiParent = mdiParent;
                Form.Show();
                Form.Activate();
            }
        }
    }
}
