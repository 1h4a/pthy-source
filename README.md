# pthy-source
Minecraft ParTicle HolographY engine in C# - view images and video in minecraft as a hologram!

You can literally use this to do anything in Minecraft. Literally anything. Make custom blocks with it for all I care. Add texture. Do whatever.

It's intended to draw images and video, but hey. It's open source. You can force it to render anything.

**To use PTHY's code in your own projects, provide proper credit referencing the github page. eg. 'Using code from PTHY (github.com/y3i/pthy-source)' Additionally, you must credit all used libraries or other external used projects as stated in this repository.**

**Installation:**
  
  Public release:
   - Release is pre-prepared. Simply extract the .zip and run.

  Source:
   - You need to install the [Emgu.CV](https://www.nuget.org/packages/Emgu.CV/4.4.0.4099), [Emgu.CV windows runtime](https://www.nuget.org/packages/Emgu.CV.runtime.windows/) and [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet packages. *You also need to install [Emgu.CV.UI](https://www.nuget.org/packages/Emgu.CV.UI/) and [Emgu.CV.Bitmap](https://www.nuget.org/packages/Emgu.CV.Bitmap/) - these two packages were added in v1.3.1 "the performance update" and are core to generating functions*
   - Standard VS2019 solution in C#. Pretty straightforward.
  
**Newest update:**

  *The current newest update is v1.3.1 "the performance update". Here are all the changes:*

    - Revamped the frame export, resize and function generation systems. Generation of full videos is now lightning fast!
    - Worked on resource usage - max RAM usage on an average ~480p video (before downscale) is around 100mb with CPU only ever peaking at 10%!
    - Proper disposal - no more RAM clogging!
    - No more working files - the *%appdata%\.minecraft\pthy* directory is now redundant, as no files except for the final functions are generated!

**FAQs:**

  Can I run it on Linux? _I have been asked this too many times now. You could try your luck with Mono, but there's no Linux release right now. I did have plans to work on one, but porting everything to Mono and potentially running into issues with existing libraries has proved to be a large issue. Plus, I don't even have a physical Linux machine._
  
  Can I run it on MacOS? _Same as the Linux question. You could try with Wine. There's currently no plans for a Mac release because I can't run MacOS even in a VM._
  
  The window doesn't open. _Check you have all the dependencies and you have the correct release for your PC (32-64 bit)_
  
  How do I view the video? _There's instructions in the actual software, but you can simply run the function that it tells you to run in a command block and that's all._
  
  I saw videos with sound in the showcases, yet I don't get any. How come? _The sound was added manually via a resource pack. Use the /playsound command with custom sounds to do this._
  
  It's so laggy! _I cannot stress this enough - Use OptiFine. It turns 5fps into 60 with this._
  
  The software freezes or crashes while I'm generating! _Update to the newest version. If this does not help, you may simply not have enough RAM. Try to optimize by closing other programs that use a lot of CPU or RAM like Minecraft itself._
  
  Can I have multiple of these in my world? _Yes, technically. To do this simply generate the video and change the namespace's name before generating again._
  
  Can I make my own project with your code? _Yes. Follow the proper crediting rules and include dependencies._
  
**Roadmap:**

  Current version (*1.3.1*) -> Linux Release 1.0 (LR1.0-1.4) -> Bedrock Support
  
  *Somewhere along the way, bug fixes as patches!*
  
~~**Current milestones:**~~ *check the milestones tab in issues for milestones, roadmap for planned things*
   
PTHY is the first, kinda user friendly software to create particle holograms easily.
Currently, there is support for video and image export - both are being updated and made better constantly.

PTHY uses Emgu.CV with the open source license. 

(u/timetobecomeegg)
