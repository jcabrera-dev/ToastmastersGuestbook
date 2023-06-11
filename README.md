# Toastmaster Guest Book
This is a project I am working on for Toastmasters, I am creating a Guest Book sign in.
This example illustrates the following scenarios:

- A class registers a dependency property for its own use.
- A class implements several callbacks, such as PropertyChangedCallback, and ValidateValueCallback, for a set of related dependency properties. The callbacks are also used to adjust the values of other properties or to prevent an initial invalid value set. These callbacks are registered as part of the dependency property characteristics of a dependency property. Whenever the appropriate condition is detected by the property system, the user-defined callback is invoked. For instance, a change in the effective value of a property invokes the registered PropertyChangedCallback.

## Build the sample
The easiest way to use these samples without using Git is to download the zip file containing the current version (using the link below or by clicking the "Download ZIP" button on the repo page). You can then unzip the entire archive and use the samples in [Visual Studio 2017](https://www.visualstudio.com/wpf-vs).

### Deploying the sample
- Select Build > Deploy Solution. 

### Deploying and running the sample
- To debug the sample and then run it, press F5 or select Debug >  Start Debugging. To run the sample without debugging, press Ctrl+F5 or selectDebug > Start Without Debugging.