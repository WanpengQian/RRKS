# RemoveRegisterKeyService

This repository contains two programs designed for managing the Windows Registry key responsible for the Terminal Server Grace Period.

## RemoveRegisterKeyService

`RemoveRegisterKeyService` is a Windows service program that removes the values of the following Registry key:

```
SYSTEM\CurrentControlSet\Control\Terminal Server\RCM\GracePeriod
```

After deleting the values, it restarts the `TermService` service. The program has the following settings:

- **Interval:** The default is 1440 minutes (1 day). After the service starts, it executes once after 10 minutes. Subsequently, it checks at this interval.
- **Key:** Specifies the Registry key to check and delete.

## ServiceInstaller

`ServiceInstaller` is a GUI program that facilitates the installation, uninstallation, and viewing of the event log for `RemoveRegisterKeyService`.

### Build Information

- **Built with:** Visual Studio 2022, C#, and .NET 4.8.

### Compatibility

Tested with Windows Server 2016 and 2019.

Feel free to contribute, report issues, or provide feedback!