To compile BadClass.il:

ilasm /dll BadClass.il

To compile CallingBadClass.cs:

csc /out:CallingBadClass.exe /r:BadClass.dll CallingBadClass.cs