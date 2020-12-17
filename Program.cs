using System;
using System.Drawing;
using System.IO;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace pthy_video
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[!] PTHY (Particle Holography engine) v1.3.1");
            start();
        }

        public static void start()
        {
            string input;
            Console.WriteLine("...");
            input = Console.ReadLine();
            chcmd(input);
        }

        public static void image()
        {
            int maxWidth = 100, maxHeight = 100;
            string wrkdir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @".minecraft\pthy\"), genname = "generated_image.mcfunction";
            string path, input;
            Console.WriteLine("* Before image generation continues, please specify the path to the image you want to convert ^");
            path = Console.ReadLine();
            Console.WriteLine("* Now reading from " + path +". Is this path correct? (y/n)");
            input = Console.ReadLine();
            Directory.CreateDirectory(wrkdir);
            switch (input)
            {
                case "y":
                    Console.WriteLine("* Continuing with generation. Check info command for working directory.");
                    break;
                case "n":
                    Console.WriteLine("* nevermind :(");
                    Console.WriteLine("* Restarting generation module...");
                    image();
                    break;
                default:
                    Console.WriteLine("* sadly not an actual command :(");
                    Console.WriteLine("* Restarting generation module...");
                    image();
                    break;
            }

            // code continues here

            static Bitmap resizeImage(Bitmap imgToResize, Size size)
            {
                return new Bitmap(imgToResize, size);
            }
            static float normalize(float val, float max, float min)
            {
                return (val - min) / (max - min);
            }
            static float correctValue(float v, float d)
            {
                return v / d;
            }
            try
            {
                float multiplier, density, size;
                byte[] line = new UTF8Encoding(true).GetBytes("# hi there - u/timetobecomeegg");
                using (FileStream fs = File.Create(wrkdir + genname))
                {
                    fs.Write(line, 0, line.Length);
                    Console.WriteLine("* Please enter an image size multiplier - supports decimal values (0.1 - 2.0, recommended 0.75)");
                    multiplier = float.Parse(Console.ReadLine());
                    Console.WriteLine("* Please enter a particle density value - supports decimal values (1 - 20, recommended 7.5)");
                    density = float.Parse(Console.ReadLine());
                    Console.WriteLine("* Please enter a particle size value - supports decimal values (0.1 - 10, recommended 1.5");
                    size = float.Parse(Console.ReadLine());
                    Console.WriteLine("* All settings successfully registered! Starting work...");
                    Bitmap pimage = new Bitmap(path);
                    float width = multiplier * (pimage.Width / (pimage.Width / maxWidth)), height = multiplier * (pimage.Height / (pimage.Height / maxHeight));
                    Size _size = new Size((int)width, (int)height);
                    Bitmap image = resizeImage(pimage, _size);
                    image.RotateFlip(RotateFlipType.Rotate180FlipX);
                    for (int a = 0; a < image.Width; a++)
                    {
                        for (int b = 0; b < image.Height; b++)
                        {
                            System.Drawing.Color pixel = image.GetPixel(a, b);
                            float newR = normalize(pixel.R, 255f, 0f), newG = normalize(pixel.G, 255f, 0f), newB = normalize(pixel.B, 255f, 0f);
                            line = new UTF8Encoding(true).GetBytes("\nparticle minecraft:dust " + newR.ToString() + ' ' + newG.ToString() + ' ' + newB.ToString() + ' ' + size + " ~" + correctValue(a, density) + " ~" + (correctValue(b, density) + 1f) + " ~" + " 0 0 0 1 0 normal"); //particle minecraft:dust 0.7 0.5 0.3 1.0 ~-0.5 ~1 ~ 0 0 0 1 0 normal
                            fs.Write(line, 0, line.Length);
                        }
                    }
                    Console.WriteLine("* Generation done! .mcfunction file has been stored at " + wrkdir + genname);
                    Console.WriteLine("* enjoy ;)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void video()
        {
            static Bitmap resizeImage(Bitmap imgToResize, Size size)
            {
                return new Bitmap(imgToResize, size);
            }
            static float normalize(float val, float max, float min)
            {
                return (val - min) / (max - min);
            }
            static float correctValue(float v, float d)
            {
                return v / d;
            }
            static int GCD(int a, int b)
            {
                int Remainder;

                while (b != 0)
                {
                    Remainder = a % b;
                    a = b;
                    b = Remainder;
                }

                return a;
            }

            string wrkdir, mcmeta, path;
            Console.WriteLine("[!] Warning - PTHY's video functionality is still highly experimental.");
            Console.WriteLine("     The current method for video playback uses nested functions, and has no playback control.");
            Console.WriteLine("* Press enter to begin generation.");
            Console.ReadLine();
            Console.WriteLine("[!] Please enter a world and link the path to it. Make sure it has no datapacks.");
            wrkdir = Console.ReadLine();
            mcmeta = Path.Combine(wrkdir, @"datapacks\pthy");
            wrkdir = Path.Combine(wrkdir, @"datapacks\pthy\data\nspthy\functions");
            Directory.CreateDirectory(wrkdir);
            using (FileStream fs = File.Create(Path.Combine(mcmeta, "pack.mcmeta")))
            {
                Byte[] data = new UTF8Encoding(true).GetBytes("{");
                fs.Write(data, 0, data.Length);
                data = new UTF8Encoding(true).GetBytes("\n  \"pack\": {");
                fs.Write(data, 0, data.Length);
                data = new UTF8Encoding(true).GetBytes("\n    \"pack_format\": 6,");
                fs.Write(data, 0, data.Length);
                data = new UTF8Encoding(true).GetBytes("\n    \"description\": \"c# holography engine\"");
                fs.Write(data, 0, data.Length);
                data = new UTF8Encoding(true).GetBytes("\n  }");
                fs.Write(data, 0, data.Length);
                data = new UTF8Encoding(true).GetBytes("\n}");
                fs.Write(data, 0, data.Length);
            }
            Console.WriteLine("[!] Datapack created.");
            Console.WriteLine("[!] Please place a repeating command block with the following command:");
            Console.WriteLine("            /function nspthy:1          ");
            Console.WriteLine("[!] Make sure the command block is set to \"needs redstone\" and you have a means of powering it.");
            Console.WriteLine("     The command block will be set to \"always active\" automatically to ensure playback, so we recommend using a button.");
            Console.WriteLine("[!] Press enter to start pre-rendering.");
            Console.ReadLine();
            Console.WriteLine("[!] Please link the path to the video you wish to use.");
            path = Console.ReadLine();
            Console.WriteLine("* Rendering...");

            int i = 0, fc, ifc;
            double fps;
            float length; // video length in seconds

            using (var video = new VideoCapture(path))
            using (var img = new Mat())
            {
                ifc = (int)Math.Floor(video.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount)); // get amount of frames   
                fps = video.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps);
                length = ifc / (float)fps; // get length in seconds based on fps

                while (video.Grab())
                {
                    i++; // increment count
                    video.Retrieve(img); // retrieves frame

                    // CvInvoke.Imwrite(filename, img); // writes temp working frame
                    Image<Bgr, Byte> _image = img.ToImage<Bgr, Byte>();
                    Bitmap image = _image.ToBitmap(); // creates system.drawing image instance

                    float width = (image.Width / GCD(image.Width, image.Height)) * 10, height = (image.Height / GCD(image.Width, image.Height)) * 10; // sets up new image resolution (redundant gcd algorithm!)
                    Size _size = new Size((int)(width * 0.75), (int)(height * 0.75));

                    image = resizeImage(image, _size); // resizes image

                    string fpath = Path.Combine(wrkdir, $"{i}.mcfunction"); // creates function path

                    float density = 7.5f, size = 1.5f; // resolution scaling settings

                    byte[] line = new UTF8Encoding(true).GetBytes("# hi there - u/timetobecomeegg"); // first line

                    using (FileStream fs = File.Create(fpath)) // writes function
                    {
                        fs.Write(line, 0, line.Length);
                        image.RotateFlip(RotateFlipType.Rotate180FlipX);
                        for (int a = 0; a < image.Width; a++)
                        {
                            for (int b = 0; b < image.Height; b++)
                            {
                                System.Drawing.Color pixel = image.GetPixel(a, b);
                                float newR = normalize(pixel.R, 255f, 0f), newG = normalize(pixel.G, 255f, 0f), newB = normalize(pixel.B, 255f, 0f);
                                line = new UTF8Encoding(true).GetBytes("\nparticle minecraft:dust " + newR.ToString() + ' ' + newG.ToString() + ' ' + newB.ToString() + ' ' + size + " ~" + correctValue(a, density) + " ~" + (correctValue(b, density) + 1f) + " ~" + " 0 0 0 1 0 normal"); //particle minecraft:dust 0.7 0.5 0.3 1.0 ~-0.5 ~1 ~ 0 0 0 1 0 normal
                                fs.Write(line, 0, line.Length);
                            }
                        }

                        if (i == ifc) // test if the frame is the last one to reset command block
                        {
                            line = new UTF8Encoding(true).GetBytes("\ndata merge block ~ ~ ~ {Command:\"function nspthy:1\",TrackOutput:0b,auto:0b,UpdateLastExecution:1b}");
                            fs.Write(line, 0, line.Length);
                        }
                        else // sustain
                        {
                            line = new UTF8Encoding(true).GetBytes("\ndata merge block ~ ~ ~ {Command:\"function nspthy:" + (i + 1) + "\",TrackOutput:1b,auto:1b,UpdateLastExecution:1b}");
                            fs.Write(line, 0, line.Length);
                        }

                        image.Dispose();
                    }
                }
            }
            fc = i;
            Console.WriteLine($"* Render complete. ({fc})");
            Console.WriteLine("* Functions are now cast in real time. Generation done!");

            Console.WriteLine("* Generation done! Run \"function nspthy:1\" in a repeating command block to see your video.");
        }
            public static void chcmd(string input)
        {
            switch (input)
            {
                case "info":
                    Console.WriteLine("* by u/timetobecomeegg");
                    Console.WriteLine("* PTHY (Particle Holography engine) v0.1a");
                    Console.WriteLine("* An updated, new holography engine.");
                    Console.WriteLine("* New features:");
                    Console.WriteLine("* + Video generation!");
                    Console.WriteLine("* + Performance optimization");
                    Console.WriteLine("* + Much more user friendly (hi)");
                    Console.WriteLine("* + New resolution correction method (different aspect ratios)");
                    Console.WriteLine(@"* Additionally - PTHY generates image files in %appdata%\.minecraft\pthy");
                    Console.WriteLine("* have fun :)");
                    start();
                    break;
                case "help":
                    Console.WriteLine("* Currently available commands:");
                    Console.WriteLine("* 'help' - literally this command.");
                    Console.WriteLine("* 'info' - information about the engine");
                    Console.WriteLine("* 'image' - last-gen image generation");
                    Console.WriteLine("* 'video' - first-gen video generation");
                    Console.WriteLine("* 'exit' - take a guess.");
                    start();
                    break;
                case "exit":
                    Console.WriteLine("[!] Warning - Exit is used to shut-down the program with directory cleanup. Do you wish to continue?");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    Console.WriteLine("* Running cleanup operation...");
                    string cpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @".minecraft\pthy\");
                    System.IO.DirectoryInfo di = new DirectoryInfo(cpath); // set up new directory info variable in the .minecraft\pthy directory
                    try
                    {
                        foreach (FileInfo file in di.EnumerateFiles()) // delete all working directory files
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo dir in di.EnumerateDirectories()) // delete all sub-directories
                        {
                            dir.Delete(true);
                        }
                    }
                    catch
                    {
                        Console.WriteLine(@"[!] An exception was thrown during cleanup. Please check the %appdata%\.minecraft\pthy directory and delete all spare working files inside if they exist.");
                        Console.WriteLine("(EX02 enum cleanup failed)");
                        Console.WriteLine("Press enter to continue.");
                        Console.ReadLine();
                    }
                    
                    Environment.Exit(0); // exit the program
                    break;
                case "image": // finally. image generation.
                    image();
                    start();
                    break;
                case "video":
                    video();
                    start();
                    break;
                default:
                    Console.WriteLine("* no such command exists :(");
                    start();
                    break;
            }
        }
    }
}
