// C# code to open a psd file, updating text layers and drawing using Graphics API in a Docker container using Aspose.PSD.
// See https://docs.aspose.com/psd/net/how-to-run-aspose-psd-in-docker/ for complete details.

using Aspose.PSD;
using Aspose.PSD.Brushes;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

namespace AsposePsdDockerSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // If you want to update text, this value shoud be true, but in this case you will need the License.
            // You can get the temporary license using this article: https://purchase.aspose.com/temporary-license
            // Also, if you need text editing under the linux, please add to the dockerfile the following comannds
            // to install the packages:
            // RUN apt-get update
            // RUN yes | apt - get install - y apt - transport - https
            // RUN yes | apt - get install - y libgdiplus
            // RUN yes | apt - get install - y libc6 - dev

            var updateText = false;

            if (updateText)
            {
                var license = new License();                
                license.SetLicense(@"Aspose.PSD.NET.lic");
            }


            // If you want to use Blending Effects, please specify the following options:
            var options = new PsdLoadOptions() { LoadEffectsResource = true };
            using (var img = (PsdImage)Image.Load("PsdDockerExample.psd", options))
            {
                if (updateText)
                {
                    var textLayer = (TextLayer)img.Layers[1];
                    textLayer.UpdateText("Welcome to the dockerized Aspose.PSD");
                }

                var regularLayer = img.Layers[2];

                // Did you want to use Aspose.PSD in docker under the Linux? Your wish is granted, just add the second eye to Daruma
                var gr = new Graphics(regularLayer);
                var brush = new SolidBrush() { Color = Color.FromArgb(1, 1, 1), Opacity = 255 };
                var secondEyeZone = new Rectangle(129, 77, 20, 20);
                gr.FillEllipse(brush, secondEyeZone);

                img.Save("Output.psd");
                img.Save("Output.png", new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
            }
        }
    }
}