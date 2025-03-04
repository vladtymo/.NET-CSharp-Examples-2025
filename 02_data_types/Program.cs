// ------------------- Data Types -------------------
/* All Types:
 *  - value types      : structures : stack (faster, size limited (~few MB))
 *  - reference types  : classes    : heap  (slower, no limit)
 */

int number = 10;      // value type     - stores in stack
string str = "Hello"; // reference type - stores in heap

int valueCopy = number;     // create copy of the 10
string referenceCopy = str; // create copy of the reference (address)

// --------- reference type can be null
string email = null;        // empty reference

//email.ToUpper(); // NullReference error

// --------- value cannot be null
//int averageMark = null;   // error

// nullable structure: Nullable<int>
int? averageMark = null;

// ?. - invoke if object is not null
averageMark?.ToString();
// ?? - return value if object is null
Console.WriteLine($"User email address: {email ?? "no email"}");

Console.WriteLine(number);
Console.WriteLine(str);    // go to heap

//number = 43.5;
//number = "Hello";

// const - constant value
const float bias = 3.2f;
//bias = 45; // error

// ------------------- Value Types -------------------
/*
 *  Integer-value types: 
     *  byte    | 1 byte  (0...255)
     *  short   | 2 bytes (-32xxx ... +32xxx)
     *  int     | 4 bytes (-2,147,483,648 ... 2,147,483,647)
     *  long    | 8 bytes
     *  
 * Unsigned: ushort, uint, ulong
     * ushort   | 2 bytes (0 ... 65xxx)
 
 *  Real-value types:
     *  float   | 4
     *  double  | 8
     *  decimal | 16 (for finnancial operations etc.)
     *  
 * Symbol type: char | 2 bytes
 * Logic type:  bool | 1 byte true/false (false: 0, true: other value)
 */

// ----------- Literals
Console.WriteLine($"{4}, type: {4.GetType()}");
Console.WriteLine($"{999L}, type: {999L.GetType()}");
Console.WriteLine($"{30.5}, type: {30.5.GetType()}");
Console.WriteLine($"{2.2F}, type: {2.2F.GetType()}");
Console.WriteLine($"{1.99M}, type: {1.99M.GetType()}");
Console.WriteLine($"{'A'}, type: {'A'.GetType()}");
Console.WriteLine($"{"B"}, type: {"B".GetType()}");

ushort width = 32767;
++width; // overflow with short
Console.WriteLine($"Width: {width} cm");

float koef = 4.5F;
decimal salary = 1300.80M;

char letter = 'A';
