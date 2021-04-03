using System;
using System.Windows.Forms;

using networking;
using services;

namespace client
{
    public class StartConcursClient
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //IChatServer server=new ChatServerMock();          
            IConcursServices server = new ConcursServerProxy("127.0.0.1", 55555);
            ConcursClientCtrl ctrl = new ConcursClientCtrl(server);
            Form1 win = new Form1(ctrl);
            Application.Run(win);
        }
    }
}