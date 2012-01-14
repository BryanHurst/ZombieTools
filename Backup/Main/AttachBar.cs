using System;
using System.ComponentModel;
using System.Drawing;
using AionMemory;

using System.Windows.Forms;

namespace ZombieTools
{
    public partial class AttachBar : Form
    {
        //counter for number of time ticks
        private int count = 300;

        /// <summary>
        /// Constructor for AttachBar
        /// </summary>
        public AttachBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Listen for click on cancel button,
        /// exit program with no error
        /// </summary>
        private void onCancelClick(object sender, EventArgs e)
        {
            Environment.Exit(42);
        }

        /// <summary>
        /// Handler for the timer tick event,
        /// attempts to attach to the aion process and insures it has not 
        /// been running for to long
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onAttachTick(object sender, EventArgs e)
        {
            count--;
            if (count > 0)
            {
                //If the Aion process is found and attached to
                if (Process.Open())
                {
                    //return to caller and kill timer
                    System.Threading.Thread.Sleep(2000);
                    this.Close();
                }
            }
            else
            {
                //Aion process not found after timer ran out
                //Stop timer.
                ((Timer)sender).Stop();
                //Send timeout message and kill program
                timeout();
            }
        }

        /// <summary>
        /// Show timeout message and kill program with no error codes.
        /// </summary>
        private void timeout()
        {
            MessageBox.Show("Aion Process Not Found!\n\nPlease ensure Aion is opened when you start this program.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Environment.Exit(42);
        }

        private void AttachBar_Load(object sender, EventArgs e)
        {

        }
    }
}
