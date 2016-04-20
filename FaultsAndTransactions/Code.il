.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )
  .ver 2:0:0:0
}

.assembly FaultsAndTransactionsInIL
{
  .custom instance void 
    [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void 
    [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = 
	  ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78 63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}

.module FaultsAndTransactionsInIL.exe
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003     
.corflags 0x00000001  

.class public abstract auto ansi sealed beforefieldinit FaultsAndTransactionsInIL.Calculations
  extends [mscorlib]System.Object
{
  .method public hidebysig static int32  Divide(int32 x, int32 y) cil managed
  {
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  div
    IL_0003:  ret
  }
}

.class public abstract auto ansi sealed beforefieldinit FaultsAndTransactionsInIL.Program
  extends [mscorlib]System.Object
{
  .method public hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    .maxstack  3
    .locals init (class FaultsAndTransactionsInIL.Transaction V_0,
             int32 V_1,
             int32 V_2)
    IL_0000:  ldnull
    IL_0001:  stloc.0    
	.try
    {
      .try
      {
        IL_0002:  newobj     instance void FaultsAndTransactionsInIL.Transaction::.ctor()
        IL_0007:  stloc.0
        IL_0008:  ldarg.0
        IL_0009:  ldc.i4.0
        IL_000a:  ldelem.ref
        IL_000b:  call       int32 [mscorlib]System.Int32::Parse(string)
        IL_0010:  stloc.1
        IL_0011:  ldarg.0
        IL_0012:  ldc.i4.1
        IL_0013:  ldelem.ref
        IL_0014:  call       int32 [mscorlib]System.Int32::Parse(string)
        IL_0019:  stloc.2
        IL_001a:  call       class [mscorlib]System.IO.TextWriter [mscorlib]System.Console::get_Out()
        IL_001f:  ldloc.1
        IL_0020:  ldloc.2
        IL_0021:  call       int32 FaultsAndTransactionsInIL.Calculations::Divide(int32,
                                                                              int32)
        IL_0026:  callvirt   instance void [mscorlib]System.IO.TextWriter::WriteLine(int32)
        IL_002b:  ldloc.0
        IL_002c:  callvirt   instance void FaultsAndTransactionsInIL.Transaction::Commit()
        IL_0031:  leave.s    IL_0084
      } 
      fault
      {
        IL_0034:  call       class [mscorlib]System.IO.TextWriter [mscorlib]System.Console::get_Out()
        IL_0039:  ldstr      "FAULT"
        IL_003e:  callvirt   instance void [mscorlib]System.IO.TextWriter::WriteLine(string)
        IL_0043:  ldloc.0
        IL_0044:  brfalse.s  IL_004c
        IL_0046:  ldloc.0
        IL_0047:  callvirt   instance void FaultsAndTransactionsInIL.Transaction::Rollback()
        IL_004c:  endfault
      }
      IL_0084:  leave.s    IL_0090
    }
    finally
    {
      IL_0086:  ldloc.0
      IL_0087:  brfalse.s  IL_008f
      IL_0089:  ldloc.0
      IL_008a:  callvirt   instance void FaultsAndTransactionsInIL.Transaction::Dispose()
      IL_008f:  endfinally
    }
    IL_0090:  ret
  }
}

.class public auto ansi sealed beforefieldinit FaultsAndTransactionsInIL.Transaction
  extends [mscorlib]System.Object
  implements [mscorlib]System.IDisposable
{
  .method public hidebysig specialname rtspecialname instance void  .ctor() cil managed
  {
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  }

  .method public hidebysig instance void Commit() cil managed
  {
    .maxstack  8
    IL_0000:  call       class [mscorlib]System.IO.TextWriter [mscorlib]System.Console::get_Out()
    IL_0005:  ldstr      "Commit"
    IL_000a:  callvirt   instance void [mscorlib]System.IO.TextWriter::WriteLine(string)
    IL_000f:  ret
  }

  .method public hidebysig newslot virtual final instance void Dispose() cil managed
  {
    .maxstack  8
    IL_0000:  call       class [mscorlib]System.IO.TextWriter [mscorlib]System.Console::get_Out()
    IL_0005:  ldstr      "Dispose"
    IL_000a:  callvirt   instance void [mscorlib]System.IO.TextWriter::WriteLine(string)
    IL_000f:  ret
  }

  .method public hidebysig instance void Rollback() cil managed
  {
    .maxstack  8
    IL_0000:  call       class [mscorlib]System.IO.TextWriter [mscorlib]System.Console::get_Out()
    IL_0005:  ldstr      "Rollback"
    IL_000a:  callvirt   instance void [mscorlib]System.IO.TextWriter::WriteLine(string)
    IL_000f:  ret
  }
}