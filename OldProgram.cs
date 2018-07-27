// using System;
// using System.Diagnostics;

// namespace ConsoleApplication
// {
//     public class Program
//     {
//         public static void Main(string[] args)
//         {
//             // todo use delegate
//             var numberOfLoops = 1000000;
//             var timer = new Stopwatch();

//             timer.Start();
//             for (var i = 0; i < numberOfLoops; i++)
//             {
//                 try
//                 {
//                     var resonse = UsesExceptionsToCommunicateError();
//                 }
//                 catch (Exception e)
//                 {
//                     ErrorHandling(e.Message);
//                 }
//             }
            
//             timer.Stop();
//             Console.WriteLine($"Execution time with Exceptions: {timer.Elapsed}");

//             timer.Start();
//             for (var i = 0; i < numberOfLoops; i++)
//             {
//                 var response = UsesResponseObjectToCommunicateError();

//                 if (response.WasSucessful == false)
//                 {
//                     ErrorHandling(response.ErrorMessage);
//                 }
//             }
//             timer.Stop();
//             Console.WriteLine($"Execution time with Checking Response Object: {timer.Elapsed}");

//             timer.Start();
//             for (var i = 0; i < numberOfLoops; i++)
//             {
//                 var response = UsesNullToCommunicateError();

//                 if (response == null)
//                 {
//                     ErrorHandling("Not Found");
//                 }
//             }
//             timer.Stop();
//             Console.WriteLine($"Execution time with Null Check: {timer.Elapsed}");
//         }
//         private static ResponseObject UsesExceptionsToCommunicateError()
//         {
//             DoWork(new DomainObject(), 100)
//             throw new Exception();
//         }

//         private static ResponseObject UsesResponseObjectToCommunicateError()
//         {
//             DoWork(new DomainObject(), 100)
//             return new ResponseObject()
//             {
//                 WasSucessful = false,
//                 ErrorMessage = "Not Found"
//             };
//         }

//         private static ResponseObject UsesNullToCommunicateError()
//         {
//             DoWork(new DomainObject(), 100)
//             return null;
//         }

//         private static void ErrorHandling(string errorMessage)
//         {

//         }        

//         private static DomainObject DoWork(DomainObject payload, int whenToQuit)
//         {
//             if (payload.Loopzies == whenToQuit) return;

//             payload.Loopzies++;

//             DoWork(payload, whenToQuit);
//         }
//     }

//     public class DomainObject
//     {
//         public int Loopzies {get; set;}
//     }

//     public class ResponseObject
//     {
//         public bool WasSucessful { get; set; }
//         public string ErrorMessage { get; set; }
//     }    
// }
