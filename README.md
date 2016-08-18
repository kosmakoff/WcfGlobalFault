# Wcf Global Fault

Experimenting with WCF higher matters: implemented the set of
service and endpoint behaviors to allow throwing typed Fault
Exception in every case when the error is not handled by user.
The error is recognized on client side as the typed FaultException.

This pattern can be used to avoid manual declaration of Fault Contracts
when lots of operations exist.

## Key moments when using in own code

1. On server side:
  * Declare the `behaviorExtensions` with both *Service* and *Endpoint* behavior extensions
  ```xml
  <system.serviceModel>
    <!-- cut -->
    <extensions>
      <behaviorExtensions>
        <add name="serviceErrorHandler" type="TheExtension.Service.UnhandledErrorBahaviorExtension, TheExtension, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />
        <add name="endpointErrorHandler" type="TheExtension.Endpoint.UnhandledErrorBehaviorExtension, TheExtension, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />
      </behaviorExtensions>
    </extensions>
    <!-- cut -->
  <system.serviceModel>
  ```
  * Use declared extensions in `serviceBehaviors` and `endpointBehaviors` sections
  ```xml
  <system.serviceModel>
    <!-- cut -->
    <behaviors>
      <endpointBehaviors>
        <behavior name="">
          <!-- cut -->
          <endpointErrorHandler />
        </behavior>
      </endpointBehaviors>
      <serviceBehaviors>
        <behavior name="">
          <!-- cut -->
          <serviceErrorHandler />
        </behavior>
      </serviceBehaviors>
    </behaviors>
  </system.serviceModel>
  ```
2. On client side
  * Declare the `behaviorExtensions` section and then use it in behavior
  ```xml
  <system.serviceModel>
    <extensions>
      <behaviorExtensions>
        <add name="endpointErrorHandler" type="TheExtension.Endpoint.UnhandledErrorBehaviorExtension, TheExtension, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />
      </behaviorExtensions>
    </extensions>
    <behaviors>
      <endpointBehaviors>
        <behavior name="">
          <!-- cut -->
          <endpointErrorHandler />
        </behavior>
      </endpointBehaviors>
    </behaviors>
  </system.serviceModel>
  ```
3. In client code - just catch the typed `FaultException` exception
```C#
try
{
    var result = client.Sum(int.MaxValue, 2);
}
catch (FaultException<UnhandledError> ex)
{
    Console.WriteLine($"Error: {ex.Message}\nType: {ex.GetType()}");
}
```
