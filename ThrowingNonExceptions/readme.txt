Remember to prefix the calls to csc and ilasm with the right directory. For example:

1.1: C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322
2.0: C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727

To compile BadClass.il:

ilasm /dll BadClass.il

To compile CallingBadClass.cs:

csc /out:CallingBadClass.exe /r:BadClass.dll CallingBadClass.cs

Note that 1.x does not support RuntimeCompatibilityAttribute, so CallingBadClass.cs must be modified to not have that attribute in the code. Also, by setting WrapNonExceptionThrows to false, 2.0 can mimic 1.x behavior.