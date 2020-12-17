# pthy-source
Minecraft ParTicle HolographY engine in C#.

Here's the source code people asked for.

**Installation:**
  
  Public release:
   - Release is pre-prepared. Simply extract the .zip and run.

  Source:
   - You need to install the [Emgu.CV](https://www.nuget.org/packages/Emgu.CV/4.4.0.4099), [Emgu.CV windows runtime](https://www.nuget.org/packages/Emgu.CV.runtime.windows/) and [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/) NuGet packages.
   - Standard VS2019 solution in C#. Pretty straightforward.

**Additional info:**

  PTHY accesses the following directories without user input:
   - %appdata%\.minecraft\pthy
  
  PTHY is *still* not finished. A lot of the generation algorithms are unpolished - some examples are the last frame having a reference to a non-existant frame, anim.mcfunction failing to generate half the time and other issues. Take the software with a grain of salt.
  
**Current milestones:**

  - A Linux release could be done by the end of December. Note that the only way I will have of testing it is to run it in a VM, so performance will not be the greatest. Any linux devs which would be open to contribute to the repo are welcome to do so.
  
  - Real-time file cleanup - no need to run a separate command to remove working files.
  
  - Better resolution downscale algorithm - the current expression used to downscale video files is flawed, and may sometimes lift the resolution massively, resulting in 500mb function files.

The *exit* command should be used to quit the software, as it ensures file cleanup.
   
PTHY is the first, kinda user friendly software to create particle holograms easily.
Currently, there is support for video and image export - both are being updated and made better constantly.

PTHY uses Emgu.CV with the open source license. 

(u/timetobecomeegg)
