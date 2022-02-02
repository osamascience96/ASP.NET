# Points to discuss

## IWebHostEnvironment
The ***IWebHostEnvironment*** provides the inoformation about the *web hosting environment* on *application is running* in. This service is injected and is provided by the *Microsoft.AspNetCore.Hosting*.

## System.io.Path
This class is used as a *utility* that provides the data of the path of the current project, this project is relative path, nothing is absolute.

## IEnumerable
An *interface* that is the parent of all *iterable collections* like list, arrays etc. It returns the GetEnumerator function. And this parent collection can be used to iterate objects.

## using
It defines(initlize) the object and inside the block of *using* the object is used, and when the execution of the block is finished, the object is automatically destroyed.

## JsonPropertyName
It is used to add the annotation when during the procedure of serialization. It specifies the property name of the json data. When serialization, so during that process when we have added this annotation to any property of the class, then it will be mapped to that property of the json data.

## JsonSerilizer
It is static class in the system.test.json namespace. It provides functionality to serailize objects to JSON and deserialize for vise versa procedure of serialize.

## JsonSerilizerOptions
It is the options that we configure when in the process of serialization.

## PageModel
It is a class that takes functionality from Microsoft.AspNetCore.Mvc.RazorPages namespace. It also inherits from its classes. But when we see that the model of the view, it inherits from the PageModel, which enables you to work with HttpRequest, such as HttpContext, Request, Response, ViewData and ModelState is defined to us in the pipeline.
 
## MapRazorPages
The model we see of each page, when we request the resource, it simply returns the view and that view which is returned by that is mapped to the cshtml using **MapRazorPages** that is configured in the program.cs

## MapGet
A function that adds the endpoint to the specific request of Get method. It takes the string pattern and a callback that when anyone sends requests, the callback function runs, so we get service from application configured services of the <TValue> type that we get some data. Then we can convert that to JSON by Serializing it and write json response.

