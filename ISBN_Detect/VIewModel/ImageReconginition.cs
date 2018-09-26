using Dynamsoft.OCR;
using System.Drawing;
using System.Windows;

namespace ISBN_Detect.VIewModel
{
    class ImageRecognition
    {
        /// <summary>
        /// Product key that provides access to Tesseract products in Dynamic .net Twain sdk.
        /// </summary>
        public string ProductKey { get; private set; } = "t0068UwAAADVSDnaM87kjXSXEa/Fd47objthsf10hkZQKUz5k7ukOG2TdeqPL+ZFaUGFPKRbm66RerLKk5UQVP/5R3ilnNTE=";
        /// <summary>
        /// Path to the Tesseract data such as language packs.
        /// </summary>
        public string TessDataPath { get; private set; } = System.IO.Directory.GetCurrentDirectory()+ "\\language_pack";
        /// <summary>
        /// Language of the detected image.
        /// </summary>
        public string Language { get; private set; } = "eng";
        /// <summary>
        /// Recongnizes text from image,
        ///     returns resulted text.
        /// </summary>
        /// <param name="image">Image for recognition.</param>
        public string Recognize(Bitmap image)
        {
            byte[] sbytes = null;
            string text = "";
            try
            {
                Tesseract OSR = new Tesseract(ProductKey);
                OSR.ResultFormat =0;
                OSR.TessDataPath = TessDataPath;
                OSR.Language = Language;
                sbytes = OSR.Recognize(image);
                if (sbytes != null && sbytes.Length > 0)
                {
                    text = System.Text.ASCIIEncoding.ASCII.GetString(sbytes);

                }
                else
                    MessageBox.Show("Programm can't recognize any text");
                
                               

            }
            catch (OCRException exp)
            {
                MessageBox.Show("Error Code: " + exp.Code.ToString() + "\nError String: " + exp.Message);
            }
            return text;


            
        }






    }
}
