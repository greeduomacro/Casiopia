del Server.exe
del Server.pdb
C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /unsafe /optimize /out:Server.exe /recurse:Server\*.cs /win32icon:Server\runuo.ico /optimize /warnaserror+ /d:Framework_4_0;ZLIB_WINAPI > Server.txt