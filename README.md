# pthy-source
Minecraft ParTicle HolographY engine in C# - view images and video in minecraft as a hologram!

You can literally use this to do anything in Minecraft. Literally anything. Make custom blocks with it for all I care. Add texture. Do whatever.

It's intended to draw images and video, but hey. It's open source. You can force it to render anything.

**Installation:**
  
  Public release:
   - Release is pre-prepared. Simply extract the .zip and run.

  Source:
   - You need to install the [Emgu.CV](https://www.nuget.org/packages/Emgu.CV/4.4.0.4099), [Emgu.CV windows runtime](https://www.nuget.org/packages/Emgu.CV.runtime.windows/) and [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet packages. *You also need to install [Emgu.CV.UI](https://www.nuget.org/packages/Emgu.CV.UI/) and [Emgu.CV.Bitmap](https://www.nuget.org/packages/Emgu.CV.Bitmap/) - these two packages were added in v1.3.1 "the performance update" and are core to generating functions*
   - Standard VS2019 solution in C#. Pretty straightforward.

**Additional info:**

  PTHY accesses the following directories without user input:
   - %appdata%\.minecraft\pthy
  
  PTHY is *still* not finished. A lot of the generation algorithms are unpolished. - ~~some examples are the last frame having a reference to a non-existant frame, anim.mcfunction failing to generate half the time and other issues.~~ Take the software with a grain of salt.
  
**Newest update:**

  *The current newest update is v1.3.1 "the performance update". Here are all the changes:*

    - Revamped the frame export, resize and function generation systems. Generation of full videos is now lightning fast!
    - Worked on resource usage - max RAM usage on an average ~480p video (before downscale) is around 100mb with CPU only ever peaking at 10%!
    - Proper disposal - no more RAM clogging!
    - No more working files - the *%appdata%\.minecraft\pthy* directory is now redundant, as no files except for the final functions are generated!
    
These changes should hopefully make PTHY much more usable and efficient, along with making it much more lightweight.
  
**Current milestones:**

  - A Linux release could be done by the end of December. Note that the only way I will have of testing it is to run it in a VM, so performance will not be the greatest. Any linux devs which would be open to contribute to the repo are welcome to do so.
  
  - ~~Real-time file cleanup - no need to run a separate command to remove working files.~~ Working files are now a thing of the past, as per v1.3.1!
  
  - Better resolution downscale algorithm - the current expression used to downscale video files is flawed, and may sometimes lift the resolution massively, resulting in 500mb function files.

  - ~~The *exit* command should be used to quit the software, as it ensures file cleanup.~~ Files are no longer written as per v1.3.1! The exit command is redundant and will be removed shortly.
   
PTHY is the first, kinda user friendly software to create particle holograms easily.
Currently, there is support for video and image export - both are being updated and made better constantly.

PTHY uses Emgu.CV with the open source license. 

(u/timetobecomeegg)
