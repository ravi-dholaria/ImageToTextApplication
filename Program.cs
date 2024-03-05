using System;
using Tesseract;
namespace ImageToTextApplication
{
        class Program
        {
            static void Main(string[] args)
            {
                //Read image Path from console
                Console.WriteLine("Enter the path of the image file");
                string imagePath;
                imagePath = "C:\\Users\\Ravi Dholariya\\Pictures\\2024-01-31\\001.jpg";
                //imagePath = "C:\\Users\\Ravi Dholariya\\Pictures\\Saved Pictures\\Screenshot 2023-02-01 022623.png";
                //imagePath = "C:\\Users\\Ravi Dholariya\\Desktop\\test.png";

                if ( imagePath.Length == 0)
                {
                    Console.WriteLine("Please provide the path to the image file.");
                    return;
                }

                // Load Tesseract OCR data from the local directory
                string tessDataDir = "C:\\Program Files\\Tesseract-OCR\\tessdata";
                using (var engine = new TesseractEngine(tessDataDir, "eng", EngineMode.Default))
                {
                    // Load image using Tesseract
                    using (var img = Pix.LoadFromFile(imagePath))
                    {
                        //Image to grey scale
                        img.ConvertRGBToGray();
                    
                        using (var page = engine.Process(img))
                        {
                            // Extract text
                            var text = page.GetText();
                            
                            //remove any unwanted characters
                            text = text.Replace("\n"," ").Replace("\r", " ").Replace("\f", " ");
                            
                            // Remove any leading/trailing whitespace
                            text = text.Trim();

                            // Print extracted text to console


                            Console.WriteLine("Extracted Text:");
                            Console.WriteLine(text);
                        }
                    }
                }
                // Wait for user input
                Console.WriteLine("Press any key to exit...");
            }
        }
}

