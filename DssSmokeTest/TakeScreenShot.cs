using OpenQA.Selenium;
using System.Drawing.Imaging;

namespace DssAutomation
{
    public class Utilities

    {

        public static void TakeScreenshot(IWebDriver driver, string saveLocation)
        {
            ITakesScreenshot ssDriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssDriver.GetScreenshot();
            screenshot.SaveAsFile(saveLocation, ImageFormat.Png);
        }
    }

}
