.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         
  .ver 1:0:5000:0
}
.assembly BadClass
{
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}

.module BadClass.dll
.imagebase 0x00400000
.subsystem 0x00000003
.file alignment 512
.corflags 0x00000001

.class public auto ansi beforefieldinit BadClass
       extends [mscorlib]System.Object
{ } 

.class public auto ansi beforefieldinit BadClass
       extends [mscorlib]System.Object
{
  .method public hidebysig instance void 
          BadMethod() cil managed
  {
    .maxstack  1
    IL_0000:  newobj     instance void [mscorlib]System.Object::.ctor()
    IL_0005:  throw
  }

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    .maxstack  1
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  }

}