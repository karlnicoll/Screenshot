using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace Screenshot
{
    /// <summary>
    /// A Class that provides methods to take and save a screenshot.
    /// </summary>
    /// <remarks>Do note that this class does not take a screenshot of any DirectX/OpenGL applications as they deal with the graphics hardware directly
    /// and circumvent the buffer from which the screenshot is taken.</remarks>
    public class Screenshot
    {
        //==================================================================================
        #region Data Structures



        #endregion

        //==================================================================================
        #region Enumerations



        #endregion

        //==================================================================================
        #region Constants



        #endregion

        //==================================================================================
        #region Events



        #endregion

        //==================================================================================
        #region Private Variables



        #endregion

        //==================================================================================
        #region Constructors/Destructors



        #endregion

        //==================================================================================
        #region Public Properties



        #endregion

        //==================================================================================
        #region Public Methods

        #region Entire Desk Area Shot

        /// <summary>
        /// Takes a screenshot of the entire screen
        /// </summary>
        public static Bitmap Take()
        {
            return Take("");
        }

        /// <summary>
        /// Takes a screenshot and saves it as the specified file in JPEG format
        /// </summary>
        /// <param name="Filename">The name of the file to save as</param>
        /// <returns>The screenshot as a bitmap</returns>
        public static Bitmap Take(string Filename)
        {
            return Take(Filename, ImageFormat.Jpeg);
        }

        /// <summary>
        /// Takes a screenshot and saves to the desired file and format.
        /// </summary>
        /// <param name="FileName">The path of the file to save it to</param>
        /// <param name="ImgFormat">The format of the image file</param>
        /// <returns>The screenshot bitmap</returns>
        public static Bitmap Take(string FileName, ImageFormat ImgFormat)
        {
            //Get width of entire desktop
            Rectangle bounds = new Rectangle(0, 0, 0, 0);

            //Find the furthest right and lowest screens to get the bounds of the screenshot
            foreach (Screen curScreen in Screen.AllScreens)
            {
                if (curScreen.Bounds.Right > bounds.Right)
                {
                    bounds.Width = curScreen.Bounds.Right;
                }

                if (curScreen.Bounds.Bottom > bounds.Bottom)
                {
                    bounds.Height = curScreen.Bounds.Bottom;
                }
            }

            //Return the fetched screenshot
            return Take(bounds, FileName, ImgFormat);
        }

        #endregion

        #region Specified Screen Screenshot

        /// <summary>
        /// Takes a screenshot of the specified monitor
        /// </summary>
        /// <param name="ClientScreen">The screen to take the screenshot of</param>
        /// <returns>The bitmap containing the screenshot</returns>
        public static Bitmap Take(Screen ClientScreen)
        {
            return Take(ClientScreen, "");
        }

        /// <summary>
        /// Takes a screenshot of the specified monitor and saves it as the specified file in JPEG format
        /// </summary>
        /// <param name="ClientScreen">The screen to take the screenshot of</param>
        /// <param name="Filename">The name of the file to save as</param>
        /// <returns>The screenshot as a bitmap</returns>
        public static Bitmap Take(Screen ClientScreen, string Filename)
        {
            return Take(ClientScreen, Filename, ImageFormat.Jpeg);
        }

        /// <summary>
        /// Takes a screenshot of the specified monitor and saves to the desired file and format.
        /// </summary>
        /// <param name="ClientScreen">The screen to take the screenshot of</param>
        /// <param name="FileName">The path of the file to save it to</param>
        /// <param name="ImgFormat">The format of the image file</param>
        /// <returns>The screenshot bitmap</returns>
        public static Bitmap Take(Screen ClientScreen, string FileName, ImageFormat ImgFormat)
        {
            //Return the fetched screenshot
            return Take(ClientScreen.Bounds, FileName, ImgFormat);
        }

        #endregion

        #region Specified Area Screenshot

        /// <summary>
        /// Takes a screenshot of the specified monitor
        /// </summary>
        /// <param name="ClientArea">The screen to take the screenshot of</param>
        /// <returns>The bitmap containing the screenshot</returns>
        public static Bitmap Take(Rectangle ClientArea)
        {
            return Take(ClientArea, "");
        }

        /// <summary>
        /// Takes a screenshot of the specified monitor and saves it as the specified file in JPEG format
        /// </summary>
        /// <param name="ClientArea">The screen to take the screenshot of</param>
        /// <param name="Filename">The name of the file to save as</param>
        /// <returns>The screenshot as a bitmap</returns>
        public static Bitmap Take(Rectangle ClientArea, string Filename)
        {
            return Take(ClientArea, Filename, ImageFormat.Jpeg);
        }

        /// <summary>
        /// Takes a screenshot
        /// </summary>
        /// <param name="ShotArea">The area of the screen to take a screenshot of</param>
        /// <param name="FileName">The path of the file in which the screenshot will be
        /// saved, if this is set to an empty string (i.e. String.Empty) then the
        /// screenshot will not be saved.</param>
        /// <param name="ImgFormat">The format of the image file, note that if the file path
        /// is not specified (i.e. String.Empty) then this parameter has no effect</param>
        /// <returns>The screenshot as a bitmap.</returns>
        /// <remarks>This is the master screenshot method, all other "Take" methods use 
        /// this method either directly, or through recursion</remarks>
        public static Bitmap Take(Rectangle ShotArea, string FileName, ImageFormat ImgFormat)
        {
            //Create the variable that holds the image
            Bitmap returnedImage = new Bitmap(ShotArea.Width, ShotArea.Height);

            //Get the screenshot
            using (Graphics gfx = Graphics.FromImage(returnedImage))
            {
                gfx.CopyFromScreen(ShotArea.Location, new Point(0, 0), ShotArea.Size);
            }

            //Save it if possible
            if (FileName != string.Empty)
            {
                returnedImage.Save(FileName, ImgFormat);
            }

            //Return the screenshot
            return returnedImage;
        }

        #endregion

        #endregion

        //==================================================================================
        #region Private/Protected Methods



        #endregion
    }
}
