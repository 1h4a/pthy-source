# pthy-source
Minecraft ParTicle HolographY engine - view images and video in minecraft as a hologram!

You can literally use this to do anything in Minecraft. Literally anything. Make custom blocks with it for all I care. Add texture. Do whatever.

It's intended to draw images and video, but hey. It's open source. You can force it to render anything.

**The original project written in C# is now discontinued, and work is underway on a C++ rewrite. All future updates including 3d rendering will be part of [Prism](https://github.com/1h4a/prism)**

**To use PTHY's code in your own projects, provide proper credit referencing the github page. eg. 'Using code from PTHY (github.com/y3i/pthy-source)' Additionally, you must credit all used libraries or other external used projects as stated in this repository.**

  **Installation:**
  
  Public release:
   - Release is pre-prepared. Simply extract the .zip and run.

  Source:
   - You need to install the [Emgu.CV](https://www.nuget.org/packages/Emgu.CV/4.4.0.4099), [Emgu.CV windows runtime](https://www.nuget.org/packages/Emgu.CV.runtime.windows/) and [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet packages. *You also need to install [Emgu.CV.UI](https://www.nuget.org/packages/Emgu.CV.UI/) and [Emgu.CV.Bitmap](https://www.nuget.org/packages/Emgu.CV.Bitmap/) - these two packages were added in v1.3.1 "the performance update" and are core to generating functions*
   - Standard VS2019 solution in C#. Pretty straightforward.
  
  **Usage:**
  
   The software on it's own should be pretty straight forward to use, but there are some specific details outside of it to keep in mind.
  
   Before you generate a video, make sure you enter the world you're generating to. Once it's done generating, run */reload* in Minecraft. 
  
   Before you ever even use this software, make sure you have *Optifine* installed and you've allocated atleast 4gb of RAM to the Minecraft profile. For optimal experience, use 8gb. Any less that 4gb will give you lag spikes constantly. Running it without Optifine will make sure you're viewing the video at a lovely 3 fps.
   
   Image generation has not been updated in ages, and so it does not generate into a specific world. You have to install it manually.
   
   I probably don't have to say this, but actually running the video requires you to have a beefy computer!
   
   That's it. Have fun!
   
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

PTHY uses Emgu.CV with the open source license. 
