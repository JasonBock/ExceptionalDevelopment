// Metadata version: v4.0.30319
.assembly extern netstandard
{
  .publickeytoken = (CC 7B 13 FF CD 2D DD 51 )                         // .{...-.Q
  .ver 2:0:0:0
}
.assembly BadClass
{
  .custom instance void [netstandard]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = 
  ( 01 00 19 2E 4E 45 54 53 74 61 6E 64 61 72 64 2C   
  56 65 72 73 69 6F 6E 3D 76 32 2E 30 01 00 54 0E   
  14 46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C 61   
  79 4E 61 6D 65 00 )                               
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}

.module BadClass.dll
.imagebase 0x10000000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003
.corflags 0x00000001

.class public auto ansi beforefieldinit BadClass
       extends [netstandard]System.Object
{ } 

.class public auto ansi beforefieldinit BadClass
       extends [netstandard]System.Object
{
  .method public hidebysig instance void 
          BadMethod() cil managed
  {
    .maxstack  1
    IL_0000:  newobj     instance void [netstandard]System.Object::.ctor()
    IL_0005:  throw
  }

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    .maxstack  1
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [netstandard]System.Object::.ctor()
    IL_0006:  ret
  }
}