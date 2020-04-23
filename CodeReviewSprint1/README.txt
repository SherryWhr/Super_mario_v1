README:

Warnings: 

1.
Warning	CA1811	'BrickBlockSprite.ChangeToUesd()' appears to have no upstream public or protected callers.	

This method is reserved for future feature

2.
Warning	CA1812	'xxx' is an internal class that is apparently never instantiated. If so, remove the code from the assembly. If this class is intended to contain only static methods, consider adding a private constructor to prevent the compiler from generating a default constructor.

All warnings similar to this one is due to classes reserved for future usages.

3.
Warning	CA1823	It appears that field 'xxx' is never used or is only ever assigned to. Use this field or remove it.

All warnings similar to this one is due to variables reserved for future usages.

4.
Warning	CA1801	Parameter 'gameTime' of 'xxx' is never used. Remove the parameter or use it in the method body.

All warnings similar to this one is due to parameter reserved for future usages.

5.
Warning	CS0414	The field 'xxx' is assigned but its value is never used.

All warnings similar to this one is due to variables (although assigned in constructors) reserved for future usages.

6.
Warning	CA1051	Because field 'xxx' is visible outside of its declaring type, change its accessibility to private and add a property, with the same accessibility as the field has currently, to provide access to it.

All warnings similar to this one is due to fields exposed, should use property instead. Expected to be fixed during Sprint 2.