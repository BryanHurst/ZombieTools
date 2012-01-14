using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AionMemory;

namespace ZombieTools	
{
	public partial class mainForm : Form
	{
        //The Aion player
        Player player;

        //From AionMemory, current target class
		Target target;
		
        //String to hold player in question
		string currentPlayer = null;
		
        //Is browser loading page?
		bool delayExecution = true;

        /// <summary>
        /// mainForm constructor.
        /// </summary>
		public mainForm()
		{
            //Find Aion game process and wait
            Application.Run(new AttachBar());
			
            //Init GUI components
			InitializeComponent();			
		}

        /// <summary>
        /// On main form load, setup Aion player and target, 
        /// then direct browser.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		void MainFormLoad(object sender, EventArgs e)
		{
            //Setup Aion player and target
            setupAionEntities();

            //Webpage to display in the window.
            //Awesome mini Aion search.
			browser.Url = new Uri("http://search.na.aiononline.com/aionmini/index.jsp");
		}

        /// <summary>
        /// Setup the player with the current player in Aion,
        /// then setup target with the current player's target in Aion.
        /// </summary>
        private void setupAionEntities()
        {
            try
            {
                //Get the current Aion Player
                player = new Player();

                //Setup a target class
                target = new Target();
            }
            catch (OverflowException)
            {

                Process.Close();
                checkTimer.Stop();
                new AttachBar().ShowDialog();
                checkTimer.Start();
                
            }
        }

        /// <summary>
        /// When finished loading webpage: don't delay execution 
        /// and lookup the current target if not null
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		void BrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
            //Let program know it is okay to process next data set since webpage is done
			delayExecution = false;
			
			if (currentPlayer != null)
			{
				LookupPlayer();
			}
		}
		
        /// <summary>
        /// Check that the website is done loading, then look up player.
        /// Loopup takes current player and puts into the website's search box.
        /// It then simply hits the ok button! Then we are done! YAY!
        /// </summary>
		void LookupPlayer()
		{
            //If not loading the a webpage
			if (!delayExecution)
			{
                //Get the searchbox in the website
				var searchBox = browser.Document.GetElementById("schar");
                //Get the submit button in the website
				var searchButton = browser.Document.GetElementById("schar_submit");
				
                //Append current player to the search field
				searchBox.SetAttribute("value", currentPlayer);
                //Submit search quary 
				searchButton.InvokeMember("Click");
			}
		}
		
        /// <summary>
        /// Grabs current target,
        /// checks type,
        /// and saves info
        /// </summary>
		void UpdateData()
		{
            try
            {
                //Grab Player information, will catch changing characters
                player.Update();
                //Grab characters current target
                target.Update();

                //Make sure it is a player not NPC
                if (target.Type == eType.Player)
                {
                    //Get a clean name of the current target
                    var name = CleanString(target.Name);

                    //Don't do it if already displaying target's info... kinda silly
                    if (name != currentPlayer)
                    {
                        //Change current target player name
                        currentPlayer = name;
                        //Go look up the player
                        LookupPlayer();
                    }
                }
            }
            catch (NullReferenceException)
            {
                setupAionEntities();
            }
            catch (OverflowException)
            {
                setupAionEntities();
            }
		}

        /// <summary>
        /// Clean up the player name extracted from memory
        /// </summary>
        /// <param name="dirty">Messy Name From Memory To Clean Up</param>
		string CleanString(string dirty)
		{
			var sb = new StringBuilder();
			
            //Go through each bit of the input memory
			foreach (var c in dirty)
			{
                //If null (end of name)
				if (c == 0)
					break;
				
                //Add info to the building string
				sb.Append(c);
			}
			
            //Return toString() name to caller
			return sb.ToString();
		}
		
        /// <summary>
        /// Check timer to see if we should update target again.
        /// Doinga  timer so we don't flood everything to hell with checks.
        /// Timer is currently set to 100 delay.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		void CheckTimerTick(object sender, EventArgs e)
		{
			UpdateData();
		}

        /// <summary>
        /// Stub for menuStrip1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
	}
}
