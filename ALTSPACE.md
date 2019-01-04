# Altspace Newtonsoft.Json Fork

Altspace maintains a fork of the Newtonsoft.Json repo as the requirements of the library code are unique to what is or should be provided by Newtonsoft.  This file contains the deviations that we have made, their reasoning, as well as the build steps required to generate the DLL for use within Altspace's codebase.

# Altspace Deviations

1. JsonTypeReflector.cs:463-481 - IL2CPP does not support dynamic code generation which Newtonsoft uses in cases where IEnumerable's and other collection interfaces are used within the C# code.  This is the case in many places within the MRE SDK, and requires that dynamic code generation be turned off altogether within the Newtonsof.Json library.

# Building Newtonsoft.Json for Altspace

You should utilize the `runbuild.ps1` script found within the `Build/` directory at the root of the repo.  This will run a build process that results in binaries being generated and placed in the `Src/Newtonsoft.Json/bin/Release/` directory.  We care about the `portable+net40+win8+wpa81+wp8+sl5` binary.  Copy the `.dll` and `.xml` files in to the Altspace `Assets/Plugins` directory.  